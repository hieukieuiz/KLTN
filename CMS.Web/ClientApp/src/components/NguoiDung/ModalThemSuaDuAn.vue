<template>
  <v-dialog v-model="dialog" max-width="800" scrollable persistent>
    <v-card>
      <v-card-title class="title primary py-1 px-2 white--text">
        <h3>{{isUpdate ? 'Cập nhật nhóm việc ' : 'Thêm nhóm việc'}}</h3>
        <v-spacer></v-spacer>
        <v-btn class="white--text ma-0" small @click.native="dialog = false" icon dark>
          <v-icon>close</v-icon>
        </v-btn>
      </v-card-title>
      <v-card-text class="pt-4">
        <v-layout row wrap>
          <v-card-text class="px-6 py-4">
            <v-form v-model="valid" scope="frmAddEdit">
              <v-row>
                <v-col cols="12" md="12" class="mt-0 mb-0 pb-0 pl-md-0">
                  <v-text-field
                    v-model="duAn.tenDuAn"
                    label="Tên nhóm việc"
                    :error-messages="errors.collect('Tên nhóm việc', 'frmAddEdit')"
                    v-validate="'required'"
                    data-vv-scope="frmAddEdit"
                    data-vv-name="Tên nhóm việc"
                    class="pa-0 ma-0"
                  ></v-text-field>
                </v-col>
                <v-col cols="12" md="12" class="mt-0 pt-0 pb-0 pl-md-0">
                  <v-datepicker
                    v-model="duAn.thoiGianTao"
                    v-show="!isUpdate"
                    :error-messages="errors.collect('Thời gian tạo', 'frmAddEdit')"
                    v-validate="''"
                    data-vv-scope="frmAddEdit"
                    data-vv-name="Thời gian tạo"
                    label="Thời gian tạo"
                    class="pa-0 mt-0"
                  ></v-datepicker>
                </v-col>
                <v-col cols="12" md="12" class="py-0 pl-md-0">
                  <v-datepicker
                    v-model="duAn.thoiGianHetHan"
                    :error-messages="errors.collect('Thời gian hết hạn', 'frmAddEdit')"
                    v-validate="''"
                    data-vv-scope="frmAddEdit"
                    data-vv-name="Thời gian hết hạn"
                    label="Thời gian hết hạn"
                  ></v-datepicker>
                </v-col>
                <v-col cols="12" md="12" class="pt-1 pb-0 pl-md-0">
                  <v-textarea
                    v-model="duAn.moTa"
                    :error-messages="errors.collect('Mô tả', 'frmAddEdit')"
                    v-validate="''"
                    data-vv-scope="frmAddEdit"
                    data-vv-name="Mô tả"
                    label="Mô tả"
                  ></v-textarea>
                </v-col>
              </v-row>
            </v-form>
          </v-card-text>
        </v-layout>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          class="primary "
          @click.native="save"
          :loading="loading"
        >{{isUpdate?'Cập nhật':'Thêm mới'}}</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import { DuAnDTO } from "../../models/DuAnDTO";
import DuAnApi from "../../apiResources/DuAnApi";
export default Vue.extend({
  components: {},
  data() {
    return {
      isUpdate: false,
      dialog: false,
      loading: false,
      locked: false,
      duAn: {} as DuAnDTO,
      valid: false,
    };
  },
  methods: {
    show(isUpdate: boolean, item: any) {
      this.dialog = true;
      this.isUpdate = isUpdate;
      this.duAn = item;
      if (isUpdate) {
        this.getDuAn(item.id);
      }
    },
    hide() {
      this.dialog = false;
    },
    getDuAn(duAnId: number) {
      DuAnApi.getDuAnById(duAnId)
        .then((res) => {
          this.duAn = res;
        })
        .catch((res) => {
          this.$snotify.error("Lấy thông tin dự án thất bại!");
        });
    },
    save() {
      this.$validator.validateAll("frmAddEdit").then((res) => {
        if (res) {
          if (this.isUpdate) {
            this.loading = true;
            DuAnApi.updateDuAn(this.duAn.id, this.duAn)
              .then((res) => {
                this.loading = false;
                this.$snotify.success("Cập nhật thành công!");
                this.$emit("updated");
                this.hide();
              })
              .catch((res) => {
                this.loading = false;
                this.$snotify.error("Cập nhật thất bại!");
              });
          } else {
            this.loading = true;
            DuAnApi.createDuAn(this.duAn)
              .then((res) => {
                this.loading = false;
                this.$snotify.success("Thêm mới thành công!");
                this.$emit("updated");
                this.hide();
              })
              .catch((res) => {
                this.loading = false;
                this.$snotify.error(res.response.data.Errors.join(", "));
              });
          }
        }
      });
    },
    formatDate(date: Date) {
      if (!date) {
        return "Không xác định";
      } else return this.$moment(date).format("DD/MM/YYYY");
    },
  },
});
</script>.