<template>
  <v-container class="pa-2 pt-1 page-mykhoahoc">
    <v-layout row nowrap>
      <v-flex xs12>
        <!-- <v-breadcrumbs class="px-0 py-0" :items="breadcrumbs"></v-breadcrumbs> -->
        <p class="q-header mt-2 mb-1 ml-1">DANH SÁCH BÀI TUYỂN DỤNG</p>
      </v-flex>
      <v-flex v-if="loading" xs12 md4 class="pr-md-4">
        <v-sheet>
          <v-skeleton-loader
            class="mx-auto"
            tile
            type="image"
          ></v-skeleton-loader>
        </v-sheet>
      </v-flex>
      <v-flex
        v-else
        xs12
        md4
        class="pr-md-4"
        v-for="baiDang in danhSachBaiTuyenDung"
        :key="baiDang.id"
      >
        <v-hover>
          <template v-slot:default="{ hover }">
            <v-card
              height="220"
              class="align-center d-flex mb-3"
              :elevation="hover ? 6 : 2"
            >
              <v-card-text class="headline font-weight-bold text-center pa-0">
                <v-img
                  :src="HOST + '/api/fileupload/download/' + baiDang.anhDaiDien"
                  height="220"
                >
                  <v-layout
                    column
                    wrap
                    style="background: rgba(0,0,0, .5); margin-top:0px"
                    fill-height
                  >
                    <v-row class="pa-0">
                      <v-col
                        cols="12"
                        style="height:22px"
                        class="py-0 px-4 d-flex justify-end"
                      >
                        <!-- <v-menu bottom left transition="slide-y-transition">
                          <template v-slot:activator="{ on }">
                            <v-btn
                              small
                              fab
                              dark
                              icon
                              v-on="on"
                              class="mt-2 mr-2 btn-xemthem"
                            >
                              <v-icon size="26">mdi-dots-vertical</v-icon>
                            </v-btn>
                          </template>
                          <v-list>
                            <v-list-item
                              :to="
                                `/ungvien/danhsachbaidangtuyen/${baiDang.id}`
                              "
                            >
                              <v-list-item-title>Giới thiệu</v-list-item-title>
                            </v-list-item>
                          </v-list>
                        </v-menu> -->
                      </v-col>
                    </v-row>
                    <v-flex class="white--text text-center mx-6">
                      <div class="mb-3">{{ baiDang.tieuDe }}</div>
                      <v-btn
                        :to="'/ungvien/danhsachbaidangtuyen/' + baiDang.id"
                        color="blue"
                        dark
                        >Giới thiệu</v-btn
                      >
                    </v-flex>
                    <v-spacer></v-spacer>
                  </v-layout>
                </v-img>
              </v-card-text>
            </v-card>
          </template>
        </v-hover>
      </v-flex>
    </v-layout>
  </v-container>
</template>
<script lang="ts">
import { Vue } from "vue-property-decorator";
import BaiTuyenDungApi from "@/apiResources/Interview/BaiTuyenDungApi";
import { BaiTuyenDungDTO } from "@/models/Interview/BaiTuyenDungDTO";
import DoanhNghiepApi from "@/apiResources/Interview/DoanhNghiepApi";
import { DoanhNghiepDTO } from "@/models/Interview/DoanhNghiepDTO";
// import HocVienApi from "../../apiResources/HocVienApi";
// import { DangKyHocDTO } from "../../models/DangKyHocDTO";
// import ModalDangKyKhoaHoc from "./ModalDangKyKhoaHoc.vue";
// import ModalShowAnhMinhHoa from "./ModalShowAnhMinhHoa.vue";
// import { KhoaHocDTO } from "../../models/KhoaHocDTO";
export default Vue.extend({
  //components: { ModalDangKyKhoaHoc, ModalShowAnhMinhHoa },
  data() {
    return {
      HOST: process.env.VUE_APP_ROOT_API,
      //danhSachKhoaHoc: {} as DangKyHocDTO[],
      loading: false,
      danhSachBaiTuyenDung: {} as BaiTuyenDungDTO[],
      //danhSachKhoaHocChuaDangKy: {} as DangKyHocDTO[],
      //loadingKhoaHocChuaDangKy: false,
    };
  },
  computed: {
    breadcrumbs(): any {
      return [
        {
          text: "Danh sách bài tuyển dụng",
          disabled: true,
          href: "#/ungvien/danhsachbaidangtuyen",
          exact: true,
        },
      ];
    },
  },
  created() {
    this.getDanhSachBaiTuyenDung();
    //this.getDanhSachKhoaHocChuaDangKy();
  },
  methods: {
    getDanhSachBaiTuyenDung() {
      this.loading = true;
      DoanhNghiepApi.getDanhSachBaiTuyenDung({ itemsPerPage: -1 })
        .then((res) => {
          this.danhSachBaiTuyenDung = res.data;
          this.loading = false;
        })
        .catch((res) => {
          this.$snotify.error("Lấy danh sách bài tuyển dụng thất bại!");
        });
    },
    baiDang(baiDang: any) {
      console.log(baiDang);
    },
  },
});
</script>
<style>
element.style {
  width: 100px;
  height: 100px;
  margin-right: 20px;
}
.btn-xemthem {
  background-color: #9e9e9e;
}
</style>
