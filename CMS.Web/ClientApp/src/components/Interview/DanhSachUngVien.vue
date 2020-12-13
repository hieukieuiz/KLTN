<template>
  <v-layout row wrap class="mt-2 mb-8">
    <v-flex xs12>
      <v-card class="px-7" style="box-shadow: 0 1px 2px rgba(0, 0, 0, 0.2);">
        <v-card-text>
          <v-layout row wrap>
            <v-flex xs12>
              <p class="mb-4 q-header">DANH SÁCH ỨNG VIÊN</p>
            </v-flex>
            <v-flex xs12 md3 class="mb-2">
              <v-tooltip bottom>
                <template v-slot:activator="{ on }">
                  <v-text-field
                    v-on="on"
                    hide-details
                    label="Tìm kiếm"
                    append-icon="search"
                    v-model="filters.keywords"
                    @keyup.enter="getDanhSachUngVien(filters)"
                    clearable
                    @click:clear="getDanhSachUngVien"
                  ></v-text-field>
                </template>
                <span>Ấn enter để tìm kiếm</span>
              </v-tooltip>
            </v-flex>
            <v-flex xs12 md3 class="mb-2">
              <v-autocomplete
                :items="danhSachTinhThanh"
                item-text="tenTinhThanh"
                item-value="id"
                label="Tỉnh thành"
                v-model="filters.tinhThanhId"
                @input="getDanhSachUngVien(filters)"
                clearable
                hide-details
              ></v-autocomplete>
            </v-flex>
            <v-flex xs12 md3 class="mb-2">
              <v-autocomplete
                :items="danhSachTrangThai"
                item-text="tenTrangThai"
                item-value="id"
                label="Trạng thái"
                v-model="filters.trangThaiId"
                @input="getDanhSachUngVien(filters)"
                clearable
                hide-details
              ></v-autocomplete>
            </v-flex>
            <v-flex xs12 class="mb-2 d-flex justify-md-end">
              <v-btn
                outlined
                class="mt-2 mt-md-n10 blue white--text"
                @click="showModalThemSua(false, {})"
                >Thêm mới</v-btn
              >
            </v-flex>
            <v-flex xs12 v-for="ungVien in danhSachUngVien" :key="ungVien.id">
              <v-data-table
                :items="danhSachUngVien"
                :headers="tableHeader"
                @update:options="getDanhSachUngVien"
                :options.sync="filters"
                :server-items-length="totalItems"
                class="elevation-0"
              >
                <template v-slot:item.thaotac="{ item }">
                  <v-btn
                    color="primary"
                    icon
                    small
                    @click="showModalThemSua(true, item)"
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
                  <v-btn
                    color="primary"
                    icon
                    small
                    :to="'/ungvien/cvungvien/' + ungVien.id"
                    class="ma-0"
                  >
                    <v-icon size="15">mdi-account-card-details</v-icon>
                  </v-btn>
                </template>
              </v-data-table>
            </v-flex>
          </v-layout>
        </v-card-text>
      </v-card>
    </v-flex>
    <!-- <cv-ung-vien ref="modalCVUngVien"></cv-ung-vien> -->
    <modal-them-sua-danh-sach-ung-vien
      ref="modalThemSuaDanhSachUngVien"
      @updated="getDanhSachUngVien(filters)"
    ></modal-them-sua-danh-sach-ung-vien>
    <v-dialog v-model="dialogConfirmDelete" max-width="290">
      <v-card>
        <v-card-title class="headline">Xác nhận xóa</v-card-title>
        <v-card-text class="pt-3">Bạn có chắc chắn muốn xóa?</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn @click.native="dialogConfirmDelete = false" text>Hủy</v-btn>
          <v-btn
            :loading="loading"
            color="red darken-1"
            text
            @click="deleteUngVien"
            >Xác Nhận</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-layout>
