<template>
  <v-layout row nowrap>
    <v-flex xs12 class="pl-0">
      <v-breadcrumbs class="px-0 py-0"
        ><v-btn outlined color="primary" small @click.prevent="back"
          ><v-icon small>arrow_back_ios</v-icon>Quay lại</v-btn
        ></v-breadcrumbs
      >
    </v-flex>
    <v-card width="100%" style="padding: 20px">
      <h1>{{ TieuDe }}</h1>
      <p v-html="noiDung"></p>
    </v-card>
  </v-layout>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";

import DoanhNghiepApi, {
  GetDoanhNghiepParams,
} from "@/apiResources/Interview/DoanhNghiepApi";
import BaiTuyenDungApi, {
  GetBaiTuyenDungParams,
} from "@/apiResources/Interview/BaiTuyenDungApi";
// import ThongTinApi, { GetThongTinParams } from '@/apiResources/ThongTinApi';

export default Vue.extend({
  data() {
    return {
      idDoanhNghiep: 0,
      idBaiTuyenDung: 0,
      //idThongTin: 0,
      TieuDe: "",
      noiDung: "",
    };
  },
  created() {
    // if (this.$route.params.doanhNghiepId != undefined) {
    //   this.idDoanhNghiep = parseInt(this.$route.params.doanhNghiepId);
    //   this.getDoanhNghiep(this.idDoanhNghiep);
    // }
    if (this.$route.params.baiTuyenDungId != undefined) {
      this.idBaiTuyenDung = parseInt(this.$route.params.baiTuyenDungId);
      this.getBaiTuyenDung(this.idBaiTuyenDung);
    }
  },
  methods: {
    getBaiTuyenDung(id: number) {
      BaiTuyenDungApi.getBaiTuyenDungById(id).then((res) => {
        this.TieuDe = res.tieuDe;
        this.noiDung = res.gioiThieu;
      });
    },
    // getDoanhNghiep(id: number) {
    //   DoanhNghiepApi.getDoanhNghiepById(id).then((res) => {
    //     this.TieuDe = "Giới thiệu về doanh nghiệp " + res.tenDoanhNghiep;
    //     this.noiDung = res.gioiThieu;
    //   });
    // },
    back() {
      this.$router.go(-1);
    },
  },
});
</script>
