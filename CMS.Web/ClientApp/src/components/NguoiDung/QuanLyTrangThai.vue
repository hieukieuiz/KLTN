<template>
  <div class="px-3">
    <h3 class="contaier mt-4"  >QUẢN LÝ TRẠNG THÁI</h3>
    <v-row>
      <v-col cols="8">
      <v-flex xs12 md4>
        <v-tooltip bottom>
          <template v-slot:activator="{ on }">
            <v-text-field
              v-on="on"
              hide-details
              label="Tìm kiếm"
              append-icon="search"
              v-model="filters.keywords"
              @input="getDanhSachTrangThai(filters)"
            ></v-text-field>
          </template>
          <span>Ấn enter để tìm kiếm</span>
        </v-tooltip>
      </v-flex>
      </v-col>
      <!-- <v-col cols="2"></v-col> -->
      <v-col cols="4" class="d-flex flex-row-reverse align-end">
        <v-btn
          color="primary"
          @click="showModalThemSuaTrangThai(false, {})"
        >Thêm mới</v-btn>
      </v-col>
    </v-row>
    <v-data-table
      :items="danhSachTrangThai"
      :headers="tableHeader"
      @update:options="getDanhSachTrangThai(filters)"
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
              @click="showModalThemSuaTrangThai(true, item)"
              class="ma-0"
            >
              <v-icon size="20">edit</v-icon>
            </v-btn>
          </template>
          <span>Sửa</span>
        </v-tooltip>

        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-btn v-on="on" @click="confirmDelete(item)" color="red" icon small class="mx-3 ma-0">
              <v-icon size="20">delete</v-icon>
            </v-btn>
          </template>
          <span>Xóa</span>
        </v-tooltip>
      </template>
    </v-data-table>
    <div>
      <modal-them-sua-trang-thai
        ref="modalThemSuaTrangThai"
        @updated="getDanhSachTrangThai(filters)"
      ></modal-them-sua-trang-thai>
    </div>
    <v-dialog v-model="dialogConfirmDelete" max-width="290">
      <v-card>
        <v-card-title class="headline">Xác nhận xóa</v-card-title>
        <v-card-text class="pt-3">xoá trạng thái và các công việc chứa trạng thái này?</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn @click.native="dialogConfirmDelete=false" text>Hủy</v-btn>
          <v-btn :loading="loading" color="red darken-1" text @click="deleteTrangThai">Xác Nhận</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import { TrangThaiDTO } from "@/models/TrangThaiDTO";
import TrangThaiApi, {
  GetTrangThaiParams,
} from "../../apiResources/TrangThaiApi";
import ModalThemSuaTrangThai from "./ModalThemSuaTrangThai.vue";
export default Vue.extend({
  components: {
    ModalThemSuaTrangThai,
  },
  data() {
    return {
      dialogConfirmDelete: false,
      tableHeader: [
        {
          text: "Tên Trạng Thái",
          value: "tenTrangThai",
          fixed: true,
          width: "150px",
          sortable: false,
          align: "center",
        },

        {
          text: "Thao tác",
          value: "thaotac",
          fixed: true,
          width: "120px",
          sortable: false,
          align: "center",
        },
      ],
      filters: {} as GetTrangThaiParams,
      totalItems: 0 as number | undefined,
      danhSachTrangThai: [] as TrangThaiDTO[],
      loading: false,
      trangThai: {} as TrangThaiDTO,
    };
  },
  created() {
    this.getDanhSachTrangThai(this.filters);
  },
  methods: {
    showModalThemSuaTrangThai(isUpdate: boolean, item: any) {
      (this.$refs.modalThemSuaTrangThai as any).show(isUpdate, item);
    },
    showModalThemSuaLSCTCongViec(isUpdate: boolean, item: any) {
      (this.$refs.modalThemSuaLichSuChiTietCongViec as any).show(isUpdate, item);
    },

    getDanhSachTrangThai(filters: GetTrangThaiParams) {
      TrangThaiApi.getTrangThai(filters)
        .then((res) => {
          this.danhSachTrangThai = res.data;
          this.totalItems = res.pagination.totalItems;
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Lấy danh sách dự án thất bại!");
        });
    },

    confirmDelete(trangThai: any): void {
      this.dialogConfirmDelete = true;
      this.trangThai = trangThai;
    },
    deleteTrangThai(): void {
      TrangThaiApi.deleteTrangThai(this.trangThai.id)
        .then((res) => {
          this.dialogConfirmDelete = false;
          this.getDanhSachTrangThai(this.filters);
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Xóa thất bại!");
        });
    },
  },
});
</script>
