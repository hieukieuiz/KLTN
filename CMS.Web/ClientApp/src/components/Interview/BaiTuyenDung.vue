<template>
  <div>
    <v-row>
      <v-col cols="12" class="pa-sm-6 pt-0 pt-sm-3">
        <div class="mb-2">
          <v-breadcrumbs class="px-3 py-0 item-bread" :items="breadcrumbs">
            <template v-slot:divider>
              <v-icon>mdi-chevron-right</v-icon>
            </template>
            <template v-slot:item="{ item }">
              <v-breadcrumbs-item :href="item.href" :disabled="item.disabled">{{
                item.text
              }}</v-breadcrumbs-item>
            </template>
          </v-breadcrumbs>
        </div>

        <v-layout row wrap>
          <v-flex xs12>
            <p class="mb-4 q-header">DANH SÁCH BÀI TUYỂN DỤNG</p>
          </v-flex>
          <v-flex xs12 md4 class="mb-2">
            <v-tooltip bottom>
              <template v-slot:activator="{ on }">
                <v-text-field
                  v-on="on"
                  hide-details
                  label="Tìm kiếm"
                  placeholder="Tìm kiếm theo bài tuyển dụng"
                  append-icon="search"
                  v-model="searchParamsBaiTuyenDung.keywords"
                  @input="getBaiTuyenDung(searchParamsBaiTuyenDung)"
                ></v-text-field>
              </template>
              <span>Ấn enter để tìm kiếm</span>
            </v-tooltip>
          </v-flex>
          <v-flex xs12 md4 class="mb-2">
            <v-autocomplete
              v-model="searchParamsBaiTuyenDung.doanhNghiepId"
              placeholder="Chọn doanh nghiệp"
              label="Doanh Nghiệp"
              persistent-hint
              hide-details
              @change="getBaiTuyenDung(searchParamsBaiTuyenDung)"
              :items="dsDoanhNghiep"
              style="margin-top: 15px!important"
              item-text="tenDoanhNghiep"
              item-value="doanhNghiepId"
              class="mb-2"
              clearable
            ></v-autocomplete>
          </v-flex>
          <!-- <v-flex xs12 md3 class="mb-2">
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
            </v-flex> -->
          <v-flex xs12 class="mb-2 d-flex justify-md-end">
            <v-btn
              outlined
              class="mt-2 mt-md-n10 blue white--text"
              @click="showModalThemSua(false, {})"
              >Thêm mới</v-btn
            >
          </v-flex>
          <!-- <v-flex xs12 v-for="ungVien in danhSachUngVien" :key="ungVien.id">
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
                  v-on="on"
                  color="primary"
                  icon
                  small
                  :to="'/ungvien/cvungvien/'"
                  class="ma-0"
                >
                  <v-icon size="15">mdi-account-card-details</v-icon>
                </v-btn>
              </template>
            </v-data-table>
          </v-flex> -->
        </v-layout>
      </v-col>
      <v-col cols="12" class="px-sm-6 py-0">
        <v-card class="q-card-shadow q-card-border pa-5">
          <v-data-table
            :items="baiTuyenDung"
            :headers="tableHeader"
            @update:options="getBaiTuyenDung"
            :options.sync="searchParamsBaiTuyenDung"
            :server-items-length="totalItems"
          >
            <template v-slot:item.thaotac="{ item }">
              <v-btn
                text
                color="primary"
                icon
                small
                @click="showModalThemSua(true, item.id)"
                class="ma-0"
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
                <v-icon small>delete</v-icon>
              </v-btn>
            </template>
            <!-- <template v-slot:item.loTrinh="{ item }">
              <span v-if="item.tenMonHoc != undefined && item.tenMonHoc.length>0">
                <span
                  style="color: #098ce9; font-weight: bolder;"
                  v-for="(lt,i ) in item.tenMonHoc"
                  :key="i"
                >
                  <span v-if="i!= 0">-></span>
                  {{lt}}
                </span>
              </span>
            </template> -->
          </v-data-table>
          <modal-quan-ly-bai-tuyen-dung
            ref="modalQuanLyBaiTuyenDung"
            @getLaiDs="getBaiTuyenDung(searchParamsBaiTuyenDung)"
          ></modal-quan-ly-bai-tuyen-dung>
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
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>
<script lang="ts">
import { Vue } from "vue-property-decorator";
//import ModalQuanLyKhoaHoc from "./ModalQuanLyKhoaHoc.vue";
import BaiTuyenDungApi, {
  GetBaiTuyenDungParams,
} from "@/apiResources/Interview/BaiTuyenDungApi";
import { BaiTuyenDungDTO } from "@/models/Interview/BaiTuyenDungDTO";
import DoanhNghiepApi, {
  GetDoanhNghiepParams,
} from "@/apiResources/Interview/DoanhNghiepApi";
import { DoanhNghiepDTO } from "@/models/Interview/DoanhNghiepDTO";
import ModalQuanLyBaiTuyenDung from "./ModalQuanLyBaiTuyenDung.vue";
export default Vue.extend({
  components: {
    //ModalQuanLyKhoaHoc,
    ModalQuanLyBaiTuyenDung,
  },
  data() {
    return {
      dialogConfirmDelete: false,
      baiTuyenDung: [] as BaiTuyenDungDTO[],
      dsDoanhNghiep: [] as DoanhNghiepDTO[],
      loading: false,
      deleting: false,
      selected: {} as any,
      isUpdate: false,
      searchParamsBaiTuyenDung: { itemsPerPage: 10 } as GetBaiTuyenDungParams,
      searchParamsDoanhNghiep: { itemsPerPage: 10 } as GetDoanhNghiepParams,
      tableHeader: [
        {
          text: "KH",
          value: "kyHieu",
          align: "center",
          sortable: false,
          width: 50,
        },
        {
          text: "Tên bài tuyển dụng",
          value: "tieuDe",
          align: "center",
          sortable: false,
          width: 150,
        },
        // {
        //   text: "Lộ trình",
        //   value: "loTrinh",
        //   align: "center",
        //   sortable: false,
        // },
        {
          text: "Thao tác",
          value: "thaotac",
          align: "center",
          sortable: false,
          width: 90,
        },
      ],
      totalItems: 0 as number | undefined,
    };
  },
  computed: {
    breadcrumbs(): any {
      return [
        {
          text: "Home",
          disabled: false,
          href: "#/",
        },
        {
          text: "Bài tuyển dụng",
          disabled: true,
        },
      ];
    },
  },
  created() {
    this.getDSDoanhNghiep(this.searchParamsDoanhNghiep);
  },
  mounted() {},
  methods: {
    showModalThemSua(isUpdate: boolean, id: number) {
      (this.$refs.modalQuanLyBaiTuyenDung as any).show(isUpdate, id);
    },
    confirmDelete(item: any): void {
      this.selected = item;
      this.dialogConfirmDelete = true;
    },
    getDSDoanhNghiep(searchParamsDoanhNghiep: GetDoanhNghiepParams) {
      this.loading = true;
      DoanhNghiepApi.getDoanhNghiep(searchParamsDoanhNghiep).then((res) => {
        this.dsDoanhNghiep = res.data;
      });
    },
    getBaiTuyenDung(searchParamsBaiTuyenDung: GetBaiTuyenDungParams): void {
      this.loading = true;
      BaiTuyenDungApi.getBaiTuyenDung(searchParamsBaiTuyenDung)
        .then((res) => {
          this.baiTuyenDung = res.data;
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
      BaiTuyenDungApi.deleteBaiTuyenDung(this.selected.id)
        .then((res) => {
          this.$snotify.success("Xóa bài tuyển dụng thành công!");
          this.getBaiTuyenDung(this.searchParamsBaiTuyenDung);
        })
        .catch((res) => {
          this.$snotify.error("Xóa bài tuyển dụng thất bại!");
        });
      this.dialogConfirmDelete = false;
      this.deleting = false;
    },
  },
});
</script>
