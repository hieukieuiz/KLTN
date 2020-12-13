<template>
  <v-dialog v-model="dialog" max-width="600" scrollable persistent>
    <v-card>
      <v-card-title class="title primary py-1 px-2 white--text">
        <h3>{{ "Cập nhật trạng thái dự án " }}</h3>
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
                <v-col cols="12" md="12" class="pa-0 ma-0">
                  <v-autocomplete
                    :items="dSTrangThai"
                    v-model="trangThaiDuAn.trangThaiId"
                    item-text="tenTrangThai"
                    item-value="id"
                    :error-messages="errors.collect('Trạng thái', 'frmAddEdit')"
                    v-validate="'required'"
                    data-vv-scope="frmAddEdit"
                    data-vv-name="Tên trạng thái"
                    label="Lựa chọn trạng thái:"
                  ></v-autocomplete>
                </v-col>
                <v-col cols="12" class="pa-0 ma-0">
                  <v-spacer></v-spacer>
                  <v-btn @click="save" color="blue" dark>
                    Thêm
                  </v-btn>
                </v-col>

                <v-col cols="12" class="pa-0 ma-0 mt-3">
                  <h3>Trạng Thái Hiện Tại:</h3>
                </v-col>
                <v-col cols="12">
                  <v-data-table
                    :items="dSTrangThaiDuAn"
                    :headers="headers"
                    :options.sync="filters"
                    :server-items-length="totalItems"
                    class="elevation-0"
                  >
                    <template v-slot:item.thaoTac="{ item }">
                      <v-tooltip top>
                        <template v-slot:activator="{ on }">
                          <v-btn
                            v-on="on"
                            @click="confirmDelete(item)"
                            color="red"
                            icon
                            small
                            class="mx-3 ma-0"
                          >
                            <v-icon size="20">delete</v-icon>
                          </v-btn>
                        </template>
                        <span>Xóa</span>
                      </v-tooltip>
                    </template>
                  </v-data-table>
                </v-col>
              </v-row>
            </v-form>
          </v-card-text>
        </v-layout>
      </v-card-text>
    </v-card>
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
            @click="deleteTrangThaiDuAn"
            >Xác Nhận</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>
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
      totalItems: 0 as number | undefined,
      duAn: {} as DuAnDTO,
      valid: false,
      dialogConfirmDelete: false,
      trangThaiDuAnSelected: {} as TrangThaiDuAnDTO,
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
    show(item: any) {
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
          this.totalItems = response.pagination.totalItems;
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
              this.trangThaiDuAn = {} as TrangThaiDuAnDTO;
              this.$emit("updated");
            })
            .catch((res) => {
              this.$snotify.error("Trạng thái đã có!");
              this.loading = false;
            });
        }
      });
    },
  },
});
</script>