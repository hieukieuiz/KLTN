<template>
  <div class="px-3">
    <h2 class="pt-5">QUẢN LÝ NHÓM VIỆC</h2>
    <v-row class="pt-0">
      <v-col cols="4" class="pt-0">
        <v-text-field
          class="pt-0 pb-3"
          hide-details
          placeholder="Tìm kiếm"
          append-icon="search"
          v-model="filters.keywords"
          @input="getDanhSAchDuAn(filters)"
        >
        </v-text-field>
      </v-col>
      <v-col cols="4"></v-col>
      <v-col cols="4" class="d-flex flex-row-reverse">
        <v-btn
          color="primary"
          @click="showModalThemSuaDuAn(false, {})"
          >Thêm mới</v-btn
        >
      </v-col>
    </v-row>
    <v-data-table
      :items="danhSachDuAn"
      :headers="tableHeader"
      @update:options="getDanhSAchDuAn"
      :options.sync="filters"
      :server-items-length="totalItems"
      class="elevation-0"
    >
    
      <template v-slot:item.thaotac="{ item }">
        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-btn
              v-on="on"
              color="primary"
              icon
              small
              @click="showModalThemSuaDuAn(true, item)"
              class="ma-0"
            >
              <v-icon size="15">edit</v-icon>
            </v-btn>
          </template>
          <span>Sửa</span>
        </v-tooltip>

        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-btn v-on="on" @click="confirmDelete(item)" color="red" icon small class="mx-1 ma-0">
              <v-icon size="15">delete</v-icon>
            </v-btn>
          </template>
          <span>Xóa</span>
        </v-tooltip>

        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-btn :to="item.linkQuanLiViec" class="ma-0 mr-1" icon small v-on="on">
                 <v-icon size="17" color="blue darken-2">mdi-library-books</v-icon>
            </v-btn>
          </template>
          <span>Quản Lí Việc</span>
        </v-tooltip>

        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-btn :disabled="isOverdue(item.thoiGianHetHan)" @click="showModalQuyenDuAn(item.id)" class="ma-0" icon small v-on="on">
                 <v-icon size="17" color="blue darken-2">mdi-account</v-icon>
            </v-btn>
          </template>
          <span>Cập nhật vai trò nhân sự</span>
        </v-tooltip>
      </template>

      <template v-slot:item.soLuongThanhVien="{ item }">
        <span class="mt-4">{{item.soLuongThanhVien}}</span>
        <v-tooltip top>
          <template v-slot:activator="{ on }" >
            <v-btn @click="showModalThemNhanSu(item)" v-on="on" color="blue" icon  class="mt-0">
                <v-icon>add_circle</v-icon>
            </v-btn>
          </template>
          <span>{{isOverdue(item.thoiGianHetHan)?'Xem Nhân Sự':'Cập nhật nhân sự'}}</span>
        </v-tooltip>
      </template>

      <template v-slot:item.tinhTrangViec="{ item }">
        <span v-if="item.trangThaiDuAn.length==0">Chưa có trạng thái nhóm việc</span>
        <span
            v-for="(item, indexTrangThai) in item.trangThaiDuAn"
            :key="indexTrangThai"
            class="pt-3 mr-3"
          >
             {{item.trangThai.tenTrangThai}}:{{item.soLuongCongViec}} 
             
          </span>
          
        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-btn :disabled="isOverdue(item.thoiGianHetHan)" @click="showModalThemSuaTrangThai(item)" v-on="on" color="blue" icon  class="mb-1">
                <v-icon>add_circle</v-icon>
            </v-btn>
          </template>
          <span>Thêm Trạng Thái</span>
        </v-tooltip>
      </template>

      <template v-slot:item.thoigian="{ item }">
        <div>
          {{
            (formatDate(item.thoiGianTao)=='Không xác định' && formatDate(item.thoiGianHetHan)=='Không xác định') ? 'không xác định':
            formatDate(item.thoiGianTao) + " -- " +formatDate(item.thoiGianHetHan)
          }}
        </div>
      </template>
    </v-data-table>
    <div>
      <modal-them-sua-trang-thai ref="ModalThemSuaTrangThai" @updated="getDanhSAchDuAn(filters)"></modal-them-sua-trang-thai>
      <modal-them-sua-du-an ref="ModalThemSuaDuAn" @updated="getDanhSAchDuAn(filters)"></modal-them-sua-du-an>
      <modal-them-sua-nhan-su ref="modalThemSuaNhanSu" @updated="getDanhSAchDuAn(filters)"></modal-them-sua-nhan-su>
      <modal-them-sua-quyen-du-an ref="ModalThemSuaQuyenDuAn" @updated="getDanhSAchDuAn(filters)"></modal-them-sua-quyen-du-an>
    </div>
     <v-dialog v-model="dialogConfirmDelete" max-width="290">
      <v-card>
        <v-card-title class="headline">Xác nhận xóa</v-card-title>
        <v-card-text class="pt-3">Bạn có chắc chắn muốn xóa?</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn @click.native="dialogConfirmDelete=false" text>Hủy</v-btn>
          <v-btn :loading="loading" color="red darken-1" text @click="deleteDuAn">Xác Nhận</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    
  </div>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import ModalThemSuaNhanSu from "./ModalThemSuaNhanSu.vue";
