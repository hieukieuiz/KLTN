<template>
  <v-dialog v-model="dialog" max-width="390" persistent>
    <v-card>
      <v-card-title class="px-4">
        {{ isUpdate ? "Cập nhật " : "Thêm mới " }}
        <v-spacer></v-spacer>
        <v-btn class="ma-0" small @click="hide" icon light>
          <v-icon>close</v-icon>
        </v-btn>
      </v-card-title>
      <v-card-text class="px-4 py-0">
        <v-row>
          <v-col cols="12" class="mt-0 pb-0">
            <v-text-field
              v-model="kyNang.tenKyNang"
              :error-messages="errors.collect('Tên kỹ năng', 'frmAddEdit')"
              v-validate="'required'"
              data-vv-scope="frmAddEdit"
              data-vv-name="Tên kỹ năng"
              label="Tên kỹ năng"
            ></v-text-field>
          </v-col>
        </v-row>
      </v-card-text>
      <v-card-actions class="pa-4">
        <v-btn
          :loading="loading"
          outlined
          block
          class="blue white--text"
          @click.native="save"
          >{{ isUpdate ? "Cập nhật" : "Thêm" }}</v-btn
        >
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script lang="ts">
import { Vue } from "vue-property-decorator";
import NhomKyNangApi, {
  GetNhomKyNangParams,
} from "@/apiResources/Interview/NhomKyNangApi";
import { NhomKyNangDTO } from "@/models/Interview/NhomKyNangDTO";
import KyNangApi, { GetKyNangParams } from "@/apiResources/Interview/KyNangApi";
import { KyNangDTO } from "@/models/Interview/KyNangDTO";
export default Vue.extend({
  components: {},
  data() {
    return {
      isUpdate: false,
      dialog: false,
      loading: false,
      kyNang: {} as KyNangDTO,
    };
  },
  methods: {
    hide() {
      this.dialog = false;
    },
    show(isUpdate: boolean, item: any) {
      this.$validator.errors.clear();
      this.dialog = true;
      this.isUpdate = isUpdate;
      this.kyNang = item;
    },
    save(): void {
      this.$validator.validateAll("frmAddEdit").then((res) => {
        if (res) {
          this.loading = true;
          if (this.isUpdate) {
            KyNangApi.updateKyNang(this.kyNang.id, this.kyNang)
              .then((res) => {
                this.loading = false;
                this.$snotify.success("Cập nhật thành công!");
                this.hide();
                this.$emit("getLaiDs");
              })
              .catch((res) => {
                this.loading = false;
                this.$snotify.error("Cập nhật thất bại!");
              });
          } else {
            KyNangApi.createKyNang(this.kyNang)
              .then((res) => {
                this.loading = false;
                this.$snotify.success("Thêm mới thành công!");
                this.hide();
                this.$emit("getLaiDs");
              })
              .catch((res) => {
                this.loading = false;
                this.$snotify.error("Thêm mới thất bại!");
              });
          }
        }
      });
    },
  },
});
</script>
