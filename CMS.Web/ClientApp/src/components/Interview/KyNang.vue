<template>
  <v-container style="background-color:#fff">
    <v-row>
      <v-col cols="12">
        <h3>QUẢN LÝ KỸ NĂNG</h3>
      </v-col>
      <v-col cols="12" xs="12" md="6">
        <v-text-field
          hide-details
          label="Tìm kiếm"
          append-icon="search"
          placeholder="Tìm kiếm theo tiêu đề"
          v-model="searchParamsKyNang.keyword"
          @input="getKyNang(searchParamsKyNang)"
        ></v-text-field>
      </v-col>
      <v-col cols="12" xs=" 12" md="3" class="pl-md-0">
        <v-autocomplete
          v-model="searchParamsKyNang.nhomKyNangId"
          hide-details
          :items="dsNhomKyNang"
          item-value="nhomKyNangId"
          item-text="tenNhomKyNang"
          label="Nhóm Kỹ Năng"
          placeholder="Chọn nhóm kỹ năng"
          @change="getKyNang(searchParamsKyNang)"
          persistent-hint
          clearable
        ></v-autocomplete>
      </v-col>
      <v-spacer></v-spacer>
      <v-col cols="12" md="2" class="d-flex align-end justify-end pb-2">
        <v-btn
          outlined
          class="white--text blue"
          @click="showModalThemSua(false, {})"
          >Tạo mới</v-btn
        >
      </v-col>
      <!-- <v-col cols="3" class="d-flex align-end">
        <v-btn color="#216fda" dark @click="showModalThemSua(false,0)">Thêm mới</v-btn>
      </v-col>-->
      <v-col cols="12" xs="12" md="12">
        <v-data-table
          :loading="loading"
          :items="kyNang"
          @update:options="getKyNang"
          :options.sync="searchParamsKyNang"
          :server-items-length="searchParamsKyNang.totalItems"
          :headers="tableHeader"
          :items-per-page="10"
          class="elevation-0"
        >
          <template v-slot:item.thaotac="{ item }">
            <v-btn
              color="primary"
              icon
              small
              @click="showModalThemSua(true, item)"
              @created="getKyNang(searchParamsKyNang)"
              @updated="getKyNang(searchParamsKyNang)"
              class="ma-0"
            >
              <v-icon small>edit</v-icon>
            </v-btn>
            <v-btn
              color="red"
              icon
              small
              class="ma-0"
              @click="confirmDelete(item)"
            >
              <v-icon small>delete</v-icon>
            </v-btn>
          </template>
        </v-data-table>
      </v-col>
    </v-row>
    <modal-them-sua-ky-nang
      ref="modalAddEditKyNang"
      @getLaiDs="getKyNang"
    ></modal-them-sua-ky-nang>
    <!-- <modal-tao-bai-viet ref="modalTaoBaiViet" @update="getAllThongTin(searchParamsKyNang)"></modal-tao-bai-viet> -->
    <v-dialog v-model="dialogConfirmDelete" max-width="290">
      <v-card>
        <v-card-title class="headline">Xác nhận xóa</v-card-title>
        <v-card-text class="pt-3">Bạn có chắc chắn muốn xóa?</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            :disabled="deleting"
            @click.native="dialogConfirmDelete = false"
            text
            >Hủy</v-btn
          >
          <v-btn
            :disabled="deleting"
            :loading="deleting"
            color="red darken-1"
            @click="deleteItem"
            text
            >Xác Nhận</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>
<script lang="ts">
import { Vue } from "vue-property-decorator";
import ModalThemSuaKyNang from "./ModalThemSuaKyNang.vue";
//import ModalTaoBaiViet from "../News/ModalTaoBaiViet.vue";
import KyNangApi, { GetKyNangParams } from "@/apiResources/Interview/KyNangApi";
import NhomKyNangApi, {
  GetNhomKyNangParams,
} from "@/apiResources/Interview/NhomKyNangApi";
import { KyNangDTO } from "@/models/Interview/KyNangDTO";
import { NhomKyNangDTO } from "@/models/Interview/NhomKyNangDTO";
export default Vue.extend({
  components: {
    ModalThemSuaKyNang,
    // ModalThongTin,
    // ModalTaoBaiViet
  },
  data() {
    return {
      dialogConfirmDelete: false,
      kyNang: [] as KyNangDTO[],
      dsNhomKyNang: [] as NhomKyNangDTO[],
      loading: false,
      deleting: false,
      selected: {} as any,
      isUpdate: false,
      searchParamsKyNang: { itemsPerPage: 10 } as GetKyNangParams,
      tableHeader: [
        {
          text: "Kỹ năng",
          value: "tenKyNang",
          align: "center",
          sortable: true,
        },
        // {
        //   text: "Tiêu đề",
        //   value: "tieuDe",
        //   align: "left",
        //   sortable: true,
        //   width: "400px"
        // },
        // {
        //   text: "Ngày đăng",
        //   value: "ngayDang",
        //   align: "center",
        //   sortable: true
        // },
        // {
        //   text: "Người đăng",
        //   value: "nguoiDang",
        //   align: "center",
        //   sortable: true
        // },
        // {
        //   text: "Trạng thái",
        //   value: "trangThai",
        //   align: "center",
        //   sortable: true
        // },
        { text: "Thao tác", value: "thaotac", align: "center", sortable: true },
      ],
    };
  },
  mounted() {
    this.getKyNang(this.searchParamsKyNang);
    this.getDSNhomKyNang();
  },
  methods: {
    showModalThemSua(isUpdate: boolean, item: any) {
      (this.$refs.modalAddEditKyNang as any).show(isUpdate, item);
    },
    confirmDelete(item: any): void {
      this.selected = item;
      this.dialogConfirmDelete = true;
    },

    getKyNang(searchParamsKyNang: GetKyNangParams): void {
      this.loading = true;
      KyNangApi.getKyNang(searchParamsKyNang)
        .then((res) => {
          this.kyNang = res.data;
          this.loading = false;
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Get data failed!");
        });
    },

    deleteItem(): void {
      this.deleting = true;
      // call api delete
      KyNangApi.deleteKyNang(this.selected.id)
        .then((res) => {
          this.$snotify.success("Xóa kỹ năng thành công!");
          this.getKyNang(this.searchParamsKyNang);
        })
        .catch((res) => {
          this.$snotify.error("Xóa kỹ năng thất bại!");
        });
      this.dialogConfirmDelete = false;
      this.deleting = false;
    },

    getDSNhomKyNang() {
      var searchParamsNhomKyNang = { itemsPerPage: 0 } as GetNhomKyNangParams;
      NhomKyNangApi.getNhomKyNang(searchParamsNhomKyNang).then((res) => {
        this.dsNhomKyNang = res.data;
      });
    },
    // updateThongTin(item: any) {
    //   item.trangThai = !item.trangThai;
    //   ThongTinApi.updateThongTin(item.id, item)
    //     .then(res => {
    //       this.loading = false;
    //       this.getAllThongTin(this.searchParamsKyNang);
    //       this.isUpdate = true;
    //     })
    //     .catch(res => {
    //       this.loading = false;
    //       this.$snotify.error("Cập nhật thông tin thất bại!");
    //     });
    // }
  },
});
</script>
