<template>
  <v-row justify="center">
    <v-dialog v-model="isShow" persistent max-width="600px">
      <v-card>
        <v-card-title class="headline primary">
          {{
            isUpdate
              ? "Cập nhật quá trình làm dự án"
              : "Thêm mới quá trình làm dự án"
          }}
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="6">
                <v-datepicker
                  label="Từ năm"
                  v-model="quaTrinhLamDuAn.thoiGianBatDau"
                  :error-messages="errors.collect('Từ năm', 'frmAddEdit')"
                  v-validate="'required'"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Từ năm"
                ></v-datepicker>
              </v-col>
              <v-col cols="6">
                <v-datepicker
                  label="Đến năm"
                  v-model="quaTrinhLamDuAn.thoiGianKetThuc"
                  :error-messages="errors.collect('Đến năm', 'frmAddEdit')"
                  v-validate="'required'"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Đến năm"
                ></v-datepicker>
              </v-col>
              <v-col cols="6">
                <v-autocomplete
                  label="Công ty"
                  v-model="quaTrinhLamDuAn.doanhNghiepId"
                  :error-messages="errors.collect('Tên công ty', 'frmAddEdit')"
                  v-validate="'required'"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Tên công ty"
                  @change="getQuaTrinhLamDuAn(quaTrinhLamDuAn)"
                  :items="dsDoanhNghiep"
                  item-text="tenDoanhNghiep"
                  item-value="id"
                ></v-autocomplete>
              </v-col>
              <v-col cols="6">
                <v-text-field
                  label="Vị trí"
                  v-model="quaTrinhLamDuAn.viTri"
                  :error-messages="errors.collect('Vị trí', 'frmAddEdit')"
                  v-validate="'required'"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Vị trí"
                ></v-text-field>
              </v-col>
              <v-col cols="6">
                <v-textarea
                  label="Mô tả ngắn dự án"
                  v-model="quaTrinhLamDuAn.moTaNganDuAn"
                  :error-messages="
                    errors.collect('Mô tả ngắn dự án', 'frmAddEdit')
                  "
                  v-validate="'required'"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Mô tả ngắn dự án"
                ></v-textarea>
              </v-col>
              <v-col cols="6">
                <v-autocomplete
                  label="Kỹ năng"
                  v-model="quaTrinhLamDuAn.kyNangId"
                  hide-details
                  :items="dsKyNang"
                  item-value="kyNangId"
                  item-text="tenKyNang"
                  placeholder="Chọn kỹ năng"
                  persistent-hint
                  clearable
                  :error-messages="errors.collect('Kỹ năng', 'frmAddEdit')"
                  v-validate="'required'"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Kỹ Năng"
                  multiple
                ></v-autocomplete>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="isShow = false">
            Hủy
          </v-btn>
          <v-btn color="blue darken-1" text @click="isShow = false">
            {{ isUpdate ? "Cập nhật" : "Thêm mới" }}
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
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
import KyNangApi, { GetKyNangParams } from "@/apiResources/Interview/KyNangApi";
import { KyNangDTO } from "@/models/Interview/KyNangDTO";
import DoanhNghiepApi, {
  GetDoanhNghiepParams,
} from "@/apiResources/Interview/DoanhNghiepApi";
import { DoanhNghiepDTO } from "@/models/Interview/DoanhNghiepDTO";
export default Vue.extend({
  data: () => ({
    isShow: false,
    isUpdate: false,
    loading: false,
    quaTrinhLamDuAn: {} as QuaTrinhLamDuAnDTO,
    dsKyNang: [] as KyNangDTO[],
    dsDoanhNghiep: [] as DoanhNghiepDTO[],
  }),
  methods: {
    hide(): void {
      this.isShow = false;
    },
    show(isUpdate: boolean, item: any): void {
      this.isShow = true;
      this.isUpdate = isUpdate;
      this.quaTrinhLamDuAn = item;
      this.getKyNang();
      this.getDoanhNghiep();
      if (isUpdate) {
        //this.getQuaTrinhLamDuAn(item.id);
        this.getQuaTrinhLamDuAnID(item.id);
        console.log(this.quaTrinhLamDuAn);
      }
    },
    getQuaTrinhLamDuAnID(id: number) {
      QuaTrinhLamDuAnApi.getQuaTrinhLamDuAnById(id)
        .then((res) => {
          this.quaTrinhLamDuAn = res;
        })
        .catch((res) => {
          this.$snotify.error("Lấy dữ liệu quá trình làm dự án thất bại!");
        });
    },
    // getQuaTrinhLamDuAn(quaTrinhLamDuAnId: number) {
    //   QuaTrinhLamDuAnApi.getQuaTrinhLamDuAnById(quaTrinhLamDuAnId)
    //     .then((res) => {
    //       this.quaTrinhLamDuAn = res;
    //     })
    //     .catch((res) => {
    //       this.$snotify.error("Lấy thông tin quá trình làm dự án thất bại!");
    //     });
    // },
    getKyNang() {
      KyNangApi.getKyNang({ itemsPerPage: -1 })
        .then((response) => {
          this.dsKyNang = response.data;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu kỹ năng thất bại!");
        });
    },
    getDoanhNghiep() {
      DoanhNghiepApi.getDoanhNghiep({ itemsPerPage: -1 })
        .then((response) => {
          this.dsDoanhNghiep = response.data;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu doanh nghiệp thất bại!");
        });
    },
    save() {
      this.$validator.validateAll("frmAddEdit").then((res) => {
        if (res) {
          if (this.isUpdate) {
            this.loading = true;
            QuaTrinhLamDuAnApi.updateQuaTrinhLamDuAn(
              this.quaTrinhLamDuAn.id,
              this.quaTrinhLamDuAn
            )
              .then((res) => {
                this.$emit("updated");
                this.$snotify.success("Cập nhật thành công!");
                this.loading = false;
                this.hide();
                this.$emit("getLaiDs");
              })
              .catch((res) => {
                this.$snotify.error("Cập nhật thất bại!");
                this.loading = false;
              });
          } else {
            this.loading = true;
            QuaTrinhLamDuAnApi.createQuaTrinhLamDuAn(this.quaTrinhLamDuAn)
              .then((res) => {
                this.$emit("updated");
                this.$snotify.success("Thêm thành công!");
                this.loading = false;
                this.hide();
                this.$emit("getLaiDs");
              })
              .catch((res) => {
                this.$snotify.error("Thêm thất bại!");
                this.loading = false;
              });
          }
        }
      });
    },
  },
});
</script>
