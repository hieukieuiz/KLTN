<template>
  <v-layout row wrap class="mt-2 mb-8">
    <v-flex xs12>
      <v-card class="px-7" style="box-shadow: 0 1px 2px rgba(0, 0, 0, 0.2);">
        <v-card-text>
          <v-layout row wrap>
            <v-flex xs12>
              <p class="mb-4 q-header">QUẢN LÝ LOẠI CÔNG VIỆC</p>
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
                    @input="getDanhSachLoaiCongViec(filters)"
                  ></v-text-field>
                </template>
                <span>Ấn enter để tìm kiếm</span>
              </v-tooltip>
            </v-flex>
            <v-flex xs12 class="mb-2 d-flex justify-md-end">
              <v-btn
                outlined
                class="mt-2 mt-md-n10 blue white--text"
                @click="showModalThemSuaLoaiCongViec(false,{})"
              >Thêm mới</v-btn>
            </v-flex>
            <v-flex xs12>
              <v-data-table
                :items="danhSachLoaiCongViec"
                :headers="tableHeader"
                @update:options="getDanhSachLoaiCongViec"
                :options.sync="filters"
                :server-items-length="totalItems"
                class="elevation-0"
              >
                <template v-slot:item.thaoTac="{ item }">
                  <v-btn
                    color="primary"
                    icon
                    small
                    @click="showModalThemSuaLoaiCongViec(true, item)"
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
    <modal-them-sua-loai-cong-viec ref="modalThemSuaLoaiCongViec" @updated="getDanhSachLoaiCongViec(filters)"></modal-them-sua-loai-cong-viec>
    <v-dialog v-model="dialogConfirmDelete" max-width="290">
      <v-card>
        <v-card-title class="headline">Xác nhận xóa</v-card-title>
        <v-card-text class="pt-3">Bạn có chắc chắn muốn xóa?</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn @click.native="dialogConfirmDelete=false" text>Hủy</v-btn>
          <v-btn :loading="loading" color="red darken-1" text @click="deleteLoaiCongViec">Xác Nhận</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-layout>
</template>
<script lang="ts">
import { Vue } from "vue-property-decorator";
import ModalThemSuaLoaiCongViec from "./ModalThemSuaLoaiCongViec.vue";
import LoaiCongViecApi, { GetLoaiCongViecParams } from "../../apiResources/LoaiCongViecApi";
import { LoaiCongViecDTO } from "../../models/LoaiCongViecDTO";
export default Vue.extend({
  components: {
    ModalThemSuaLoaiCongViec
  },
  data() {
    return {
      dialogConfirmDelete: false,
      loaiCongViecSelected: {} as LoaiCongViecDTO,
      tableHeader: [
        {
          text: "Tên loại công việc",
          value: "tenLoaiCongViec",
          sortable: false,
          align: "center"
        },
        {
          text: "Thao Tác",
          value: "thaoTac",
          fixed: true,
          sortable: false,
          align:"center"
        },
      ],
      danhSachLoaiCongViec: [] as LoaiCongViecDTO[],
      loaiCongViec: {} as LoaiCongViecDTO,
      filters: { itemsPerPage: -1 } as GetLoaiCongViecParams,
      totalItems: 0 as number | undefined,
      loading: false
    };
  },
  computed: {},
  created() {
    
    this.getDanhSachLoaiCongViec(this.filters);
  },
  methods: {
    showModalThemSuaLoaiCongViec(isUpdate: boolean, item: any) {
      (this.$refs.modalThemSuaLoaiCongViec as any).show(isUpdate, item);
    },
    getDanhSachLoaiCongViec(filters: GetLoaiCongViecParams) {
      LoaiCongViecApi.getLoaiCongViec(filters)
        .then(res => {
          this.danhSachLoaiCongViec = res.data;
          this.totalItems = res.pagination.totalItems;
        })
        .catch(res => {
          this.$snotify.error("Lấy danh sách loại công việc thất bại!");
        });
    },
    confirmDelete(loaiCongViec: any): void {
      this.dialogConfirmDelete = true;
      this.loaiCongViecSelected = loaiCongViec;
    },
    deleteLoaiCongViec(): void {
      LoaiCongViecApi.deleteLoaiCongViec(this.loaiCongViecSelected.id)
        .then(res => {
          this.dialogConfirmDelete = false;
          this.getDanhSachLoaiCongViec(this.filters);
          this.$snotify.success("Xóa thành Công!");
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