</template>
<script lang="ts">
import { Vue } from "vue-property-decorator";
//import ModalThemSuaDanhSachUngVien from "./ModalQuanLyHocVien.vue";
import UngVienApi, {
  GetUngVienParams,
} from "../../apiResources/Interview/UngVienApi";
import { UngVienDTO } from "../../models/Interview/UngVienDTO";
import TinhThanhApi from "../../apiResources/TinhThanhApi";
import { TinhThanhDTO } from "../../models/TinhThanhDTO";
import ModalThemSuaDanhSachUngVien from "./ModalThemSuaDanhSachUngVien.vue";
import CVUngVien from "./CVUngVien.vue";
import TrangThaiApi, {
  GetTrangThaiParams,
} from "../../apiResources/TrangThaiApi";
import { TrangThaiDTO } from "../../models/TrangThaiDTO";
export default Vue.extend({
  components: {
    //ModalQuanLyHocVien,
    ModalThemSuaDanhSachUngVien,
  },
  data() {
    return {
      dialogConfirmDelete: false,
      ungVienSelected: {} as UngVienDTO,
      tableHeader: [
        {
          text: "Thao tác",
          value: "thaotac",
          fixed: true,
          width: "80px",
          sortable: false,
          align: "center",
        },
        {
          text: "Ứng viên",
          value: "hoTen",
          fixed: true,
          width: "180px",
          sortable: false,
        },
        {
          text: "Tài khoản",
          value: "account",
          fixed: true,
          width: "250px",
          sortable: false,
        },
        {
          text: "SĐT",
          value: "sdt",
          fixed: true,
          width: "120px",
          sortable: false,
        },
        {
          text: "Quê quán",
          value: "tinhThanh.tenTinhThanh",
          fixed: true,
          width: "100px",
          sortable: false,
          align: "center",
        },
        {
          text: "Trạng thái",
          value: "trangThai.tenTrangThai",
          fixed: true,
          width: "100px",
          sortable: false,
          align: "center",
        },
      ],
      danhSachUngVien: [] as UngVienDTO[],
      ungVien: {} as UngVienDTO,
      danhSachTrangThai: [] as TrangThaiDTO[],
      danhSachTinhThanh: [] as TinhThanhDTO[],
      filters: { itemsPerPage: -1 } as GetUngVienParams,
      totalItems: 0 as number | undefined,
      loading: false,
    };
  },
  computed: {},
  created() {
    this.getDanhSachUngVien(this.filters);
    this.getDanhSachTinhThanh();
    this.getDanhSachTrangThai();
  },
  methods: {
    formatDate(date: Date) {
      return this.$moment(date).format("DD/MM/YYYY");
    },
    showModalThemSua(isUpdate: boolean, item: any) {
      (this.$refs.modalThemSuaDanhSachUngVien as any).show(isUpdate, item);
    },
    getUngVien(ungVienId: number) {
      UngVienApi.getUngVienById(ungVienId)
        .then((res) => {
          this.ungVien = res;
          UngVienApi.updateUngVien(this.ungVien.id, this.ungVien)
            .then((res) => {})
            .catch((res) => {});
        })
        .catch((res) => {
          this.$snotify.error("Lấy thông tin học viên thất bại!");
        });
    },
    getDanhSachUngVien(filters: GetUngVienParams) {
      UngVienApi.getUngVien(filters)
        .then((res) => {
          this.danhSachUngVien = res.data;
          this.totalItems = res.pagination.totalItems;
        })
        .catch((res) => {
          this.$snotify.error("Lấy danh sách ứng viên thất bại!");
        });
    },
    getDanhSachTinhThanh() {
      TinhThanhApi.getTinhThanh({ itemsPerPage: -1 })
        .then((res) => {
          this.danhSachTinhThanh = res.data;
        })
        .catch((res) => {
          this.$snotify.error("Lấy danh sách tỉnh thành thất bại!");
        });
    },
    getDanhSachTrangThai() {
      TrangThaiApi.getTrangThai({ itemsPerPage: -1 })
        .then((res) => {
          this.danhSachTrangThai = res.data;
        })
        .catch((res) => {
          this.$snotify.error("Lấy danh sách trạng thái thất bại!");
        });
    },
    confirmDelete(ungVien: any): void {
      this.dialogConfirmDelete = true;
      this.ungVienSelected = ungVien;
    },
    deleteUngVien(): void {
      UngVienApi.deleteUngVien(this.ungVienSelected.id)
        .then((res) => {
          this.dialogConfirmDelete = false;
          this.getDanhSachUngVien(this.filters);
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Xóa thất bại!");
        });
    },
  },
});
</script>
<style>
.q-header {
  color: #050505;
  font-size: 20px;
}
</style>
