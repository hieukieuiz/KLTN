<template>
  <v-dialog v-model="dialog" scrollable max-width="900">
    <v-card>
      <v-card-title class="px-5">
        {{ isUpdate ? "Cập nhật " : "Thêm mới " }}
        <v-spacer></v-spacer>
        <v-btn class="ma-0" small @click="hide" icon light>
          <v-icon>close</v-icon>
        </v-btn>
      </v-card-title>
      <v-divider class="grey lighten-2"></v-divider>
      <v-card-text>
        <v-form v-model="valid" scope="frmAddEdit">
          <v-row class="mt-3">
            <v-col cols="12" md="6" v-if="baiTuyenDung.anhDaiDien">
              <span class="q-label mb-1">Ảnh đại diện</span>
              <v-img
                height="200"
                class="grey lighten-2"
                :src="
                  HOST + '/api/fileupload/download/' + baiTuyenDung.anhDaiDien
                "
                aspect-ratio="0.75"
                contain
              ></v-img>
            </v-col>
            <input
              type="file"
              accept=".jpg, .png, .jpeg"
              style="display:none;"
              ref="inpFile"
              id="inpFile"
              @change="changePhoto"
            />
            <v-col cols="12" md="6" v-if="baiTuyenDung.linkAnhMinhHoa">
              <span class="q-label mb-1">Ảnh minh họa</span>
              <v-img
                height="200"
                class="grey lighten-2"
                :src="
                  HOST +
                    '/api/fileupload/download/' +
                    baiTuyenDung.linkAnhMinhHoa
                "
                aspect-ratio="0.75"
                contain
              ></v-img>
            </v-col>
            <input
              type="file"
              accept=".jpg, .png, .jpeg"
              style="display:none;"
              ref="inpFile1"
              id="inpFile1"
              @change="changePhoto1"
            />
            <v-col cols="12" md="4" class="pa-3 pb-0 pr-md-0">
              <span class="q-label mb-2">Tên bài tuyển dụng</span>
              <v-text-field
                v-model="baiTuyenDung.tieuDe"
                :error-messages="
                  errors.collect('Tên bài tuyển dụng', 'frmAddEdit')
                "
                v-validate="'required'"
                data-vv-scope="frmAddEdit"
                data-vv-name="Tên bài tuyển dụng"
                solo
                flat
                class="mt-0"
                dense
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="4" class="pa-3 pb-0 pr-md-0">
              <span class="q-label mb-2">Tên doanh nghiệp</span>
              <v-autocomplete
                v-model="baiTuyenDung.doanhNghiepId"
                @change="getBaiTuyenDung(baiTuyenDung)"
                :items="dsDoanhNghiep"
                v-validate="'required'"
                data-vv-scope="frmAddEdit"
                item-text="tenDoanhNghiep"
                item-value="id"
                solo
                flat
                class="mt-0"
                dense
              ></v-autocomplete>
            </v-col>
            <v-col cols="12" md="4" class="pa-3 pb-0">
              <span class="q-label mb-2">Ký hiệu</span>
              <v-text-field
                v-validate="{ required: true, max: 5, min: 2 }"
                v-model="baiTuyenDung.kyHieu"
                :error-messages="errors.collect('Ký hiệu', 'frmAddEdit')"
                data-vv-scope="frmAddEdit"
                data-vv-name="Ký hiệu"
                solo
                flat
                class="mt-0"
                dense
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="3" class="pt-0">
              <v-checkbox
                v-model="baiTuyenDung.hienThi"
                class="mt-0 pt-0"
                hide-details
              >
                <template v-slot:label>
                  <span class="q-label">Active</span>
                </template>
              </v-checkbox>
            </v-col>
            <v-col cols="12" md="9" class="py-0 px-3 d-flex justify-end">
              <v-btn
                rounded
                height="34"
                @click="$refs.inpFile.click()"
                class="mr-3"
                color="#EBEDF0"
                style="box-shadow:none;"
                :loading="loadingAnh"
                >{{ baiTuyenDung.anhDaiDien ? "Sửa" : "Thêm" }} ảnh đại
                diện</v-btn
              >
              <v-btn
                rounded
                height="34"
                @click="$refs.inpFile1.click()"
                color="#EBEDF0"
                style="box-shadow:none;"
                :loading="loadingAnh"
                >{{ baiTuyenDung.linkAnhMinhHoa ? "Sửa" : "Thêm" }} ảnh minh
                họa</v-btn
              >
            </v-col>
            <v-col cols="12" class="pt-0">
              <span class="q-label mb-2">Viết giới thiệu</span>
              <v-ckeditor
                v-model="baiTuyenDung.gioiThieu"
                :config="editorConfig"
              ></v-ckeditor>
            </v-col>

            <!-- <v-col cols="12" class="py-0" v-if="showLoTrinh">
              <v-row>
                <v-col cols="12" class="d-flex">
                  <span style="font-size:18px; color: #050505">Chương trình học</span>
                  <v-spacer></v-spacer>
                  <v-btn color="primary" small @click="showModalThemSuaCT(false,{})">Thêm mới</v-btn>
                </v-col>
                <v-col cols="12" class="py-0">
                  <v-data-table
                    :loading="loading"
                    :items="dsGoiKhoaHoc"
                    :headers="headersChuongTrinh"
                    :server-items-length="totalChuongTrinhs"
                  >
                    <template v-slot:item.thaotac="{ item }">
                      <v-btn
                        color="primary"
                        icon
                        small
                        @click="showModalThemSuaCT(true,item)"
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
                        @click="confirmDeleteCT(item)"
                      >
                        <v-icon small>delete</v-icon>
                      </v-btn>
                    </template>
                  </v-data-table>
                </v-col>
              </v-row>
              <v-row>
                <v-col cols="12" class="pb-0">
                  <span style="font-size:18px; color: #050505">Lộ trình khóa học</span>
                </v-col>
                <v-col cols="6" class="pt-2 pb-0">
                  <span class="q-label mb-1">Chọn Môn</span>
                  <v-autocomplete
                    solo
                    flat
                    dense
                    class="mt-0"
                    v-model="khoaMonHoc.monHocId"
                    :items="dsMon"
                    item-text="tenMon"
                    item-value="id"
                    :error-messages="errors.collect('Chọn Môn', 'formKhoaMonHoc')"
                    v-validate="'required'"
                    data-vv-scope="formKhoaMonHoc"
                    data-vv-name="Chọn Môn"
                    required
                  ></v-autocomplete>
                </v-col>
                <v-col cols="3" class="px-1 pt-2 pb-0">
                  <span class="q-label mb-1">Số thứ tự học</span>
                  <v-text-field
                    v-model.number="khoaMonHoc.soThuTu"
                    solo
                    flat
                    dense
                    class="mt-0"
                    type="number"
                    :error-messages="errors.collect('Số thứ tự học', 'formKhoaMonHoc')"
                    v-validate="'required|numeric'"
                    data-vv-scope="formKhoaMonHoc"
                    data-vv-name="Số thứ tự học"
                  ></v-text-field>
                </v-col>
                <v-col cols="3" class="d-flex align-center justify-end">
                  <v-btn
                    color="orange lighten-2"
                    class="mr-3"
                    fab
                    dark
                    small
                    @click="saveKhoaMonHoc()"
                  >
                    <v-icon small class="px-0">{{isUpdateChiTiet == false ? 'add' :'save'}}</v-icon>
                  </v-btn>
                  <v-btn color="orange lighten-2" fab dark small @click="reload()">
                    <v-icon small class="px-0">autorenew</v-icon>
                  </v-btn>
                </v-col>

                <v-col cols="12" class="pt-0">
                  <v-data-table
                    :loading="loading"
                    :items="dskhoaMonHoc"
                    :headers="tableHeader"
                    @update:options="getDSKhoaMonHoc"
                    :options.sync="searchParamsKhoaMonHoc"
                    :server-items-length="totalItems"
                    class="elevation-0"
                  >
                    <template v-slot:body="{ }">
                      <tbody>
                        <tr
                          v-for="item in dskhoaMonHoc"
                          :key="item.id"
                          @click.stop="selectedRow(item)"
                          style="cursor: pointer"
                        >
                          <td class="text-center">{{item.monHoc.kyHieu}}-{{item.monHoc.tenMon}}</td>
                          <td class="text-center">{{item.soThuTu}}</td>
                          <td class="text-center">
                            <v-btn icon small class="mx-0" @click.stop="confirmDelete(item)">
                              <v-icon small color="red">delete</v-icon>
                            </v-btn>
                          </td>
                        </tr>
                      </tbody>
                    </template>
                  </v-data-table>
                </v-col>
              </v-row>
            </v-col> -->
          </v-row>
        </v-form>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          class="primary"
          :loading="loadingbtn"
          :disabled="loadingbtn"
          @click.native="save"
          >{{ isUpdate ? "Cập nhật" : "Lưu" }}</v-btn
        >
      </v-card-actions>
      <!-- <v-dialog v-model="dialogConfirmDelete" max-width="290">
        <v-card>
          <v-card-title class="headline">Xác nhận xóa</v-card-title>
          <v-card-text class="pt-3">Bạn có chắc chắn muốn xóa?</v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn :disabled="deleting" @click.native="dialogConfirmDelete=false" text>Hủy</v-btn>
            <v-btn
              :disabled="deleting"
              :loading="deleting"
              color="red darken-1"
              @click="deleteItem"
              text
            >Xác Nhận</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <v-dialog v-model="dialogConfirmDeleteCT" max-width="290">
        <v-card>
          <v-card-title class="headline">Xác nhận xóa</v-card-title>
          <v-card-text class="pt-3">Bạn có chắc chắn muốn xóa?</v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn :disabled="deleting" @click.native="dialogConfirmDelete=false" text>Hủy</v-btn>
            <v-btn
              :disabled="deleting"
              :loading="deleting"
              color="red darken-1"
              @click="deleteChuongTrinh"
              text
            >Xác Nhận</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <modal-khoa-mon-hoc ref="modalKhoaMonHoc" @getLaiDs="getDSKhoaMonHoc(searchParamsKhoaMonHoc)"></modal-khoa-mon-hoc>
      <modal-them-sua-chuong-trinh ref="modalThemSuaChuongTrinh" @getLaiDs="getDanhSachGoiKhoaHoc"></modal-them-sua-chuong-trinh> -->
      -->
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
//import ModalKhoaMonHoc from "./ModalKhoaMonHoc.vue";
//import ModalThemSuaChuongTrinh from "./ModalThemSuaChuongTrinh.vue";
//import { MonHocDTO } from "../../models/MonHocDTO";
//import MonHocApi, { GetMonHocParams } from "@/apiResources/MonHocApi";
import { BaiTuyenDungDTO } from "../../models/Interview/BaiTuyenDungDTO";
import BaiTuyenDungApi, {
  GetBaiTuyenDungParams,
} from "@/apiResources/Interview/BaiTuyenDungApi";
import DoanhNghiepApi, {
  GetDoanhNghiepParams,
} from "@/apiResources/Interview/DoanhNghiepApi";
import { DoanhNghiepDTO } from "@/models/Interview/DoanhNghiepDTO";
//import { KhoaMonHocDTO } from "../../models/KhoaMonHocDTO";
//import KhoaMonHocApi, {
//  GetKhoaMonHocParams,
//} from "@/apiResources/KhoaMonHocApi";
import FileUploadApi from "../../apiResources/FileUploadApi";
//import { GoiKhoaHocDTO } from "../../models/GoiKhoaHocDTO";
//import GoiKhoaHocApi from "../../apiResources/GoiKhoaHocApi";
export default Vue.extend({
  components: {
    //ModalKhoaMonHoc,
    //ModalThemSuaChuongTrinh,
  },
  data() {
    return {
      valid: false,
      loadingAnh: false,
      HOST: process.env.VUE_APP_ROOT_API,
      row: "all",
      isUpdate: false,
      dialog: false,
      taiKhoan: {} as any,
      isUpdateChiTiet: false,
      dialogConfirmDelete: false,
      dialogConfirmDeleteCT: false,
      showLoTrinh: false,
      items: ["Tất cả", "Sự kiện"],
      a: "Tất cả",
      //khoaMonHoc: {} as KhoaMonHocDTO,
      //dskhoaMonHoc: [] as KhoaMonHocDTO[],
      baiTuyenDung: {} as BaiTuyenDungDTO,
      searchParamsBaiTuyenDung: { itemsPerPage: 10 } as GetBaiTuyenDungParams,
      searchParamsDoanhNghiep: { itemsPerPage: 10 } as GetDoanhNghiepParams,
      //searchParamsKhoaMonHoc: { itemsPerPage: 10 } as GetKhoaMonHocParams,
      deleting: false,
      selected: {} as any,
      chuongTrinhSelected: {} as any,
      dsDoanhNghiep: [] as DoanhNghiepDTO[],
      //searchParamsMonHoc: { itemsPerPage: 0 } as GetMonHocParams,
      //dsMon: [] as MonHocDTO[],
      loading: false,
      // tableHeader: [
      //   { text: "Môn", value: "mon", align: "center", sortable: true },
      //   { text: "Thứ tự", value: "soThuTu", align: "center", sortable: true },
      //   { text: "Thao tác", value: "thaotac", align: "center", sortable: true },
      // ],
      // headersChuongTrinh: [
      //   {
      //     text: "Tên chương trình",
      //     value: "goiChuongTrinh.tenGoiChuongTrinh",
      //     align: "center",
      //     sortable: false,
      //   },
      //   { text: "Thứ tự", value: "thuTu", align: "center", sortable: false },
      //   { text: "Giá", value: "giaThanh", align: "center", sortable: false },
      //   {
      //     text: "Thao tác",
      //     value: "thaotac",
      //     align: "center",
      //     sortable: false,
      //   },
      // ],
      editorConfig: {
        height: 200,
        language: "vi",
        toolbarGroups: [
          { name: "document", groups: ["mode", "document", "doctools"] },
          { name: "clipboard", groups: ["clipboard", "undo"] },
          { name: "forms" },
          { name: "basicstyles", groups: ["basicstyles"] },
          { name: "colors" },
          { name: "tools" },
          { name: "others" },
          { name: "about" },
          {
            name: "paragraph",
            groups: ["list", "indent", "blocks", "align", "bidi"],
          },
          { name: "links" },
          { name: "insert" },
          { name: "styles" },
        ],
        filebrowserBrowseUrl: "/MediaFilesManager",
        filebrowserImageBrowseUrl: "/MediaFilesManager?type=Images",
        filebrowserUploadUrl: "/MediaFilesManager",
        filebrowserImageUploadUrl: "/MediaFilesManager?type=Images",
      },
      loadingbtn: false,
      totalItems: 0 as number | undefined,
      totalChuongTrinhs: 0 as number | undefined,
      //dsGoiKhoaHoc: [] as GoiKhoaHocDTO[],
    };
  },
  created() {
    this.getDanhSachDoanhNghiep();
  },
  mounted() {},
  methods: {
    hide() {
      this.dialog = false;
    },
    // showModalThemSuaCT(isUpdate: boolean, item: any) {
    //   (this.$refs.modalThemSuaChuongTrinh as any).show(
    //     isUpdate,
    //     item,
    //     this.khoaHoc.id
    //   );
    // },
    // getDSKhoaMonHoc(searchParamsKhoaMonHoc: GetKhoaMonHocParams): void {
    //   searchParamsKhoaMonHoc.khoaHocId = this.khoaHoc.id;
    //   KhoaMonHocApi.getKhoaMonHoc(searchParamsKhoaMonHoc)
    //     .then((res) => {
    //       this.dskhoaMonHoc = res.data;
    //       this.totalItems = res.pagination.totalItems;
    //     })
    //     .catch((res) => {
    //       this.loading = false;
    //       this.$snotify.error("Lấy dữ liệu khóa môn học thất bại!");
    //     });
    // },
    getDanhSachDoanhNghiep() {
      this.loading = true;
      DoanhNghiepApi.getDoanhNghiep({ itemsPerPage: -1 })
        .then((res) => {
          this.dsDoanhNghiep = res.data;
        })
        .catch((res) => {
          this.$snotify.error("Lấy danh sách doanh nghiệp thất bại!");
        });
    },
    show(isUpdate: boolean, id: number) {
      this.$validator.errors.clear();
      this.dialog = true;
      this.isUpdate = isUpdate;
      this.getDanhSachDoanhNghiep();
      //this.getDSMonHoc();
      //this.khoaMonHoc = {} as KhoaMonHocDTO;
      if (isUpdate) {
        //this.showLoTrinh = true;
        this.getBaiTuyenDungID(id);
        //this.searchParamsDoanhNghiep. = id;
        this.getDanhSachDoanhNghiep();
        //this.searchParamsKhoaMonHoc.khoaHocId = id;
        //this.getDSKhoaMonHoc(this.searchParamsKhoaMonHoc);
        //this.getDanhSachGoiKhoaHoc(id);
      } else {
        //this.showLoTrinh = false;
        this.baiTuyenDung = {} as BaiTuyenDungDTO;
        this.baiTuyenDung.gioiThieu = "";
      }
    },
    confirmDelete(item: any): void {
      this.selected = item;
      this.dialogConfirmDelete = true;
    },
    // deleteItem(): void {
    //   this.deleting = true;
    //   // call api delete
    //   KhoaMonHocApi.deleteKhoaMonHoc(this.selected.id)
    //     .then((res) => {
    //       this.$snotify.success("Xóa khóa môn học thành công!");
    //       this.getDSKhoaMonHoc(this.searchParamsKhoaMonHoc);
    //     })
    //     .catch((res) => {
    //       this.$snotify.error("Xóa khóa môn học thất bại!");
    //     });
    //   this.dialogConfirmDelete = false;
    //   this.deleting = false;
    // },
    // confirmDeleteCT(item: any): void {
    //   this.chuongTrinhSelected = item;
    //   this.dialogConfirmDeleteCT = true;
    // },
    // deleteChuongTrinh(): void {
    //   this.deleting = true;
    //   // call api delete
    //   GoiKhoaHocApi.deleteGoiKhoaHoc(this.chuongTrinhSelected.id)
    //     .then((res) => {
    //       this.$snotify.success("Xóa thành công!");
    //       this.getDanhSachGoiKhoaHoc(this.khoaHoc.id);
    //     })
    //     .catch((res) => {
    //       this.$snotify.error("Xóa thất bại!");
    //     });
    //   this.dialogConfirmDeleteCT = false;
    //   this.deleting = false;
    // },

    getBaiTuyenDungID(id: number) {
      BaiTuyenDungApi.getBaiTuyenDungById(id)
        .then((res) => {
          this.baiTuyenDung = res;
          if (this.baiTuyenDung.gioiThieu == null)
            this.baiTuyenDung.gioiThieu = " ";
          //this.getDSKhoaMonHoc(this.searchParamsKhoaMonHoc);
        })
        .catch((res) => {
          this.$snotify.error("Lấy dữ liệu bài tuyển dụng thất bại!");
        });
    },
    // getDSMonHoc() {
    //   MonHocApi.getMonHoc(this.searchParamsMonHoc)
    //     .then((res) => {
    //       this.dsMon = res.data;
    //     })
    //     .catch((res) => {
    //       this.$snotify.error("Lấy dữ liệu môn học thất bại!");
    //     });
    // },
    reload() {
      this.isUpdateChiTiet = false;
      this.$validator.reset();
      //this.khoaMonHoc = {} as KhoaMonHocDTO;
    },
    selectedRow(value: any) {
      //this.khoaMonHoc = value;
      this.isUpdateChiTiet = true;
    },
    // saveKhoaMonHoc(): void {
    //   this.khoaMonHoc.khoaHocId = this.khoaHoc.id;
    //   this.khoaMonHoc.monHoc = undefined as any;
    //   this.$validator.validateAll("formKhoaMonHoc").then((res) => {
    //     if (res) {
    //       if (this.isUpdateChiTiet) {
    //         this.loading = true;
    //         KhoaMonHocApi.updateKhoaMonHoc(this.khoaMonHoc.id, this.khoaMonHoc)
    //           .then((res) => {
    //             this.loading = false;
    //             this.isUpdateChiTiet = false;
    //             this.$emit("getLaiDs");
    //             this.khoaMonHoc = {} as KhoaMonHocDTO;
    //             this.getDSKhoaMonHoc(this.searchParamsKhoaMonHoc);
    //             this.$snotify.success("Cập nhật thành công!");
    //           })
    //           .catch((res) => {
    //             this.loading = false;
    //             this.$snotify.error("Cập nhật thất bại!");
    //           });
    //       } else {
    //         this.loading = true;
    //         KhoaMonHocApi.createKhoaMonHoc(this.khoaMonHoc)
    //           .then((res) => {
    //             this.khoaMonHoc = res;
    //             this.isUpdateChiTiet = false;
    //             this.loading = false;
    //             this.$emit("getLaiDs");
    //             this.khoaMonHoc = {} as KhoaMonHocDTO;
    //             this.getDSKhoaMonHoc(this.searchParamsKhoaMonHoc);
    //             this.$snotify.success("Thêm mới thành công!");
    //           })
    //           .catch((res) => {
    //             this.loading = false;
    //             this.$snotify.error("Thêm mới thất bại!");
    //           });
    //       }
    //     }
    //   });
    // },
    // getDanhSachGoiKhoaHoc(khoaHocId: number) {
    //   GoiKhoaHocApi.getGoiKhoaHoc({ khoaHocId: khoaHocId, itemsPerPage: -1 })
    //     .then((res) => {
    //       this.dsGoiKhoaHoc = res.data;
    //       this.totalChuongTrinhs = res.pagination.totalItems;
    //     })
    //     .catch((res) => {
    //       this.$snotify.error("Lấy danh sách gói khóa học thất bại!");
    //     });
    // },
    save(): void {
      this.$validator.validateAll("frmAddEdit").then((res) => {
        if (res) {
          this.loading = true;
          this.loadingbtn = true;
          if (this.isUpdate) {
            BaiTuyenDungApi.updateBaiTuyenDung(
              this.baiTuyenDung.id,
              this.baiTuyenDung
            )
              .then((res) => {
                this.baiTuyenDung = res;
                this.loading = false;
                this.loadingbtn = false;
                this.$snotify.success("Cập nhật bài tuyển dụng thành công!");
                this.isUpdate = true;
                this.hide();
                this.$emit("getLaiDs");
              })
              .catch((res) => {
                this.loading = false;
                this.loadingbtn = false;
                this.$snotify.error("Cập nhật bài tuyển dụng thất bại!");
              });
          } else {
            BaiTuyenDungApi.createBaiTuyenDung(this.baiTuyenDung)
              .then((res) => {
                this.baiTuyenDung = res;
                this.isUpdate = true;
                this.loading = false;
                this.loadingbtn = false;
                //this.showLoTrinh = true;
                this.$snotify.success("Thêm mới bài tuyển dụng thành công!");
                //this.getDSKhoaMonHoc(this.searchParamsKhoaMonHoc);
                //this.getDanhSachGoiKhoaHoc(this.khoaHoc.id);
                this.$emit("getLaiDs");
              })
              .catch((res) => {
                this.loading = false;
                this.loadingbtn = false;
                this.$snotify.error("Thêm mới bài tuyển dụng thất bại!");
              });
          }
        }
      });
    },
    changePhoto(): void {
      this.loadingAnh = true;
      var formData = new FormData();
      let inpFile = document.querySelector("#inpFile") as any;
      formData.append("img", inpFile.files[0]);
      inpFile.value = null;
      FileUploadApi.upload(formData)
        .then((res) => {
          Vue.set(this.baiTuyenDung, "anhDaiDien", res.key);
          this.loadingAnh = false;
        })
        .catch((res) => {
          this.loadingAnh = false;
          this.$snotify.error("Upload ảnh thất bại!");
        });
    },
    changePhoto1(): void {
      this.loadingAnh = true;
      var formData = new FormData();
      let inpFile = document.querySelector("#inpFile1") as any;
      formData.append("img", inpFile.files[0]);
      inpFile.value = null;
      FileUploadApi.upload(formData)
        .then((res) => {
          Vue.set(this.baiTuyenDung, "linkAnhMinhHoa", res.key);
          this.loadingAnh = false;
        })
        .catch((res) => {
          this.loadingAnh = false;
          this.$snotify.error("Upload ảnh thất bại!");
        });
    },
  },
});
</script>
