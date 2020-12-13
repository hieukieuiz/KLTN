<template>
  <v-dialog v-model="dialog" max-width="600"  scrollable persistent>
    <v-card style="height=800px">
      <v-card-title class="title primary py-1 px-2 white--text">
        <h3>{{ isUpdate? 'cập nhật công việc':'thêm lịch sử chi tiết công việc' }}</h3>
        <v-spacer></v-spacer>
        <v-btn
          class="white--text ma-0"
          small
          @click.native="dialog = false"
          icon
          dark
        >
          <v-icon>close</v-icon>
        </v-btn>
      </v-card-title>
      <v-card-text>
        <v-layout row wrap>
          <v-card-text class="px-6">
            <v-form v-model="valid" scope="frmAddEdit">
              <v-row>              
                <v-col cols="12">
                 <h3>hôm nay  đã cập nhật trạng thái cho dự án</h3>
                </v-col>

                <v-col cols="12">
                  <h4>Trạng Thái Hiện Tại</h4>
                </v-col>
                <v-col cols="12">
                  <v-data-table
                    :items="dSTrangThaiDuAn"
                    :headers="headers"
                    :options.sync="filters"
                    :server-items-length="totalItemsTTDA"
                    class="elevation-0"
                  >
                   
                  </v-data-table>
                </v-col>
              </v-row>
            </v-form>
          </v-card-text>
        </v-layout>
      </v-card-text>
    </v-card>
  
  </v-dialog>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import { TrangThaiDuAnDTO } from "../../models/TrangThaiDuAnDTO";
import { TrangThaiDTO } from "../../models/TrangThaiDTO";
import TrangThaiDuAnApi, {
  GetTrangThaiDuAnParams,
} from "../../apiResources/TrangThaiDuAnApi";
import TrangThaiApi from "../../apiResources/TrangThaiApi";
import { DuAnDTO } from "@/models/DuAnDTO";
export default Vue.extend({
  components: {},
  data() {
    return {
      dialog: false,
      loading: false,
      trangThaiDuAn: {} as TrangThaiDuAnDTO,
      dSTrangThai: [] as TrangThaiDTO[],
      dSTrangThaiDuAn: [] as TrangThaiDuAnDTO[],
      filters: { itemsPerPage: 25 } as GetTrangThaiDuAnParams,
      totalItemsTTDA: 0 as number | undefined,
      duAn: {} as DuAnDTO,
      valid: false,
      dialogConfirmDelete: false,
      trangThaiDuAnSelected: {} as TrangThaiDuAnDTO,
      isUpdate:false,
      headers: [
        {
          text: "Tên trạng thái",
          value: "trangThai.tenTrangThai",
          fixed: true,
          width: "150px",
          sortable: false,
          align: "center",
        },
        {
          text: "Thao tác",
          value: "thaoTac",
          fixed: true,
          width: "10px",
          sortable: false,
          align: "center",
        },
      ],
    };
  },
  methods: {
    show(isUpdate:boolean, item: any) {
      this.dialog = true;
      this.getTrangThai();
      this.duAn = item;
      this.filters.duAnId = item.id;
      this.getTrangThaiDuAn(this.filters);
      this.trangThaiDuAn = {} as TrangThaiDuAnDTO;
    },

    hide() {
      this.dialog = false;
      this.$emit("updated");
    },
    getTrangThai() {
      TrangThaiApi.getTrangThai({ itemsPerPage: -1 })
        .then((response) => {
          this.dSTrangThai = response.data;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu trạng thái thất bại!");
        });
    },
    getTrangThaiDuAn(filters: GetTrangThaiDuAnParams) {
      TrangThaiDuAnApi.getTrangThaiDuAnByDuAnId(filters)
        .then((response) => {
          this.dSTrangThaiDuAn = response.data;
          this.totalItemsTTDA = response.pagination.totalItems;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu trạng thái thất bại!");
        });
    },
    confirmDelete(trangThaiDuAn: any): void {
      this.dialogConfirmDelete = true;
      this.trangThaiDuAnSelected = trangThaiDuAn;
    },
    deleteTrangThaiDuAn(): void {
      TrangThaiDuAnApi.deleteTrangThaiDuAn(this.trangThaiDuAnSelected.id)
        .then((res) => {
          this.dialogConfirmDelete = false;
          this.getTrangThaiDuAn(this.filters);
          this.$emit("updated");
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Xóa thất bại!");
        });
    },
    save() {
      this.$validator.validateAll("frmAddEdit").then((res) => {
        if (res) {
          this.loading = true;
          this.trangThaiDuAn.duAnID = this.duAn.id;
          TrangThaiDuAnApi.createTrangThaiDuAn(this.trangThaiDuAn)
            .then((res) => {
              this.loading = false;
              this.$snotify.success("Thêm mới thành công!");
              this.getTrangThaiDuAn(this.filters);
              this.$emit("updated");
            })
            .catch((res) => {
              this.$snotify.error("Thêm thất bại!");
              this.loading = false;
            });
        }
      });
    },
  },
});
</script>
