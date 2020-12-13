<template>
  <v-container class="pa-0">
    <v-card class="mt-3">
      <v-row class="px-4 pt-3">
        <v-col cols="12">
          <p class="mb-0 q-header">QUẢN LÝ NHÓM KỸ NĂNG</p>
        </v-col>
        <v-col cols="12" md="6">
          <v-text-field
            hide-details
            label="Tìm kiếm"
            append-icon="search"
            clearable
            v-model="searchParamsNhomKyNang.keywords"
            @input="getNhomKyNang(searchParamsNhomKyNang)"
          ></v-text-field>
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

        <v-col cols="12">
          <v-data-table
            :loading="loading"
            class="mt-0"
            :headers="headers"
            :items="dsNhomKyNang"
            @update:options="getNhomKyNang"
            :options.sync="searchParamsNhomKyNang"
            :server-items-length="searchParamsNhomKyNang.totalItems"
          >
            <v-progress-linear
              height="2"
              slot="progress"
              color="blue"
              indeterminate
            ></v-progress-linear>
            <template v-slot:item.thaotac="{ item }">
              <v-btn
                icon
                small
                class="ma-0"
                @click="showModalThemSua(true, item)"
                @created="getNhomKyNang(searchParamsNhomKyNang)"
                @updated="getNhomKyNang(searchParamsNhomKyNang)"
              >
                <v-icon small>edit</v-icon>
              </v-btn>
              <v-btn
                text
                color="red"
                icon
                small
                class="ma-0"
                @click="confirmDelete(item)"
              >
                <v-icon small style="color: red">delete</v-icon>
              </v-btn>
            </template>
          </v-data-table>
        </v-col>
      </v-row>
    </v-card>
    <modal-them-sua-nhom-ky-nang
      ref="modalAddEditNkn"
      @getLaiDs="getNhomKyNang"
    ></modal-them-sua-nhom-ky-nang>
    <!-- <modal-add-edit-dts ref="modalAddEditDts" @getLaiDs="getDotTuyenSinh"></modal-add-edit-dts> -->
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
import ModalThemSuaNhomKyNang from "./ModalThemSuaNhomKyNang.vue";
import NhomKyNangApi, {
  GetNhomKyNangParams,
} from "@/apiResources/Interview/NhomKyNangApi";
import { NhomKyNangDTO } from "@/models/Interview/NhomKyNangDTO";
export default Vue.extend({
  components: {
    //ModalAddEditDts
    ModalThemSuaNhomKyNang,
  },
  data() {
    return {
      data: {},
      dialogConfirmDelete: false,
      loading: false,
      deleting: false,
      selected: {} as any,
      dsNhomKyNang: [] as NhomKyNangDTO[],
      isUpdate: false,
      headers: [
        {
          text: "Thao Tác",
          value: "thaotac",
          align: "center",
          sortable: false,
        },
        {
          text: "Tên nhóm kỹ năng",
          align: "center",
          sortable: false,
          value: "tenNhomKyNang",
        },
      ],
      searchParamsNhomKyNang: {
        itemsPerPage: 10,
      } as GetNhomKyNangParams,
      totalItems: 0 as number | undefined,
    };
  },
  mounted() {
    this.getNhomKyNang(this.searchParamsNhomKyNang);
  },

  methods: {
    confirmDelete(item: any): void {
      this.selected = item;
      this.dialogConfirmDelete = true;
    },
    getNhomKyNang(searchParamsNhomKyNang: GetNhomKyNangParams): void {
      this.loading = true;
      NhomKyNangApi.getNhomKyNang(searchParamsNhomKyNang)
        .then((res) => {
          this.dsNhomKyNang = res.data;
          this.totalItems = res.pagination.totalItems;
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
      NhomKyNangApi.deleteNhomKyNang(this.selected.id)
        .then((res) => {
          this.$snotify.success("Xóa nhóm kỹ năng thành công");
          this.getNhomKyNang(this.searchParamsNhomKyNang);
        })
        .catch((res) => {
          this.$snotify.error("Xóa nhóm kỹ năng thất bại");
        });
      this.dialogConfirmDelete = false;
      this.deleting = false;
    },
    showModalThemSua(isUpdate: boolean, item: any) {
      (this.$refs.modalAddEditNkn as any).show(isUpdate, item);
    },
  },
});
</script>
