<template>
  <div class="px-3">
    <h2 class="pt-5">QUẢN LÝ DỰ ÁN</h2>
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
      <v-col cols="4" style="position:relative;">
      </v-col>
    </v-row>
    <v-data-table
      :items="danhSachDuAn"
      :headers="tableHeader"
      :options.sync="filters"
      :server-items-length="totalItems"
      class="elevation-0"
    >
    
      <template v-slot:item.thaotac="{ item }">
        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-btn :to="item.linkQuanLiViec" class="ma-0 mr-1" icon small v-on="on">
                 <v-icon size="17" color="blue darken-2">mdi-library-books</v-icon>
            </v-btn>
          </template>
          <span>Quản Lí Việc</span>
        </v-tooltip>
      </template>
      <template v-slot:item.soLuongThanhVien="{ item }">
        <span class="mt-4">{{item.soLuongThanhVien}}</span> 
      </template>

      <template v-slot:item.tinhTrangViec="{ item }">
        <span v-if="item.trangThaiDuAn.length==0">Chưa có trạng thái dự án</span>
        <span
            v-for="(item, indexTrangThai) in item.trangThaiDuAn"
            :key="indexTrangThai"
            class="pt-3 mr-3"
          >
             {{item.trangThai.tenTrangThai}}:{{item.soLuongCongViec}} 
          </span>
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
    </div>
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
import { HocVienDTO } from "../../models/HocVienDTO";
import UserApi from "../../apiResources/UserApi";

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
          width: "20px",
          sortable: false,
          align: "center",
        },
      ],
      filters: {} as GetDuAnParams,
      totalItems: 0 as number | undefined,
      danhSachDuAn: [] as DuAnDTO[],
      loading: false,
      duAnSelected:{} as DuAnDTO,
      hocVien:{} as HocVienDTO,
    };
  },
  created() {
    this.getHocVienByUser();
    
    
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
          console.log('get du an')
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Lấy danh sách dự án thất bại!");
        });
    },
    formatDate(date: Date) {
      if (!date) {
        return "Không xác định";
      } 
      else 
      return this.$moment(date).format("DD/MM/YYYY");
    },
    // deleteDuAn(): void {
    //   DuAnApi.deleteDuAn(this.duAnSelected.id)
    //     .then(res => {
    //       this.dialogConfirmDelete = false;
    //       this.getDanhSAchDuAn(this.filters);
    //     })
    //     .catch(res => {
    //       this.loading = false;
    //       this.$snotify.error("Xóa thất bại!");
    //     });
    // },
    // confirmDelete(duAn: any): void {
    //   this.dialogConfirmDelete = true;
    //   this.duAnSelected = duAn;
    // },
    // //modal them trang thai
    // showModalThemSuaTrangThai(item:any){
    //   (this.$refs.ModalThemSuaTrangThai as any).show(item);
    // },
    // //modal them nhan su
    // showModalThemNhanSu(item:any){
    //   (this.$refs.modalThemSuaNhanSu as any).show(item);
    // },
    getHocVienByUser() {
      UserApi.getHocVienByUser()
        .then((res) => {
          this.hocVien = res;
          console.log('get user');
          this.filters.hocVienId=this.hocVien.id;
          this.getDanhSAchDuAn(this.filters);
        })
        .catch((res) => {
          this.$snotify.error("Lấy thông tin học viên thất bại!");
        });
    },

  },
});
</script>
