<template>
  <v-container
    style="background-color: #fff; min-height: auto"
    class="q-card-shadow q-card-border mt-3"
  >
    <v-row>
      <v-col cols="12" md="9">
        <h3>CV Ứng Viên</h3>
        <h4>1. Thông tin ứng viên</h4>
      </v-col>

      <v-col cols="12" md="12" style="padding: 0px 12px">
        <v-row>
          <v-col md="4" style="padding: 0px 12px">
            <v-tooltip top>
              <template v-slot:activator="{ on, attrs }">
                <v-text-field
                  v-model="ungVien.hoTen"
                  label="Họ tên (*)"
                  :error-messages="errors.collect('Họ tên', 'frmAddEdit')"
                  v-validate="'required'"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Họ tên"
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
            </v-tooltip>
          </v-col>

          <v-col md="4" style="padding: 0px 12px 0px 12px">
            <v-tooltip top>
              <template v-slot:activator="{ on, attrs }">
                <v-datepicker
                  v-model="ungVien.ngaySinh"
                  :error-messages="errors.collect('Ngày sinh', 'frmAddEdit')"
                  v-validate="'required'"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Ngày sinh"
                  label="Ngày sinh (*)"
                  v-bind="attrs"
                  v-on="on"
                ></v-datepicker>
              </template>
            </v-tooltip>
          </v-col>
          <v-col md="4" style="padding: 0px 12px 0px 12px">
            <v-tooltip top>
              <template v-slot:activator="{ on, attrs }">
                <v-autocomplete
                  v-model="search"
                  label="Giới tính"
                  v-bind="attrs"
                  v-on="on"
                ></v-autocomplete>
              </template>
            </v-tooltip>
          </v-col>

          <v-col md="4" style="padding: 0px 12px 0px 12px">
            <v-tooltip top>
              <template v-slot:activator="{ on, attrs }">
                <v-text-field
                  v-model="search"
                  append-icon="mdi-clipboard-account"
                  label="Địa chỉ"
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
            </v-tooltip>
          </v-col>

          <v-col md="4" style="padding: 0px 12px 0px 12px">
            <v-tooltip top>
              <template v-slot:activator="{ on, attrs }">
                <v-text-field
                  v-model="search"
                  append-icon="mdi-clipboard-list"
                  label="SĐT"
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
            </v-tooltip>
          </v-col>

          <v-col md="4" style="padding: 0px 12px 0px 12px">
            <v-tooltip top>
              <template v-slot:activator="{ on, attrs }">
                <v-text-field
                  v-model="ungVien.email"
                  :error-messages="errors.collect('Email', 'frmAddEdit')"
                  v-validate="'required'"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Email"
                  label="Địa chỉ Gmail"
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
            </v-tooltip>
          </v-col>

          <v-col md="6" style="padding: 0px 12px 0px 12px">
            <v-tooltip top>
              <template v-slot:activator="{ on }">
                <v-textarea
                  hide-details
                  v-on="on"
                  label="Mục tiêu cá nhân"
                  rows="2"
                  style="border-radius: inherit"
                ></v-textarea>
              </template>
            </v-tooltip>
          </v-col>

          <v-col md="6" style="padding: 0px 12px 0px 12px">
            <v-tooltip top>
              <template v-slot:activator="{ on }">
                <v-textarea
                  hide-details
                  v-on="on"
                  label="Sở thích"
                  rows="2"
                  style="border-radius: inherit"
                ></v-textarea>
              </template>
            </v-tooltip>
          </v-col>

          <v-row class="px-4 pt-3">
            <v-col cols="12">
              <v-row>
                <v-col cols="12" md="6"><p>Quá trình học tập</p></v-col>
                <v-spacer></v-spacer>
                <v-col
                  cols="12"
                  md="2"
                  class="d-flex align-end justify-end pb-2"
                >
                  <v-btn
                    outlined
                    class="white--text blue"
                    @click="ShowModalThemSuaQuaTrinhHocTap(false, {})"
                    >Tạo mới</v-btn
                  >
                </v-col>
              </v-row>
              <v-data-table
                :headers="headersQuaTrinhHocTap"
                :items="dsQuaTrinhHocTap"
                :items-per-page="5"
                class="elevation-1"
                :loading="loading"
                @update:options="getQuaTrinhHocTap"
                :options.sync="searchParamsQuaTrinhHocTap"
                :server-items-length="searchParamsQuaTrinhHocTap.totalItems"
              >
                <template v-slot:item.ThaoTac="{ item }">
                  <v-btn icon small class="mx-0">
                    <v-icon
                      small
                      color="teal"
                      @click="ShowModalThemSuaQuaTrinhHocTap(true, item)"
                      @created="getQuaTrinhHocTap(searchParamsQuaTrinhHocTap)"
                      @updated="getQuaTrinhHocTap(searchParamsQuaTrinhHocTap)"
                      >edit</v-icon
                    >
                  </v-btn>
                  <v-btn icon small class="mx-0">
                    <v-icon
                      small
                      color="red"
                      @click="XacNhanXoaQuaTrinhHocTap()"
                      >delete</v-icon
                    >
                  </v-btn>
                </template>
              </v-data-table>
              <v-dialog
                v-model="dialogXoaQuaTrinhHocTap"
                persistent
                max-width="290"
              >
                <v-card>
                  <v-card-title class="headline">
                    Xác nhận xóa
                  </v-card-title>
                  <v-card-text>Bạn có chắc chắn muốn xóa không?.</v-card-text>
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn
                      color="green darken-1"
                      text
                      @click.native="dialogXoaQuaTrinhHocTap = false"
                    >
                      Hủy
                    </v-btn>
                    <v-btn
                      color="green darken-1"
                      text
                      :disabled="deleting"
                      :loading="deleting"
                      @click="deleteItemQuaTrinhHocTap"
                    >
                      Đồng ý
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-dialog>
              <modal-them-sua-qua-trinh-hoc-tap
                ref="modalThemSuaQuaTrinhHocTap"
                @getLaiDs="getQuaTrinhHocTap()"
              ></modal-them-sua-qua-trinh-hoc-tap>
            </v-col>

            <v-col cols="12">
              <v-row>
                <v-col cols="12" md="6"><p>Quá trình làm dự án</p></v-col>
                <v-spacer></v-spacer>
                <v-col
                  cols="12"
                  md="2"
                  class="d-flex align-end justify-end pb-2"
                >
                  <v-btn
                    outlined
                    class="white--text blue"
                    @click="ShowModalThemSuaQuaTrinhLamDuAn(false, {})"
                    >Tạo mới</v-btn
                  >
                </v-col>
              </v-row>
              <v-data-table
                :loading="loading"
                :headers="headersQuaTrinhLamDuAn"
                :items="dsQuaTrinhLamDuAn"
                @update:options="getQuaTrinhLamDuAn"
                :options.sync="searchParamsQuaTrinhLamDuAn"
                :server-items-length="searchParamsQuaTrinhLamDuAn.totalItems"
                :items-per-page="5"
                class="elevation-1"
              >
                <template v-slot:item.ThaoTac="{ item }">
                  <v-btn icon small class="mx-0">
                    <v-icon
                      small
                      color="teal"
                      @click="ShowModalThemSuaQuaTrinhLamDuAn(true, item)"
                      @created="getQuaTrinhLamDuAn(searchParamsQuaTrinhLamDuAn)"
                      @updated="getQuaTrinhLamDuAn(searchParamsQuaTrinhLamDuAn)"
                      >edit</v-icon
                    >
                  </v-btn>
                  <v-btn icon small class="mx-0">
                    <v-icon
                      small
                      color="red"
                      @click="XacNhanXoaQuaTrinhLamDuAn()"
                      >delete</v-icon
                    >
                  </v-btn>
                </template>
              </v-data-table>
              <v-dialog
                v-model="dialogXoaQuaTrinhLamDuAn"
                persistent
                max-width="290"
              >
                <v-card>
                  <v-card-title class="headline">
                    Xác nhận xóa
                  </v-card-title>
                  <v-card-text>Bạn có chắc chắn muốn xóa không?.</v-card-text>
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn
                      color="green darken-1"
                      text
                      @click.native="dialogXoaQuaTrinhLamDuAn = false"
                    >
                      Disagree
                    </v-btn>
                    <v-btn color="green darken-1" text @click="deleteItem">
                      Agree
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-dialog>
              <modal-them-sua-qua-trinh-lam-du-an
                ref="modalThemSuaQuaTrinhLamDuAn"
                @getLaiDs="getQuaTrinhLamDuAn()"
              ></modal-them-sua-qua-trinh-lam-du-an>
            </v-col>

            <v-col cols="12">
              <v-row>
                <v-col cols="12" md="6"><p>Bằng cấp, chứng chỉ</p></v-col>
                <v-spacer></v-spacer>
                <v-col
                  cols="12"
                  md="2"
                  class="d-flex align-end justify-end pb-2"
                >
                  <v-btn
                    outlined
                    class="white--text blue"
                    @click="ShowModalThemSuaBangCapChungChi(false, {})"
                    >Tạo mới</v-btn
                  >
                </v-col>
              </v-row>
              <v-data-table
                :headers="headersBangCapChungChi"
                :items="dsBangCapChungChi"
                :items-per-page="5"
                class="elevation-1"
              >
                <template v-slot:item.ThaoTac="{ item }">
                  <v-btn icon small class="mx-0">
                    <v-icon
                      small
                      color="teal"
                      @click="ShowModalThemSuaBangCapChungChi(true, item)"
                      >edit</v-icon
                    >
                  </v-btn>
                  <v-btn icon small class="mx-0">
                    <v-icon
                      small
                      color="red"
                      @click="XacNhanXoaBangCapChungChi()"
                      >delete</v-icon
                    >
                  </v-btn>
                </template>
              </v-data-table>
              <v-dialog
                v-model="dialogXoaBangCapChungChi"
                persistent
                max-width="290"
              >
                <v-card>
                  <v-card-title class="headline">
                    Xác nhận xóa
                  </v-card-title>
                  <v-card-text>Bạn có chắc chắn muốn xóa không?.</v-card-text>
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn
                      color="green darken-1"
                      text
                      @click="dialogXoaBangCapChungChi = false"
                    >
                      Disagree
                    </v-btn>
                    <v-btn
                      color="green darken-1"
                      text
                      @click="dialogXoaBangCapChungChi = false"
                    >
                      Agree
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-dialog>
              <modal-them-sua-bang-cap-chung-chi
                ref="modalThemSuaBangCapChungChi"
              ></modal-them-sua-bang-cap-chung-chi>
            </v-col>
          </v-row>
        </v-row>
      </v-col>
    </v-row>

    <v-row>
      <v-col cols="12" md="9">
        <h4>2. Đánh giá năng lực</h4>
      </v-col>
      <template>
        <v-expansion-panels focusable style="margin: 12px" outline color="red">
          <v-expansion-panel>
            <v-expansion-panel-header style="font-size: 18px"
              >A. Nhóm kỹ năng lập trình
              <template v-slot:actions>
                <v-icon color="primary"> mdi-menu-down-outline </v-icon>
              </template>
            </v-expansion-panel-header>
            <v-expansion-panel-content>
              <v-row>
                <v-col
                  cols="12"
                  md="6"
                  style="padding: 0px 12px; margin-top: 30px"
                >
                  <v-row>
                    <v-col cols="5" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on, attrs }">
                          <v-text-field
                            v-model="search"
                            append-icon="mdi-clipboard-list"
                            label="1. Học dự án"
                            v-bind="attrs"
                            v-on="on"
                          ></v-text-field>
                        </template>
                        <span>Học dự án</span>
                      </v-tooltip>
                    </v-col>
                    <v-col
                      cols="1"
                      style="
                        padding: 0px;
                        text-align: center;
                        align-self: center;
                        padding-left: 18px;
                      "
                    >
                      {{ chonSao }}
                    </v-col>
                    <v-col cols="1" style="padding: 0px; margin-top: 17px">
                      <v-icon color="orange">mdi-star</v-icon>
                    </v-col>
                    <v-col cols="2" style="padding: 0px; margin-top: 20px">
                      <a @click="dialogChonSao = true"><i>(Sửa)</i></a>
                    </v-col>

                    <!-- hvit danh gia  -->
                    <v-col cols="10" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on }">
                          <v-textarea
                            v-on="on"
                            outlined
                            rows="2"
                            style="border-radius: inherit"
                          ></v-textarea>
                        </template>
                        <span>Hvit đánh giá</span>
                      </v-tooltip>
                    </v-col>
                    <!-- end hvit danh gia -->
                  </v-row>
                </v-col>
                <v-col
                  cols="12"
                  md="6"
                  style="padding: 0px 12px; margin-top: 30px"
                >
                  <v-row>
                    <v-col cols="5" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on, attrs }">
                          <v-text-field
                            v-model="search"
                            append-icon="mdi-clipboard-list"
                            label="1. Học dự án"
                            v-bind="attrs"
                            v-on="on"
                          ></v-text-field>
                        </template>
                        <span>Học dự án</span>
                      </v-tooltip>
                    </v-col>
                    <v-col
                      cols="1"
                      style="
                        padding: 0px;
                        text-align: center;
                        align-self: center;
                        padding-left: 18px;
                      "
                    >
                      {{ chonSao }}
                    </v-col>
                    <v-col cols="1" style="padding: 0px; margin-top: 17px">
                      <v-icon color="orange">mdi-star</v-icon>
                    </v-col>
                    <v-col cols="2" style="padding: 0px; margin-top: 20px">
                      <a @click="dialogChonSao = true"><i>(Sửa)</i></a>
                    </v-col>

                    <!-- hvit danh gia  -->
                    <v-col cols="10" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on }">
                          <v-textarea
                            v-on="on"
                            outlined
                            rows="2"
                            style="border-radius: inherit"
                          ></v-textarea>
                        </template>
                        <span>Hvit đánh giá</span>
                      </v-tooltip>
                    </v-col>
                    <!-- end hvit danh gia -->
                  </v-row>
                </v-col>
              </v-row>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </template>
      <!-- dialog chon sao -->
      <v-dialog v-model="dialogChonSao" max-width="270px">
        <v-card>
          <v-card-title style="padding: 10px">
            <span>Đánh giá ứng viên</span>
            <v-spacer></v-spacer>
            <v-btn class="ma-0 mr-1" icon small @click="dialogChonSao = false">
              <v-icon color="red">mdi-close</v-icon>
            </v-btn>
          </v-card-title>
          <v-card-actions>
            <v-rating
              v-model="chonSao"
              background-color="red"
              color="orange"
              size="18"
            ></v-rating>
          </v-card-actions>
        </v-card>
      </v-dialog>

      <!-- end chon sao -->
    </v-row>

    <v-row>
      <v-col cols="12" md="2">
        <v-btn outlined class="white--text blue">Xem CV</v-btn>
      </v-col>
      <v-spacer></v-spacer>
      <v-col cols="12" md="2" class="d-flex align-end justify-end pb-2">
        <v-btn outlined class="white--text blue">Lưu</v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import UngVienApi, {
  GetUngVienParams,
} from "@/apiResources/Interview/UngVienApi";
import { UngVienDTO } from "@/models/Interview/UngVienDTO";
import { TruongDaiHocDTO } from "@/models/TruongDaiHocDTO";
//import { LichHocDTO } from "@/models/LichHocDTO";
import TinhThanhApi, { GetTinhThanhParams } from "@/apiResources/TinhThanhApi";
import QuanHuyenApi, { GetQuanHuyenParams } from "@/apiResources/QuanHuyenApi";
import XaPhuongApi, { GetXaPhuongParams } from "@/apiResources/XaPhuongApi";
import TruongDaiHocApi, {
  GetTruongDaiHocParams,
} from "@/apiResources/TruongDaiHocApi";
import { TinhThanhDTO } from "@/models/TinhThanhDTO";
import { QuanHuyenDTO } from "@/models/QuanHuyenDTO";
import { XaPhuongDTO } from "@/models/XaPhuongDTO";
import ModalThemSuaQuaTrinhHocTap from "./ModalThemSuaQuaTrinhHocTap.vue";
import ModalThemSuaQuaTrinhLamDuAn from "./ModalThemSuaQuaTrinhLamDuAn.vue";
import ModalThemSuaBangCapChungChi from "./ModalThemSuaBangCapChungChi.vue";
import QuaTrinhLamDuAnApi, {
  GetQuaTrinhLamDuAnParams,
} from "@/apiResources/Interview/QuaTrinhLamDuAnApi";
import { QuaTrinhLamDuAnDTO } from "@/models/Interview/QuaTrinhLamDuAnDTO";
import QuaTrinhHocTapApi, {
  GetQuaTrinhHocTapParams,
} from "@/apiResources/Interview/QuaTrinhHocTapApi";
import { QuaTrinhHocTapDTO } from "@/models/Interview/QuaTrinhHocTapDTO";
import CVUngVienApi, {
  GetCVUngVienParams,
} from "@/apiResources/Interview/CVUngVienApi";
import { CVUngVienDTO } from "@/models/Interview/CVUngVienDTO";
export default Vue.extend({
  components: {
    ModalThemSuaQuaTrinhHocTap,
    ModalThemSuaQuaTrinhLamDuAn,
    ModalThemSuaBangCapChungChi,
  },
  data() {
    return {
      data: {},
      loading: false,
      deleting: false,
      selected: {} as any,
      ungVien: { quanHuyenId: 0 } as UngVienDTO,
      cVUngVien: {} as CVUngVienDTO,
      dsTinhThanh: [] as TinhThanhDTO[],
      dsQuanHuyen: [] as QuanHuyenDTO[],
      dsXaPhuong: [] as XaPhuongDTO[],
      searchParamsTruongDaiHoc: { itemsPerPage: 0 } as GetTruongDaiHocParams,
      searchParamsTinhThanh: { itemsPerPage: 0 } as GetTinhThanhParams,
      searchParamsQuanHuyen: { itemsPerPage: 0 } as GetQuanHuyenParams,
      searchParamsXaPhuong: { itemsPerPage: 0 } as GetXaPhuongParams,
      searchParamsQuaTrinhLamDuAn: {
        itemsPerPage: 10,
      } as GetQuaTrinhLamDuAnParams,
      searchParamsQuaTrinhHocTap: {
        itemsPerPage: 10,
      } as GetQuaTrinhHocTapParams,
      totalItems: 0 as number | undefined,
      chonSao: 4,
      isUpdate: false,
      search: "",
      dialogChonSao: false,
      dialogXoaQuaTrinhHocTap: false,
      dialogXoaQuaTrinhLamDuAn: false,
      dialogXoaBangCapChungChi: false,
      id: 0 as number,
      idUngVien: 0,
      HOST: process.env.VUE_APP_ROOT_API,
      headersQuaTrinhHocTap: [
        {
          text: "#",
          align: "center",
          sortable: false,
          value: "STT",
        },
        { text: "Từ năm", value: "TuNam", align: "center" },
        { text: "Đến năm", value: "DenNam", align: "center" },
        { text: "Học tại", value: "HocTai", align: "center" },
        { text: "Chuyên ngành", value: "ChuyenNganh", align: "center" },
        { text: "Thao tác", value: "ThaoTac", align: "center" },
      ],
      dsQuaTrinhHocTap: [
        // {
        //   STT: "1",
        //   TuNam: "15/09/2016",
        //   DenNam: "09/12/2020",
        //   HocTai: "Học Viện Kỹ Thuật Quân Sự",
        //   ChuyenNganh: "Công nghệ phần mềm",
        //   //iron: "1%",
        // },
      ] as QuaTrinhHocTapDTO[],
      headersQuaTrinhLamDuAn: [
        {
          text: "#",
          align: "center",
          sortable: false,
          value: "STT",
        },
        { text: "Từ năm", value: "TuNam", align: "center" },
        { text: "Đến năm", value: "DenNam", align: "center" },
        { text: "Công ty", value: "CongTy", align: "center" },
        { text: "Vị trí", value: "ViTri", align: "center" },
        { text: "Mô tả ngắn dự án", value: "MoTaNganDuAn", align: "center" },
        { text: "Kỹ năng", value: "KyNang", align: "center" },
        { text: "Thao tác", value: "ThaoTac", align: "center" },
      ],
      dsQuaTrinhLamDuAn: [
        // {
        //   STT: "Frozen Yogurt",
        //   TuNam: 159,
        //   DenNam: 6.0,
        //   CongTy: 24,
        //   ViTri: 4.0,
        //   MoTaNganDuAn: "abc",
        //   KyNang: "C#",
        //   //iron: "1%",
        // },
      ] as QuaTrinhLamDuAnDTO[],
      headersBangCapChungChi: [
        {
          text: "#",
          align: "center",
          sortable: false,
          value: "STT",
        },
        { text: "Tên bằng", value: "TenBang", align: "center" },
        { text: "Ngày cấp", value: "NgayCap", align: "center" },
        { text: "Thao tác", value: "ThaoTac", align: "center" },
      ],
      dsBangCapChungChi: [
        {
          STT: "Frozen Yogurt",
          TenBang: 159,
          NgayCap: 6.0,
          //iron: "1%",
        },
      ],
    };
  },
  created() {
    this.getUngVien();
    this.getQuaTrinhLamDuAn(this.searchParamsQuaTrinhLamDuAn);
    //this.getCVUngVienID(this.id);
    if (this.$route.params.ungVienId != undefined) {
      this.idUngVien = parseInt(this.$route.params.ungVienId);
      this.getUngVienID(this.idUngVien);
    }
    //this.getLichHocCaNhan();
    //this.getDsTruongDaiHoc();
    //this.getTinhThanh();
  },

  methods: {
    XacNhanXoaQuaTrinhHocTap(item: any): void {
      this.selected = item;
      this.dialogXoaQuaTrinhHocTap = true;
    },
    getQuaTrinhHocTap(
      searchParamsQuaTrinhHocTap: GetQuaTrinhHocTapParams
    ): void {
      this.loading = true;
      QuaTrinhHocTapApi.getQuaTrinhHocTap(searchParamsQuaTrinhHocTap)
        .then((res) => {
          this.dsQuaTrinhHocTap = res.data;
          this.totalItems = res.pagination.totalItems;
          this.loading = false;
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Get data failed!");
        });
    },
    deleteItemQuaTrinhHocTap(): void {
      this.deleting = true;
      // call api delete
      QuaTrinhHocTapApi.deleteQuaTrinhHocTap(this.selected.id)
        .then((res) => {
          this.$snotify.success("Xóa quá trình học tập thành công");
          this.getQuaTrinhHocTap(this.searchParamsQuaTrinhHocTap);
        })
        .catch((res) => {
          this.$snotify.error("Xóa quá trình học tập thất bại");
        });
      this.dialogXoaQuaTrinhHocTap = false;
      this.deleting = false;
    },
    XacNhanXoaQuaTrinhLamDuAn(item: any) {
      this.dialogXoaQuaTrinhLamDuAn = true;
    },
    getQuaTrinhLamDuAn(
      searchParamsQuaTrinhLamDuAn: GetQuaTrinhLamDuAnParams
    ): void {
      this.loading = true;
      QuaTrinhLamDuAnApi.getQuaTrinhLamDuAn(searchParamsQuaTrinhLamDuAn)
        .then((res) => {
          this.dsQuaTrinhLamDuAn = res.data;
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
      QuaTrinhLamDuAnApi.deleteQuaTrinhLamDuAn(this.selected.id)
        .then((res) => {
          this.$snotify.success("Xóa quá trình làm dự án thành công");
          this.getQuaTrinhLamDuAn(this.searchParamsQuaTrinhLamDuAn);
        })
        .catch((res) => {
          this.$snotify.error("Xóa quá trình làm dự án thất bại");
        });
      this.dialogXoaQuaTrinhLamDuAn = false;
      this.deleting = false;
    },
    XacNhanXoaBangCapChungChi(item: any) {
      this.dialogXoaBangCapChungChi = true;
    },
    ShowModalThemSuaQuaTrinhHocTap(isUpdate: boolean, item: any) {
      (this.$refs.modalThemSuaQuaTrinhHocTap as any).show(isUpdate, item);
    },
    ShowModalThemSuaQuaTrinhLamDuAn(isUpdate: boolean, item: any) {
      (this.$refs.modalThemSuaQuaTrinhLamDuAn as any).show(isUpdate, item);
    },
    ShowModalThemSuaBangCapChungChi(isUpdate: boolean, item: any) {
      (this.$refs.modalThemSuaBangCapChungChi as any).show(isUpdate, item);
    },
    // getQuanHuyen(id: number) {
    //   this.searchParamsQuanHuyen.tinhThanhId = id;
    //   QuanHuyenApi.getQuanHuyen(this.searchParamsQuanHuyen)
    //     .then((response) => {
    //       this.dsQuanHuyen = response.data;
    //     })
    //     .catch((err) => {
    //       this.$snotify.error("Lây dữ liệu thất bại!");
    //     });
    // },
    // getXaPhuong(id: number) {
    //   this.searchParamsXaPhuong.quanHuyenId = id;
    //   XaPhuongApi.getXaPhuong(this.searchParamsXaPhuong)
    //     .then((response) => {
    //       this.dsXaPhuong = response.data;
    //     })
    //     .catch((err) => {
    //       this.$snotify.error("Lây dữ liệu thất bại!");
    //     });
    // },
    getUngVien() {
      UngVienApi.getThongTinUngVien1()
        .then((res) => {
          this.ungVien = res;
          // if (res.tinhThanhId != null && res.tinhThanhId != null)
          //   this.getQuanHuyen(res.tinhThanhId);
          // if (res.quanHuyenId != null && res.quanHuyenId != null)
          //   this.getXaPhuong(res.quanHuyenId);
        })
        .catch((res) => {
          this.$snotify.error("Lấy thông tin học viên thất bại!");
        });
    },
    save() {
      this.$validator.validateAll("frmAddEdit").then((res) => {
        if (res) {
          if (
            this.ungVien.bietQuaGioiThieu == true &&
            (this.ungVien.tenNguoiGioiThieu == null ||
              this.ungVien.tenNguoiGioiThieu.trim() == "")
          )
            this.$snotify.error("Vui lòng điền tên người giới thiệu!");
          else {
            //this.ungVien.lichHoc = this.lichHocCaNhan;
            UngVienApi.updateThongTinCaNhanUngVien(
              this.ungVien.id,
              this.ungVien
            )
              .then((res) => {
                this.$snotify.success("Cập nhật thông tin cá nhân thành công!");
              })
              .catch((err) => {
                this.$snotify.error("Cập nhật thông tin cá nhân thất bại!");
              });
          }
        } else this.$snotify.error("Vui lòng điền đủ thông tin!");
      });
    },
    getUngVienID(id: number) {
      UngVienApi.getUngVienById(id)
        .then((res) => {
          this.ungVien = res;
        })
        .catch((res) => {
          this.$snotify.error("Lấy dữ liệu thông tin thất bại!");
        });
    },
  },
});
</script>
<style scoped></style>
