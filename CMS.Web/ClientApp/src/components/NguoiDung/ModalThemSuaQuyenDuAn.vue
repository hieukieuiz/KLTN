<template>
  <v-dialog v-model="dialog" max-width="600" scrollable persistent>
    <v-card>
      <v-card-title class="title primary py-1 px-2 white--text">
        <h3>Cập nhật vai trò nhóm việc</h3>
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
                    :items="dSQuyen"
                    v-model="quyenDuAn.quyenId"
                    item-text="tenQuyen"
                    item-value="id"
                    :error-messages="errors.collect('Vai trò', 'frmAddEdit')"
                    v-validate="'required'"
                    data-vv-scope="frmAddEdit"
                    data-vv-name="Tên vai trò"
                    label="Lựa chọn vai trò:"
                  ></v-autocomplete>
                </v-col>
                <v-col cols="12" class="pa-0 ma-0">
                  <v-spacer></v-spacer>
                  <v-btn @click="save" color="blue" dark>
                    Thêm
                  </v-btn>
                </v-col>

                <v-col cols="12" class="pa-0 ma-0 mt-3">
                  <h3>Danh sách vai trò hiện tại:</h3>
                </v-col>
                <v-col cols="12">
                  <v-data-table
                    :items="dSQuyenDuAn"
                    :headers="headers"
                    :options.sync="filtersQuyenDuAn"
                    :server-items-length="totalItemsQDA"
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
            @click="deleteQuyenDuAn"
            >Xác Nhận</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-dialog>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import { QuyenDTO } from "../../models/QuyenDTO";
import QuyenApi, {GetQuyenParams} from "../../apiResources/QuyenApi";
import { QuyenDuAnDTO } from "../../models/QuyenDuAnDTO";
import QuyenDuAnApi, {GetQuyenDuAnParams} from "../../apiResources/QuyenDuAnApi";
import TrangThaiDuAnApi from '@/apiResources/TrangThaiDuAnApi';

export default Vue.extend({
  components: {},
  data() {
    return {
      dialog: false,
      loading: false,
      valid: false,
      dialogConfirmDelete: false,
      dSQuyen:[] as QuyenDTO[],
      dSQuyenDuAn:[] as QuyenDuAnDTO[],
      quyenDuAn:{} as QuyenDuAnDTO,
      quyenDuAnSelected:{} as QuyenDuAnDTO,
      trangThaiDuAnSelected:{} as QuyenDuAnDTO,
      totalItemsQDA:0 as number | undefined,
      filtersQuyenDuAn: { itemsPerPage: 25 } as GetQuyenDuAnParams,
      duAnId:0 as number,
      headers: [
        {
          text: "Tên vai trò",
          value: "quyen.tenQuyen",
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
    show(duAnId:number) {
      this.dialog = true;
      this.getQuyen();
      this.filtersQuyenDuAn.duAnId=duAnId;
      this.getQuyenDuAn(this.filtersQuyenDuAn);
      this.duAnId=duAnId;
      this.quyenDuAn={} as QuyenDuAnDTO;
    },

    hide() {
      this.dialog = false;
      this.$emit("updated");
    },
    getQuyen() {
      QuyenApi.getQuyen({ itemsPerPage: -1 })
        .then((response) => {
          this.dSQuyen = response.data;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu vai trò thất bại!");
        });
    },
    getQuyenDuAn(filters: GetQuyenDuAnParams) {
      QuyenDuAnApi.getQuyenDuAnByDuAnId(filters)
        .then((response) => {
          this.dSQuyenDuAn = response.data;
          this.totalItemsQDA = response.pagination.totalItems;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu vai trò nhóm việc thất bại!");
        });
    },
    confirmDelete(quyenDuAn: any): void {
      this.dialogConfirmDelete = true;
      this.quyenDuAnSelected=quyenDuAn;
    },
    deleteQuyenDuAn(): void {
      QuyenDuAnApi.deleteQuyenDuAn(this.quyenDuAnSelected.id)
        .then((res) => {
          this.dialogConfirmDelete = false;
          this.getQuyenDuAn(this.filtersQuyenDuAn);
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
          this.quyenDuAn.duAnId = this.duAnId;
          QuyenDuAnApi.createQuyenDuAn(this.quyenDuAn)
            .then((res) => {
              this.loading = false;
              this.$snotify.success("Thêm mới thành công!");
              this.quyenDuAn={} as QuyenDuAnDTO;
              this.getQuyenDuAn(this.filtersQuyenDuAn);
            })
            .catch((res) => {
              this.$snotify.error("Vai trò đã có!");
              this.loading = false;
            });
        }
      });
    },
  },
});
</script>