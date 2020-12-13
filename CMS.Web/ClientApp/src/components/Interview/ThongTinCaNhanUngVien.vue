<template>
  <v-container class="thongtincanhan-page px-1 px-md-2 py-1">
    <v-card class="mt-3">
      <v-card-text class="pb-0">
        <v-layout row wrap>
          <v-flex xs12 class="d-flex justify-center">
            <p
              class="mb-0 mb-md-9 mt-3"
              style="font-size:22px; font-weight:bold; color:#050505"
            >
              Thông tin cá nhân
            </p>
          </v-flex>
          <v-layout rowwrap class=" mr-3">
            <v-flex md3 xs12 class="text-center my-4 mt-md-3 pr-md-2 mr-3">
              <v-tooltip bottom>
                <template v-slot:activator="{ on }">
                  <v-img
                    v-on="on"
                    class="grey lighten-2"
                    :src="
                      HOST + '/api/fileupload/download/' + ungVien.linkAnhCaNhan
                    "
                    @click="$refs.inpFile.click()"
                    aspect-ratio="0.75"
                    contain
                  ></v-img>
                </template>
                <span>Click để thay đổi ảnh đại diện</span>
              </v-tooltip>
              <input
                type="file"
                accept="image/*"
                style="display:none;"
                ref="inpFile"
                id="inpFile"
                @change="changePhoto"
              />
            </v-flex>
            <v-flex md9 xs12>
              <v-form v-model="valid" scope="frmAddEdit">
                <v-layout row wrap>
                  <v-flex xs12 md4>
                    <v-text-field
                      v-model="ungVien.hoTen"
                      label="Họ tên (*)"
                      :error-messages="errors.collect('Họ tên', 'frmAddEdit')"
                      v-validate="'required'"
                      data-vv-scope="frmAddEdit"
                      data-vv-name="Họ tên"
                    ></v-text-field>
                  </v-flex>
                  <v-flex xs12 md4>
                    <v-datepicker
                      v-model="ungVien.ngaySinh"
                      :error-messages="
                        errors.collect('Ngày sinh', 'frmAddEdit')
                      "
                      v-validate="'required'"
                      data-vv-scope="frmAddEdit"
                      data-vv-name="Ngày sinh"
                      label="Ngày sinh (*)"
                    ></v-datepicker>
                  </v-flex>
                  <v-flex xs12 md4 class="mt-0">
                    <v-text-field
                      v-model="ungVien.sdt"
                      label="Số điện thoại (*)"
                      :error-messages="
                        errors.collect('Số điện thoại', 'frmAddEdit')
                      "
                      v-validate="'required|min: 9'"
                      data-vv-scope="frmAddEdit"
                      data-vv-name="Số điện thoại"
                    ></v-text-field>
                  </v-flex>
                  <v-flex xs12 md6>
                    <v-autocomplete
                      label="Trường CĐ/ĐH (*)"
                      v-model="ungVien.truongDaiHocId"
                      :search-input.sync="searchTruongDaiHoc"
                      :items="dsTruongDaiHoc"
                      item-text="tenTruongDaiHoc"
                      item-value="id"
                      :error-messages="
                        errors.collect('Trường đại học', 'frmAddEdit')
                      "
                      v-validate="'required'"
                      data-vv-scope="frmAddEdit"
                      data-vv-name="Trường đại học"
                      clearable
                    ></v-autocomplete>
                  </v-flex>
                  <v-flex xs12 md4>
                    <v-text-field
                      v-model="ungVien.tenKhoa"
                      label="Tên Khoa"
                      clearable
                    ></v-text-field>
                  </v-flex>
                  <v-flex xs12 md2>
                    <v-autocomplete
                      v-model="ungVien.namThu"
                      :items="namDaiHoc"
                      item-text="name"
                      item-value="id"
                      label="Năm thứ"
                    ></v-autocomplete>
                  </v-flex>
                  <!-- <v-flex xs12 md4>
                    <v-text-field
                      v-model="hocVien.cmtnd"
                      label="Số CMTND/TCCCD (*)"
                      :error-messages="errors.collect('CMTND', 'frmAddEdit')"
                      v-validate="'required|min: 9'"
                      data-vv-scope="frmAddEdit"
                      data-vv-name="CMTND"
                    ></v-text-field>
                  </v-flex>
                  <v-flex xs12 md4 class="text-center pb-5">
                    Tải ảnh mặt trước/sau
                    <br />
                    <v-icon v-if="hocVien.linkAnhMatTruoc" small color="success" class="mr-1">check</v-icon>
                    <v-icon v-else small color="error" class="mr-1">error</v-icon>
                    <v-menu open-on-hover :close-on-content-click="false" offset-y bottom>
                      <template v-slot:activator="{ on }">
                        <a v-on="on" @click="$refs.inpFile1.click()">mặt trước</a>
                      </template>
                      <img
                        style="max-width: 500px"
                        :src="HOST + '/api/fileupload/download/' + hocVien.linkAnhMatTruoc"
                      />
                    </v-menu>/
                    <input
                      type="file"
                      accept="image/*"
                      style="display:none;"
                      ref="inpFile1"
                      id="inpFile1"
                      @change="changePhoto1"
                    />

                    <v-icon v-if="hocVien.linkAnhMatSau" small color="success" class="mr-1">check</v-icon>
                    <v-icon v-else small color="error" class="mr-1">error</v-icon>
                    <v-menu open-on-hover :close-on-content-click="false" offset-y bottom>
                      <template v-slot:activator="{ on }">
                        <a v-on="on" @click="$refs.inpFile2.click()">mặt sau</a>
                      </template>
                      <img
                        style="max-width: 500px"
                        :src="HOST + '/api/fileupload/download/' + hocVien.linkAnhMatSau"
                      />
                    </v-menu>
                    <input
                      type="file"
                      accept="image/*"
                      style="display:none;"
                      ref="inpFile2"
                      id="inpFile2"
                      @change="changePhoto2"
                    />
                  </v-flex>-->
                  <v-flex xs12 md6>
                    <v-text-field
                      v-model="ungVien.email"
                      :error-messages="errors.collect('Email', 'frmAddEdit')"
                      v-validate="'required'"
                      data-vv-scope="frmAddEdit"
                      data-vv-name="Email"
                      label="Địa chỉ Gmail"
                    ></v-text-field>
                  </v-flex>
                  <v-flex xs12 md6>
                    <v-text-field
                      v-model="ungVien.linkFaceBook"
                      label="Link Facebook cá nhân"
                    ></v-text-field>
                  </v-flex>
                  <v-flex xs12 md6>
                    <v-text-field
                      v-model="ungVien.linkSkype"
                      label="Skype"
                    ></v-text-field>
                  </v-flex>
                  <v-flex xs12 md6>
                    <v-text-field
                      v-model="ungVien.linkZalo"
                      label="Zalo"
                    ></v-text-field>
                  </v-flex>
                  <v-flex xs12 md3>
                    <v-autocomplete
                      :items="dsTinhThanh"
                      v-model="ungVien.tinhThanhId"
                      label="Tỉnh thành"
                      item-text="tenTinhThanh"
                      item-value="id"
                      @input="changeTinhThanh(ungVien.tinhThanhId)"
                      clearable
                      :error-messages="
                        errors.collect('Tỉnh thành', 'frmAddEdit')
                      "
                      v-validate="'required'"
                      data-vv-scope="frmAddEdit"
                      data-vv-name="Tỉnh thành"
                    ></v-autocomplete>
                  </v-flex>
                  <v-flex xs12 md3>
                    <v-autocomplete
                      :items="dsQuanHuyen"
                      v-model="ungVien.quanHuyenId"
                      label="Quận huyện"
                      item-text="tenQuanHuyen"
                      item-value="id"
                      @input="changeQuanHuyen(ungVien.quanHuyenId)"
                      clearable
                      :error-messages="
                        errors.collect('Quận huyện', 'frmAddEdit')
                      "
                      v-validate="'required'"
                      data-vv-scope="frmAddEdit"
                      data-vv-name="Quận huyện"
                    ></v-autocomplete>
                  </v-flex>
                  <v-flex xs12 md3>
                    <v-autocomplete
                      :items="dsXaPhuong"
                      v-model="ungVien.xaPhuongId"
                      label="Xã phường"
                      item-text="tenXaPhuong"
                      item-value="id"
                      clearable
                      :error-messages="
                        errors.collect('Xã phường', 'frmAddEdit')
                      "
                      v-validate="'required'"
                      data-vv-scope="frmAddEdit"
                      data-vv-name="Xã phường"
                    ></v-autocomplete>
                  </v-flex>
                  <v-flex xs12 md3>
                    <v-text-field
                      v-model="ungVien.diaChi"
                      label="Số nhà"
                    ></v-text-field>
                  </v-flex>
                  <v-flex xs12 class="py-0 pl-md-2">
                    <h4>Biết HVIT Clan qua:</h4>
                  </v-flex>
                  <v-flex xs12 md2 class="pb-3">
                    <v-checkbox
                      class="mt-0"
                      label="FaceBook"
                      hide-details
                      v-model="ungVien.bietQuaFaceBook"
                    ></v-checkbox>
                  </v-flex>
                  <v-flex xs12 md2 class="pb-3">
                    <v-checkbox
                      class="mt-0"
                      label="Website"
                      hide-details
                      v-model="ungVien.bietQuaWeb"
                    ></v-checkbox>
                  </v-flex>
                  <v-flex xs12 md3 class="pb-3">
                    <v-checkbox
                      hide-details
                      class="mt-0"
                      v-model="ungVien.bietQuaGioiThieu"
                      label="Người giới thiệu"
                    ></v-checkbox>
                  </v-flex>
                  <v-flex xs12 md5 class="pb-2">
                    <v-text-field
                      v-model="ungVien.tenNguoiGioiThieu"
                      v-if="ungVien.bietQuaGioiThieu"
                      label="Tên người giới hiệu"
                      hide-details
                      class="mt-md-0"
                    ></v-text-field>
                  </v-flex>
                </v-layout>
              </v-form>
            </v-flex>
          </v-layout>
          <!-- <v-flex xs12>
            <p class="mt-3" style="font-size:16px;">
              <b>Thời gian đi học (*)</b>
              (đảm bảo tối thiểu 4 ca/tuần):
            </p>
            <table style="empty-cells:hide;" cellpadding="1">
              <tr>
                <th>Buổi</th>
                <th
                  v-for="(item, index) in lichHocTrungTam"
                  :key="index"
                  style=" text-align: center;"
                >
                  {{ item.name }}
                </th>
              </tr>
              <tr>
                <td class="text-center">Sáng</td>
                <td
                  v-for="(item, index) in lichHocTrungTam"
                  :key="index"
                  style="vertical-align: middle;"
                  class="text-center"
                >
                  <v-checkbox
                    hide-details
                    class="mt-0 py-2 d-inline-block"
                    :value="getTrangThaiCaHoc(item.id, CA_SANG)"
                    @change="dangKyHocChanged($event, item.id, CA_SANG)"
                  ></v-checkbox>
                </td>
              </tr>
              <tr>
                <td class="text-center">Chiều</td>
                <td
                  v-for="(item, index) in lichHocTrungTam"
                  :key="index"
                  style="text-align: center; vertical-align: middle;"
                >
                  <v-checkbox
                    hide-details
                    class="mt-0 py-2 d-inline-block"
                    :value="getTrangThaiCaHoc(item.id, CA_CHIEU)"
                    @change="dangKyHocChanged($event, item.id, CA_CHIEU)"
                  ></v-checkbox>
                </td>
              </tr>
              <tr>
                <td class="text-center">Tối</td>
                <td
                  v-for="(item, index) in lichHocTrungTam"
                  :key="index"
                  style="text-align: center; vertical-align: middle;"
                >
                  <v-checkbox
                    hide-details
                    class="mt-0 py-2 d-inline-block"
                    :value="getTrangThaiCaHoc(item.id, CA_TOI)"
                    @change="dangKyHocChanged($event, item.id, CA_TOI)"
                  ></v-checkbox>
                </td>
              </tr>
            </table>
          </v-flex> -->
        </v-layout>
      </v-card-text>
      <v-card-actions class="pt-4 px-4 pb-3">
        <v-spacer></v-spacer>
        <v-btn color="primary" width="120" @click="save">Cập nhật</v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>
