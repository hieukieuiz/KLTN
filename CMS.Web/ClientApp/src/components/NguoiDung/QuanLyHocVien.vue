<template>
  <v-layout row wrap class="mt-2 mb-8">
    <v-flex xs12>
      <v-card class="px-7" style="box-shadow: 0 1px 2px rgba(0, 0, 0, 0.2);">
        <v-card-text>
          <v-layout row wrap>
            <v-flex xs12>
              <p class="mb-4 q-header">QUẢN LÝ HỌC VIÊN</p>
            </v-flex>
            <v-flex xs12 md4 class="mb-2">
              <v-tooltip bottom>
                <template v-slot:activator="{ on }">
                  <v-text-field
                    v-on="on"
                    hide-details
                    label="Tìm kiếm"
                    append-icon="search"
                    v-model="filters.keywords"
                    @keyup.enter="getDanhSachHocVien(filters)"
                    clearable
                    @click:clear="getDanhSachHocVien"
                  ></v-text-field>
                </template>
                <span>Ấn enter để tìm kiếm</span>
              </v-tooltip>
            </v-flex>
            <v-flex xs12 md4 class="mb-2">
              <v-autocomplete
                :items="danhSachTinhThanh"
                item-text="tenTinhThanh"
                item-value="id"
                label="Tỉnh thành"
                v-model="filters.tinhThanhId"
                @input="getDanhSachHocVien(filters)"
                clearable
                hide-details
              ></v-autocomplete>
            </v-flex>
            <v-flex xs12 class="mb-2 d-flex justify-md-end">
              <v-btn
                outlined
                class="mt-2 mt-md-n10 blue white--text"
                @click="showModalThemSua(false,{})"
              >Thêm mới</v-btn>
            </v-flex>
            <v-flex xs12>
              <v-data-table
                :items="danhSachHocVien"
                :headers="tableHeader"
                @update:options="getDanhSachHocVien"
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
                  <v-btn color="red" icon small class="ma-0" @click="confirmDelete(item)">
                    <v-icon small>delete</v-icon>
                  </v-btn>
                </template>
              </v-data-table>
            </v-flex>
          </v-layout>
        </v-card-text>
      </v-card>
    </v-flex>
    <modal-quan-ly-hoc-vien ref="modalQuanLyHocVien" @updated="getDanhSachHocVien(filters)"></modal-quan-ly-hoc-vien>
    <v-dialog v-model="dialogConfirmDelete" max-width="290">
      <v-card>
        <v-card-title class="headline">Xác nhận xóa</v-card-title>
        <v-card-text class="pt-3">Bạn có chắc chắn muốn xóa?</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn @click.native="dialogConfirmDelete=false" text>Hủy</v-btn>
          <v-btn :loading="loading" color="red darken-1" text @click="deleteHocVien">Xác Nhận</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-layout>
</template>
<script lang="ts">
import { Vue } from "vue-property-decorator";
import ModalQuanLyHocVien from "./ModalQuanLyHocVien.vue";
import HocVienApi, { GetHocVienParams } from "../../apiResources/HocVienApi";
import { HocVienDTO } from "../../models/HocVienDTO";
import TinhThanhApi from "../../apiResources/TinhThanhApi";
import { TinhThanhDTO } from "../../models/TinhThanhDTO";
export default Vue.extend({
  components: {
    ModalQuanLyHocVien
  },
  data() {
    return {
      dialogConfirmDelete: false,
      hocVienSelected: {} as HocVienDTO,
      tableHeader: [
        {
          text: "Thao tác",
          value: "thaotac",
          fixed: true,
          width: "80px",
          sortable: false,
          align: "center"
        },
        {
          text: "Học viên",
          value: "hoTen",
          fixed: true,
          width: "180px",
          sortable: false
        },
        {
          text: "Tài khoản",
          value: "account",
          fixed: true,
          width: "250px",
          sortable: false
        },
        {
          text: "SĐT",
          value: "sdt",
          fixed: true,
          width: "120px",
          sortable: false
        },
        {
          text: "Quê quán",
          value: "tinhThanh.tenTinhThanh",
          fixed: true,
          width: "100px",
          sortable: false,
          align: "center"
        }
      ],
      danhSachHocVien: [] as HocVienDTO[],
      danhSachTinhThanh: [] as TinhThanhDTO[],
      filters: { itemsPerPage: -1 } as GetHocVienParams,
      totalItems: 0 as number | undefined,
      loading: false
    };
  },
  computed: {},
  created() {
    this.getDanhSachHocVien(this.filters);
    this.getDanhSachTinhThanh();
  },
  methods: {
    formatDate(date: Date) {
      return this.$moment(date).format("DD/MM/YYYY");
    },
    showModalThemSua(isUpdate: boolean, item: any) {
      (this.$refs.modalQuanLyHocVien as any).show(isUpdate, item);
    },
    getDanhSachHocVien(filters: GetHocVienParams) {
      HocVienApi.getHocVien(filters)
        .then(res => {
          this.danhSachHocVien = res.data;
          this.totalItems = res.pagination.totalItems;
        })
        .catch(res => {
          this.$snotify.error("Lấy danh sách học viên thất bại!");
        });
    },
    getDanhSachTinhThanh() {
      TinhThanhApi.getTinhThanh({ itemsPerPage: -1 })
        .then(res => {
          this.danhSachTinhThanh = res.data;
        })
        .catch(res => {
          this.$snotify.error("Lấy danh sách tỉnh thành thất bại!");
        });
    },
    confirmDelete(hocVien: any): void {
      this.dialogConfirmDelete = true;
      this.hocVienSelected = hocVien;
    },
    deleteHocVien(): void {
      HocVienApi.deleteHocVien(this.hocVienSelected.id)
        .then(res => {
          this.dialogConfirmDelete = false;
          this.getDanhSachHocVien(this.filters);
        })
        .catch(res => {
          this.loading = false;
          this.$snotify.error("Xóa thất bại!");
        });
    }
  }
});
</script>
<style>
.q-header {
  color: #050505;
  font-size: 20px;
}
</style>