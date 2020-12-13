<template>
  <v-dialog v-model="dialog" max-width="800" scrollable persistent>
    <v-card>
      <v-card-title class="title primary py-1 px-2 white--text">
        <h3>{{isUpdate ? 'Cập nhật loại công việc ' : 'Thêm loại công việc'}}</h3>
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
            <v-col cols="12" md="12" class="py-1 pl-md-0" >
              <v-text-field
                v-model="loaiCongViec.tenLoaiCongViec"
                label="Tên loại công việc"
                :error-messages="errors.collect('Tên loại công việc', 'frmAddEdit')"
                v-validate="'required'"
                data-vv-scope="frmAddEdit"
                data-vv-name="Tên loại công việc"
              ></v-text-field>
            </v-col>
          </v-row>
        </v-form>
      </v-card-text>
        </v-layout>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          class="primary"
          @click.native="save"
          :loading="loading"
        >{{isUpdate?'Cập nhật':'Thêm mới'}}</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import { LoaiCongViecDTO } from '@/models/LoaiCongViecDTO';
import LoaiCongViecApi, {GetLoaiCongViecParams} from '../../apiResources/LoaiCongViecApi';
export default Vue.extend({
  components: {},
  data() {
    return {
      isUpdate: false,
      dialog: false,
      loading: false,
      locked: false,
      valid:false,
      loaiCongViec:{} as LoaiCongViecDTO

    };
  },
  methods: {
    show(isUpdate: boolean, item: any) {
      this.dialog = true;
      this.isUpdate = isUpdate;
      this.loaiCongViec = item;
      if (isUpdate) {
         this.getLoaiCongViec(item.id);
      }
    },
    hide() {
      this.dialog = false;
    },
    getLoaiCongViec(loaiCongViecId: number) {
      LoaiCongViecApi.getLoaiCongViecById(loaiCongViecId)
        .then(res => {
          this.loaiCongViec= res;
        })
        .catch(res => {
          this.$snotify.error("Lấy thông tin loại công việc thất bại!");
        });
    },
    save() {
      this.$validator.validateAll("frmAddEdit").then(res => {
        if (res) {
          if (this.isUpdate) {
            this.loading = true;
            LoaiCongViecApi.updateLoaiCongViec(this.loaiCongViec.id, this.loaiCongViec)
              .then(res => {
                this.loading = false;
                this.$snotify.success("Cập nhật thành công!");
                this.$emit("updated");
                this.hide();
              })
              .catch(res => {
                this.loading = false;
                this.$snotify.error("Cập nhật thất bại!");
              });
          } else {
            this.loading = true;
            LoaiCongViecApi.createLoaiCongViec(this.loaiCongViec)
              .then(res => {
                this.loading = false;
                this.$snotify.success("Thêm mới thành công!");
                this.$emit("updated");
                this.hide();
              })
              .catch(res => {
                this.loading = false;
                this.$snotify.error(res.response.data.Errors.join(", "));
              });
          }
        }
      });
    },
  }
});
</script>.