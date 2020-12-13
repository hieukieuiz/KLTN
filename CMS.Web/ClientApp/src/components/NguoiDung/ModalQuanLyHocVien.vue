<template>
  <v-dialog v-model="dialog" max-width="700" scrollable persistent>
    <v-card>
      <v-card-title class="primary px-4 py-2 white--text">
        <h3>{{isUpdate ? 'Cập nhật học viên' : 'Thêm học viên'}}</h3>
        <v-spacer></v-spacer>
        <v-btn class="white--text ma-0" small @click.native="dialog = false" icon dark>
          <v-icon>close</v-icon>
        </v-btn>
      </v-card-title>
      <v-card-text class="px-6 py-4">
        <v-form v-model="valid" scope="frmAddEdit">
          <v-row>
            <v-col cols="12" md="4" class="py-1 pl-md-0">
              <v-text-field
                v-model="hocVien.hoTen"
                label="Họ tên"
                :error-messages="errors.collect('Họ tên', 'frmAddEdit')"
                v-validate="'required'"
                data-vv-scope="frmAddEdit"
                data-vv-name="Họ tên"
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="4" class="py-1 pl-md-0">
              <v-text-field
                label="Tài khoản"
                v-model="hocVien.account"
                required
                :error-messages="errors.collect('Tài khoản', 'frmAddEdit')"
                v-validate="'required|email'"
                data-vv-scope="frmAddEdit"
                data-vv-name="Tài khoản"
                @input="onTaiKhoanChanged"
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="4" class="py-1 pl-md-0">
              <v-datepicker
                v-model="hocVien.ngaySinh"
                :error-messages="errors.collect('Ngày sinh', 'frmAddEdit')"
                v-validate="''"
                data-vv-scope="frmAddEdit"
                data-vv-name="Ngày sinh"
                label="Ngày sinh"
              ></v-datepicker>
            </v-col>
            <v-col cols="12" md="2" class="py-1 pl-md-0">
              <v-text-field
                v-model="hocVien.sdt"
                label="Số điện thoại"
                :error-messages="errors.collect('Số điện thoại', 'frmAddEdit')"
                v-validate="'min:9'"
                data-vv-scope="frmAddEdit"
                data-vv-name="Số điện thoại"
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="5" class="py-1 pl-md-0">
              <v-text-field
                v-model="hocVien.email"
                :error-messages="errors.collect('Email', 'frmAddEdit')"
                v-validate="'required|email'"
                data-vv-scope="frmAddEdit"
                data-vv-name="Email"
                label="Địa chỉ Email"
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="3" class="py-1 pl-md-0">
              <v-autocomplete
                :items="dsTinhThanh"
                v-model="hocVien.tinhThanhId"
                item-text="tenTinhThanh"
                item-value="id"
                clearable
                :error-messages="errors.collect('Tỉnh thành', 'frmAddEdit')"
                v-validate="'required'"
                data-vv-scope="frmAddEdit"
                data-vv-name="Tỉnh thành"
                label="Tỉnh Thành"
              ></v-autocomplete>
            </v-col>
          </v-row>
        </v-form>
      </v-card-text>
      <v-card-actions class="px-4 pb-4">
        <v-spacer></v-spacer>
        <v-btn
          class="primary px-4"
          @click.native="save"
          :loading="loading"
        >{{isUpdate?'Cập nhật':'Thêm mới'}}</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import { HocVienDTO } from "../../models/HocVienDTO";
import ModalThemSuaDangKyHoc from "./ModalThemSuaDangKyHoc.vue";
import ModalThemSuaTrangThaiHocVien from "./ModalThemSuaTrangThaiHocVien.vue";
import HocVienApi from "../../apiResources/HocVienApi";
import { TinhThanhDTO } from "../../models/TinhThanhDTO";
import TinhThanhApi from "../../apiResources/TinhThanhApi";
export default Vue.extend({
  components: {},
  data() {
    return {
      valid: false,
      dialog: false,
      loading: false,
      isUpdate: false,
      hocVien: {} as HocVienDTO,
      dialogConfirmDelete: false,
      dsTinhThanh: [] as TinhThanhDTO[],
      HOST: process.env.VUE_APP_ROOT_API
    };
  },
  methods: {
    show(isUpdate: boolean, item: any) {
      this.isUpdate = isUpdate;
      this.hocVien = item;
      this.dialog = true;
      this.getTinhThanh();
      if (isUpdate) {
        this.getHocVien(item.id);
        console.log(this.hocVien);
      }
    },
    hide() {
      this.dialog = false;
    },
    getHocVien(hocVienId: number) {
      HocVienApi.getHocVienById(hocVienId)
        .then(res => {
          this.hocVien = res;
        })
        .catch(res => {
          this.$snotify.error("Lấy thông tin học viên thất bại!");
        });
    },
    save() {
      this.$validator.validateAll("frmAddEdit").then(res => {
        if (res) {
          if (this.isUpdate) {
            this.loading = true;
            HocVienApi.updateHocVien(this.hocVien.id, this.hocVien)
              .then(res => {
                this.$emit("updated");
                this.$snotify.success("Cập nhật thành công!");
                this.loading = false;
                this.hide();
              })
              .catch(res => {
                this.$snotify.error("Cập nhật thất bại!");
                this.loading = false;
              });
          } else {
            this.loading = true;
            HocVienApi.createHocVien(this.hocVien)
              .then(res => {
                this.$emit("updated");
                this.$snotify.success("Thêm thành công!");
                this.loading = false;
                this.hide();
              })
              .catch(res => {
                this.$snotify.error("Thêm thất bại!");
                this.loading = false;
              });
          }
        }
      });
    },
    getTinhThanh() {
      TinhThanhApi.getTinhThanh({ itemsPerPage: -1 })
        .then(response => {
          this.dsTinhThanh = response.data;
        })
        .catch(err => {
          this.$snotify.error("Lây dữ liệu tỉnh thành thất bại!");
        });
    },
    onTaiKhoanChanged(account: any) {
      if (!this.isUpdate) {
        this.hocVien.email = account;
      }
    }
  }
});
</script>