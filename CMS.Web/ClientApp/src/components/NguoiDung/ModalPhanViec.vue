<template>
  <v-dialog v-model="dialog" max-width="400" scrollable persistent>
    <v-card>
      <v-card-title class="primary px-4 py-2 white--text">
        <h4>Thêm phân việc</h4>
        <v-spacer></v-spacer>
        <v-btn
          class="white--text ma-0"
          small
          @click.native="dialog = false"
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
              <v-autocomplete
                  v-model="phanViec.thanhVienDuAnId"
                  :items="dSThanhVienDuAn"
                  item-value="id"
                  item-text="hocVien.hoTen"
                  clearable
                  class="pt-0"
                  label="Thành viên:"
                  placeholder="Chọn độ thành viên"
                ></v-autocomplete>
            </v-col>
          </v-row>
        </v-form>
      </v-card-text>
      <v-card-actions class="px-4 pb-4">
        <v-spacer></v-spacer>
        <v-btn class="primary px-4" @click.native="save" :loading="loading">Thêm mới</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import { PhanViecDTO } from "@/models/PhanViecDTO";
import PhanViecApi from '@/apiResources/PhanViecApi';
import { ThanhVienDuAnDTO } from "@/models/ThanhVienDuAnDTO";
import ThanhVienDuAnApi, {
  GetThanhVienDuAnParams,
} from "../../apiResources/ThanhVienDuAnApi";

export default Vue.extend({
  components: {},
  data() {
    return {
     valid:false,
     loading:false,
     dialog:false,
     phanViec:{} as PhanViecDTO,
     congViecId:0 as number,
     filtersThanhVienDuAn: { itemsPerPage: 25 } as GetThanhVienDuAnParams,
     dSThanhVienDuAn:[] as ThanhVienDuAnDTO[],
     totalItemsTVDA: 0 as number | undefined,
    };
  },
  methods: {
    show(congViecId:number,duAnId:number){
      this.dialog=true;
      this.congViecId=congViecId;
      this.filtersThanhVienDuAn.duAnId = duAnId;
      this.getThanhVienDuAn(this.filtersThanhVienDuAn);
      this.phanViec={} as PhanViecDTO;
    },
    hide(){
      this.dialog=false;
    },
    getThanhVienDuAn(filters: GetThanhVienDuAnParams) {
      ThanhVienDuAnApi.getThanhVienDuAn(filters)
        .then((response) => {
          this.dSThanhVienDuAn = response.data;
          this.totalItemsTVDA = response.pagination.totalItems;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu thành viên dự án thất bại!");
        });
    },
    save() {
      this.$validator.validateAll("frmAddEdit").then((res) => {
            this.loading = true;
            this.phanViec.congViecId=this.congViecId;
            PhanViecApi.createPhanViec(this.phanViec)
              .then((res) => {
                this.loading = false;
                this.$snotify.success("Thêm mới thành công!");
                this.$emit("updated");
                this.hide();
                
              })
              .catch((res) => {
                this.$snotify.error("Thêm thất bại!");
                this.loading = false;
              });
          })
        },
  }
});
</script>