<script lang="ts">
import { Vue } from "vue-property-decorator";
import { HTTP } from "@/HTTPServices";
//import UngVienApi, { GetUngVienParams } from "@/apiResources/UngVienApi";
import UngVienApi, {
  GetUngVienParams,
} from "@/apiResources/Interview/UngVienApi";
import FileUploadApi from "@/apiResources/FileUploadApi";
//import LichHocApi, { GetLichHocParams } from "@/apiResources/LichHocApi";
import { UngVienDTO } from "@/models/Interview/UngVienDTO";
//import { UngVienDTO } from "@/models/UngVienDTO";
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

export default Vue.extend({
  components: {},
  data() {
    return {
      valid: false,
      // CA_SANG: 1,
      // CA_CHIEU: 2,
      // CA_TOI: 3,
      ungVien: { quanHuyenId: 0 } as UngVienDTO,
      paramsUngVien: {
        includeEntities: true,
        rowsPerPage: 0,
      } as GetUngVienParams,
      // paramsLichHoc: {
      //   includeEntities: true,
      //   rowsPerPage: 0,
      // } as GetLichHocParams,
      checkbox: false,
      enabled: false,
      radioGroup: 1,
      switch1: true,
      menu: false,
      id: 0 as number,
      //lichHocCaNhan: [] as LichHocDTO[],
      dsTruongDaiHoc: [] as TruongDaiHocDTO[],
      dsTinhThanh: [] as TinhThanhDTO[],
      dsQuanHuyen: [] as QuanHuyenDTO[],
      dsXaPhuong: [] as XaPhuongDTO[],
      searchParamsTruongDaiHoc: { itemsPerPage: 0 } as GetTruongDaiHocParams,
      searchParamsTinhThanh: { itemsPerPage: 0 } as GetTinhThanhParams,
      searchParamsQuanHuyen: { itemsPerPage: 0 } as GetQuanHuyenParams,
      searchParamsXaPhuong: { itemsPerPage: 0 } as GetXaPhuongParams,
      searchTruongDaiHoc: "",
      HOST: process.env.VUE_APP_ROOT_API,
      // lichHocTrungTam: [
      //   { id: 2, name: "Thứ 2" },
      //   { id: 3, name: "Thứ 3" },
      //   { id: 4, name: "Thứ 4" },
      //   { id: 5, name: "Thứ 5" },
      //   { id: 6, name: "Thứ 6" },
      //   { id: 7, name: "Thứ 7" },
      // ] as any[],
      namDaiHoc: [
        { id: 1, name: 1 },
        { id: 2, name: 2 },
        { id: 3, name: 3 },
        { id: 4, name: 4 },
        { id: 5, name: 5 },
      ] as any[],
    };
  },
  created() {
    this.getUngVien();
    //this.getLichHocCaNhan();
    this.getDsTruongDaiHoc();
    this.getTinhThanh();
  },
  computed: {
    // caHocSang(): any {
    //   let danhSachCaHocSang = [] as LichHocDTO[];
    //   for (let i = this.lichHocCaNhan.length; i++; ) {
    //     if (this.lichHocCaNhan[i].ca === 1) {
    //       danhSachCaHocSang.push(this.lichHocCaNhan[i]);
    //     }
    //   }
    //   return danhSachCaHocSang;
    // },
  },
  methods: {
    getUngVien() {
      UngVienApi.getThongTinUngVien()
        .then((res) => {
          this.ungVien = res;
          if (res.tinhThanhId != null && res.tinhThanhId != null)
            this.getQuanHuyen(res.tinhThanhId);
          if (res.quanHuyenId != null && res.quanHuyenId != null)
            this.getXaPhuong(res.quanHuyenId);
        })
        .catch((res) => {
          this.$snotify.error("Lấy thông tin học viên thất bại!");
        });
    },
    changeTinhThanh(id: number) {
      if (id !== undefined) {
        this.ungVien.quanHuyenId = id;
        this.ungVien.xaPhuongId = id;
        this.ungVien.tinhThanhId = id;
        this.getQuanHuyen(id);
      }
    },
    changeQuanHuyen(id: number) {
      if (id !== undefined) {
        this.ungVien.quanHuyenId = id;
        this.ungVien.xaPhuongId = null as any;
        this.getXaPhuong(id);
      }
    },
    getDsTruongDaiHoc() {
      TruongDaiHocApi.getTruongDaiHoc(this.searchParamsTruongDaiHoc)
        .then((res) => {
          this.dsTruongDaiHoc = res.data;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu thất bại!");
        });
    },
    getTinhThanh() {
      TinhThanhApi.getTinhThanh(this.searchParamsTinhThanh)
        .then((response) => {
          this.dsTinhThanh = response.data;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu thất bại!");
        });
    },
    getQuanHuyen(id: number) {
      this.searchParamsQuanHuyen.tinhThanhId = id;
      QuanHuyenApi.getQuanHuyen(this.searchParamsQuanHuyen)
        .then((response) => {
          this.dsQuanHuyen = response.data;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu thất bại!");
        });
    },
    getXaPhuong(id: number) {
      this.searchParamsXaPhuong.quanHuyenId = id;
      XaPhuongApi.getXaPhuong(this.searchParamsXaPhuong)
        .then((response) => {
          this.dsXaPhuong = response.data;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu thất bại!");
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
    // changePhoto(): void {
    //   var formData = new FormData();
    //   let inpFile = document.querySelector("#inpFile") as any;
    //   formData.append("img", inpFile.files[0]);
    //   inpFile.value = null;
    //   FileUploadApi.upload(formData)
    //     .then((res) => {
    //       this.ungVien.linkAnhCaNhan = res.key;
    //     })
    //     .catch((res) => {
    //       this.$snotify.error("Upload ảnh thất bại!");
    //     });
    // },
    // changePhoto1(): void {
    //   var formData = new FormData();
    //   let inpFile = document.querySelector("#inpFile1") as any;
    //   formData.append("img", inpFile.files[0]);
    //   inpFile.value = null;
    //   FileUploadApi.upload(formData)
    //     .then((res) => {
    //       this.ungVien.linkAnhMatTruoc = res.key;
    //       this.$snotify.success("Upload ảnh thành công!");
    //     })
    //     .catch((res) => {
    //       this.$snotify.error("Upload ảnh thất bại!");
    //     });
    // },
    // changePhoto2(): void {
    //   var formData = new FormData();
    //   let inpFile = document.querySelector("#inpFile2") as any;
    //   formData.append("img", inpFile.files[0]);
    //   inpFile.value = null;
    //   FileUploadApi.upload(formData)
    //     .then((res) => {
    //       this.ungVien.linkAnhMatSau = res.key;
    //       this.$snotify.success("Upload ảnh thành công!");
    //     })
    //     .catch((res) => {
    //       this.$snotify.error("Upload ảnh thất bại!");
    //     });
    // },
    changePhoto(): void {
      var formData = new FormData();
      let inpFile = document.querySelector("#inpFile") as any;
      formData.append("img", inpFile.files[0]);
      inpFile.value = null;
      FileUploadApi.upload(formData)
        .then((res) => {
          this.ungVien.linkAnhCaNhan = res.key;
        })
        .catch((res) => {
          this.$snotify.error("Upload ảnh thất bại!");
        });
    },
    changePhoto1(): void {
      var formData = new FormData();
      let files = (document as any).querySelector("#inpFile1").files[0];
      var re = /^\w+\.(?:jpg|png|gif|jpeg)$/g;
      if (re.test(files.name)) {
        formData.append("img", files);
        FileUploadApi.upload(formData)
          .then((res) => {
            this.ungVien.linkAnhMatTruoc = res.key;
            this.$snotify.success("Upload ảnh thành công!");
          })
          .catch((res) => {
            this.$snotify.error("Upload ảnh thất bại!");
          });
      } else {
        this.$snotify.error("Tên file chỉ chứa ký tự chữ, số và ký tự `_`");
      }
    },
    changePhoto2(): void {
      var formData = new FormData();
      let files = (document as any).querySelector("#inpFile2").files[0];
      var re = /^\w+\.(?:jpg|png|gif|jpeg)$/g;
      if (re.test(files.name)) {
        formData.append("img", files);
        FileUploadApi.upload(formData)
          .then((res) => {
            this.ungVien.linkAnhMatSau = res.key;
            this.$snotify.success("Upload ảnh thành công!");
          })
          .catch((res) => {
            this.$snotify.error("Upload ảnh thất bại!");
          });
      } else {
        this.$snotify.error("Tên file chỉ chứa ký tự chữ, số và ký tự `_`");
      }
    },
  },
});
</script>
<style>
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td,
th {
  border: 1px solid #dddddd;
  text-align: center;
  padding: 1px;
}

.v-text-field {
  padding-top: 0px;
}
</style>