import { DuAnDTO } from "../../models/DuAnDTO";
import DuAnApi, { GetDuAnParams } from "../../apiResources/DuAnApi";
import ModalThemSuaDuAn from "./ModalThemSuaDuAn.vue";
import ModalThemSuaTrangThai from "./ModalThemSuaTrangThaiDuAn.vue";
import ModalThemSuaQuyenDuAn from "./ModalThemSuaQuyenDuAn.vue";

export default Vue.extend({
  components: {
    ModalThemSuaNhanSu,
    ModalThemSuaDuAn,
    ModalThemSuaTrangThai,
    ModalThemSuaQuyenDuAn
  },
  data() {
    return {
      dialogConfirmDelete:false,
      tableHeader: [
        {
          text:"#",
          value: "soThuTu",
          fixed: true,
          width: "10px",
          sortable: false,
          align: "center",
        },
        {
          text: "Tên nhóm việc",
          value: "tenDuAn",
          fixed: true,
          width: "100px",
          sortable: false,
          align: "left",
        },
        {
          text: "Thời gian",
          value: "thoigian",
          fixed: true,
          width: "100px",
          sortable: false,
          align: "left",
        },
        {
          text: "Số NS",
          value: "soLuongThanhVien",
          fixed: true,
          width: "20px",
          sortable: false,
          align: "center",
        },
        {
          text: "Tình trạng việc",
          value: "tinhTrangViec",
          fixed: true,
          width: "220px",
          sortable: false,
          align: "left",
        },
        {
          text: "Thao tác",
          value: "thaotac",
          fixed: true,
          width: "100px",
          sortable: false,
          align: "center",
        },
      ],
      filters: {} as GetDuAnParams,
      totalItems: 0 as number | undefined,
      danhSachDuAn: [] as DuAnDTO[],
      loading: false,
      duAnSelected:{} as DuAnDTO,
      today:new Date(),
    };
  },
  created() {
    this.getDanhSAchDuAn(this.filters);
  },
  methods: {
    showModalThemSuaDuAn(isUpdate: boolean, item: any) {
      (this.$refs.ModalThemSuaDuAn as any).show(isUpdate, item);
    },
    showModalQuyenDuAn(duAnId:number){
      (this.$refs.ModalThemSuaQuyenDuAn as any).show(duAnId);
    },

    getDanhSAchDuAn(filters: GetDuAnParams) {
      DuAnApi.getDuAn(filters)
        .then((res) => {
          this.danhSachDuAn = res.data;
          for(var i=0;i<this.danhSachDuAn.length;i++)
          {
            this.danhSachDuAn[i].linkQuanLiViec=`/nguoidung/quanlyduan/${this.danhSachDuAn[i].id}`;
          }
          this.totalItems = res.pagination.totalItems;
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Lấy danh sách nhóm việc thất bại!");
        });
    },
    formatDate(date: Date) {
      if (!date) {
        return "Không xác định";
      } 
      else 
      return this.$moment(date).format("DD/MM/YYYY");
    },
    deleteDuAn(): void {
      DuAnApi.deleteDuAn(this.duAnSelected.id)
        .then(res => {
          this.dialogConfirmDelete = false;
          this.getDanhSAchDuAn(this.filters);
        })
        .catch(res => {
          this.loading = false;
          this.$snotify.error("Xóa thất bại!");
        });
    },
    confirmDelete(duAn: any): void {
      this.dialogConfirmDelete = true;
      this.duAnSelected = duAn;
    },
    //modal them trang thai
    showModalThemSuaTrangThai(item:any){
      (this.$refs.ModalThemSuaTrangThai as any).show(item);
    },
    //modal them nhan su
    showModalThemNhanSu(item:any){
      (this.$refs.modalThemSuaNhanSu as any).show(item);
    },
    isOverdue(date:Date){
      return this.$moment(this.today).isAfter(date,'day');
    },
  },
});
</script>
