<template>
  <v-card width="1005%" style="padding: 20px">
    <v-layout row wrap>
      <v-row class="mt-5">
        <v-col
          cols="12"
          xs="12"
          md="6"
          style="padding-top: 0px; padding-bottom: 0px;"
        >
          <v-text-field
            hide-details
            label="Tìm kiếm"
            placeholder="Tìm kiếm theo tên doanh nghiệp"
            append-icon="search"
            v-model="searchParamsDoanhNghiep.keywords"
            @input="getDoanhNghiep(searchParamsDoanhNghiep)"
          ></v-text-field>
        </v-col>
        <v-spacer></v-spacer>

        <v-col cols="12" xs=" 12" md="2" style="padding-bottom: 0px;">
          <v-btn
            color="primary"
            style="float: right"
            @click="showModalThemSua(false, 0)"
          >
            Thêm mới</v-btn
          >
        </v-col>

        <v-col cols="12" xs="12" md="12">
          <v-data-table
            :loading="loading"
            class="table-border mt-0"
            :headers="headersDoanhNghiep"
            :items="doanhNghiep"
            @update:options="getDoanhNghiep"
            :options.sync="searchParamsDoanhNghiep"
            :server-items-length="searchParamsDoanhNghiep.totalItems"
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
                @click="showModalThemSua(true, item.id)"
                @created="getDoanhNghiep(searchParamsDoanhNghiep)"
                @updated="getDoanhNghiep(searchParamsDoanhNghiep)"
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
      <modal-them-sua-doanh-nghiep
        ref="modalThemSuaDoanhNghiep"
        @getLaiDs="getDoanhNghiep(searchParamsDoanhNghiep)"
      ></modal-them-sua-doanh-nghiep>
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
    </v-layout>
  </v-card>
</template>
<script lang="ts">
import { Vue } from "vue-property-decorator";
import ModalThemSuaDoanhNghiep from "./ModalThemSuaDoanhNghiep.vue";
import DoanhNghiepApi, {
  GetDoanhNghiepParams,
} from "@/apiResources/Interview/DoanhNghiepApi";
//import { DoanhNghiepDTO } from "../../models/Interview/DoanhNghiepDTO";
import { DoanhNghiepDTO } from "@/models/Interview/DoanhNghiepDTO";
export default Vue.extend({
  components: {
    ModalThemSuaDoanhNghiep,
  },
  data() {
    return {
      data: {},
      dialogConfirmDelete: false,
      loading: false,
      deleting: false,
      selected: {} as any,
      doanhNghiep: [] as DoanhNghiepDTO[],
      isUpdate: false,
      headersDoanhNghiep: [
        { text: "Thao Tác", value: "thaotac", align: "center" },
        {
          text: "Tên doanh nghiep",
          align: "center",
          sortable: false,
          value: "tenDoanhNghiep",
        },
      ],
      searchParamsDoanhNghiep: {
        itemsPerPage: 10,
      } as GetDoanhNghiepParams,
      totalItems: 0 as number | undefined,
    };
  },
  mounted() {
    this.getDoanhNghiep(this.searchParamsDoanhNghiep);
  },

  methods: {
    confirmDelete(item: any): void {
      this.selected = item;
      this.dialogConfirmDelete = true;
    },
    getDoanhNghiep(searchParamsDoanhNghiep: GetDoanhNghiepParams): void {
      this.loading = true;
      DoanhNghiepApi.getDoanhNghiep(searchParamsDoanhNghiep)
        .then((res) => {
          this.doanhNghiep = res.data;
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
      DoanhNghiepApi.deleteDoanhNghiep(this.selected.id)
        .then((res) => {
          this.$snotify.success("Xóa doanh nghiệp thành công");
          this.getDoanhNghiep(this.searchParamsDoanhNghiep);
        })
        .catch((res) => {
          this.$snotify.error("Xóa doanh nghiệp thất bại");
        });
      this.dialogConfirmDelete = false;
      this.deleting = false;
    },
    showModalThemSua(isUpdate: boolean, id: number) {
      (this.$refs.modalThemSuaDoanhNghiep as any).show(isUpdate, id);
    },
  },
});
</script>
