<template>
  <v-dialog v-model="dialog" max-width="400" scrollable persistent>
    <v-card>
      <v-card-title class="primary px-4 py-2 white--text">
        <h4>Thêm chi tiết công việc</h4>
        <v-spacer></v-spacer>
        <v-btn
          class="white--text ma-0"
          small
          @click.native="hide"
          icon
          dark
        >
          <v-icon>close</v-icon>
        </v-btn>
      </v-card-title>
      <v-card-text class="px-6 py-4">
        <v-form v-model="valid" scope="frmAddEdit">
          <v-row>
            <v-col cols="12" class="pt-3 pl-md-0">
              <v-text-field
                v-model="chiTietCongViec.tenChiTietCongViec"
                class="mt-0 pt-0"
                label="Tên chi tiết công việc"
                :error-messages="errors.collect('Tên chi tiết công việc', 'frmAddEdit')"
                v-validate="'required'"
                data-vv-scope="frmAddEdit"
                data-vv-name="Tên chi tiết công việc"
              ></v-text-field>
            </v-col>
            <v-col cols="12" class="py-0 pl-md-0">
              <v-datepicker
                v-model="chiTietCongViec.ngayHetHan"
                class="mt-0 pt-0"
                :max="congViec.ngayHetHan"
                label="Ngày hết hạn"
                :error-messages="errors.collect('Ngày hết hạn', 'frmAddEdit')"
                v-validate="'required'"
                data-vv-scope="frmAddEdit"
                data-vv-name="Ngày hết hạn"
              ></v-datepicker>
            </v-col>
          </v-row>
        </v-form>
      </v-card-text>
      <v-card-actions class="px-4 pb-4">
        <v-spacer></v-spacer>
        <v-btn class="primary px-4" @click.native="save" :loading="loading"
          >Thêm mới</v-btn
        >
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import { ChiTietCongViecDTO } from "@/models/ChiTietCongViecDTO";
import ChiTietCongViecApi from "@/apiResources/ChiTietCongViecApi";
import { CongViecDTO } from "@/models/CongViecDTO";
import CongViecApi, { GetCongViecParams } from "../../apiResources/CongViecApi";

export default Vue.extend({
  components: {},
  data() {
    return {
      valid: false,
      loading: false,
      dialog: false,
      chiTietCongViec: {} as ChiTietCongViecDTO,
      congViecId: 0 as number,
      congViec: {} as CongViecDTO,
    };
  },
  methods: {
    show(congViecId: number) {
      this.dialog = true;
      this.congViecId = congViecId;
      this.getCongViecById(congViecId);
    },
    hide() {
      this.dialog = false;
      this.chiTietCongViec = {} as ChiTietCongViecDTO;
      this.$emit("updated");
    },
    getCongViecById(congViecId: number) {
      CongViecApi.getCongViecById(congViecId)
        .then((response) => {
          this.congViec = response;
        })
        .catch((response) => {
          this.$snotify.error("Lây dữ liệu công việc thất bại!");
        });
    },
    save() {
      this.$validator.validateAll("frmAddEdit").then((res) => {
        if (res) {
          this.loading = true;
          this.chiTietCongViec.congViecId = this.congViecId;
          this.chiTietCongViec.trangThaiId = 1;
          ChiTietCongViecApi.createChiTietCongViec(this.chiTietCongViec)
            .then((res) => {
              this.loading = false;
              this.$snotify.success("Thêm mới thành công!");
              this.hide();
            })
            .catch((res) => {
              this.loading = false;
              this.$snotify.error(res.response.data.Errors.join(", "));
            });
        }
      });
    },
  },
});
</script>
