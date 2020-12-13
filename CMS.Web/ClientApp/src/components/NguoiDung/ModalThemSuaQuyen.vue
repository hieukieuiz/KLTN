<template>
  <v-dialog v-model="dialog" max-width="800" scrollable persistent>
    <v-card>
      <v-card-title class="title primary py-1 px-2 white--text">
        <h3>{{isUpdate ? 'Cập nhật quyền ' : 'Thêm quyền'}}</h3>
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
                v-model="quyen.tenQuyen"
                label="Tên quyền"
                :error-messages="errors.collect('Tên quyền', 'frmAddEdit')"
                v-validate="'required'"
                data-vv-scope="frmAddEdit"
                data-vv-name="Tên quyền"
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
import { DuAnDTO } from "../../models/DuAnDTO";
import DuAnApi from "../../apiResources/DuAnApi";
import { QuyenDTO } from '@/models/QuyenDTO';
import QuyenApi, {GetQuyenParams} from '../../apiResources/QuyenApi';
export default Vue.extend({
  components: {},
  data() {
    return {
      isUpdate: false,
      dialog: false,
      loading: false,
      locked: false,
      duAn:{} as DuAnDTO,
      valid:false,
      quyen:{} as QuyenDTO

    };
  },
  methods: {
    show(isUpdate: boolean, item: any) {
      this.dialog = true;
      this.isUpdate = isUpdate;
      this.quyen = item;
      if (isUpdate) {
         this.getQuyen(item.id);
      }
    },
    hide() {
      this.dialog = false;
    },
    getQuyen(quyenId: number) {
      QuyenApi.getQuyenById(quyenId)
        .then(res => {
          this.quyen= res;
        })
        .catch(res => {
          this.$snotify.error("Lấy thông tin dự án thất bại!");
        });
    },
    save() {
      this.$validator.validateAll("frmAddEdit").then(res => {
        if (res) {
          if (this.isUpdate) {
            this.loading = true;
            QuyenApi.updateQuyen(this.quyen.id, this.quyen)
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
            QuyenApi.createQuyen(this.quyen)
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