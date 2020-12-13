<template>
  <v-dialog v-model="dialog" max-width="900">
    <v-card>
      <v-card-title class="title primary py-1 px-2 white--text">
        {{ isUpdate ? "Cập nhật " : "Thêm mới " }}
        <v-spacer></v-spacer>
        <v-btn class="white--text ma-0" small @click="hide" icon dark
          ><v-icon>close</v-icon></v-btn
        >
      </v-card-title>
      <v-card-text>
        <v-layout row nowrap>
          <v-flex md12 xs12 class="mt-3 pa-2">
            <v-text-field
              v-model="trangThai.tenTrangThai"
              :error-messages="errors.collect('Tên trạng thái', 'frmAddEdit')"
              v-validate="'required'"
              data-vv-scope="frmAddEdit"
              data-vv-name="Tên trạng thái"
              label="Tên trạng thái"
            ></v-text-field>
          </v-flex>
        </v-layout>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          style="margin-top: -20px;"
          class="primary"
          @click.native="save"
          >{{ isUpdate ? "Cập nhật" : "Thêm mới" }}</v-btn
        >
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script lang="ts">
import { Vue } from "vue-property-decorator";
import TrangThaiApi, { GetTrangThaiParams } from "@/apiResources/TrangThaiApi";
import { TrangThaiDTO } from "@/models/TrangThaiDTO";

export default Vue.extend({
  components: {},
  data() {
    return {
      row: "all",
      isUpdate: false,
      dialog: false,
      loading: false,
      trangThai: {} as TrangThaiDTO,
      searchParamsTrangThai: {
        itemsPerPage: 10,
      } as GetTrangThaiParams,
      id: 0 as number,
    };
  },
  methods: {
    hide() {
      this.dialog = false;
    },
    show(isUpdate: boolean, id: number) {
      this.$validator.errors.clear();
      this.dialog = true;
      //              this.getDSMucThongTin();
      this.id = id;
      if (id > 0) {
        this.isUpdate = true;
        this.getTrangThaiID(id);
      } else {
        this.isUpdate = false;
        this.trangThai = {} as TrangThaiDTO;
      }
    },
    getTrangThaiID(id: number) {
      TrangThaiApi.getTrangThaiById(id)
        .then((res) => {
          this.trangThai = res;
        })
        .catch((res) => {
          this.$snotify.error("Lấy dữ liệu thông tin thất bại!");
        });
    },
    save(): void {
      this.$validator.validateAll("frmAddEdit").then((res) => {
        if (res) {
          this.loading = true;
          if (this.isUpdate) {
            TrangThaiApi.updateTrangThai(this.id, this.trangThai)
              .then((res) => {
                this.trangThai = res;
                this.loading = false;
                this.$snotify.success("Cập nhật thông tin thành công!");
                this.isUpdate = true;
                this.hide();
                this.$emit("getLaiDs");
              })
              .catch((res) => {
                this.loading = false;
                this.$snotify.error("Cập nhật thông tin thất bại!");
              });
          } else {
            TrangThaiApi.createTrangThai(this.trangThai)
              .then((res) => {
                this.trangThai = res;
                this.isUpdate = true;
                this.loading = false;
                this.$snotify.success("Thêm mới thông tin thành công!");
                this.hide();
                this.$emit("getLaiDs");
              })
              .catch((res) => {
                this.loading = false;
                this.$snotify.error("Thêm mới thông tin thất bại!");
              });
          }
        }
      });
    },
  },
});
</script>
