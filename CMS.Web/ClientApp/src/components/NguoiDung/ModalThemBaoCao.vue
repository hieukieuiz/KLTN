<template>
  <v-dialog v-model="dialog" max-width="600" scrollable persistent>
    <v-card style="height=800px">
      <v-card-title class="title primary py-1 px-2 white--text">
        <h3>Lịch sử chi tiết công việc</h3>
        <v-spacer></v-spacer>
        <v-btn class="white--text ma-0" small @click.native="hide" icon dark>
          <v-icon>close</v-icon>
        </v-btn>
      </v-card-title>
      <v-card-text>
        <v-layout row wrap>
          <v-card-text class="px-6">
            <v-form scope="frmAddEdit">
              <v-row>
                <v-col cols="12">
                  <p
                    v-for="(item, index) in dSLichSuChiTietCongViec"
                    :key="index"
                  >
                    Ngày
                    <span style="font-weight:bold;font-size:15px;">{{
                      formatDate(item.ngayCapNhat)
                    }}</span>
                    ,<span style="font-weight:bold;font-size:15px;">{{
                      item.thanhVienDuAn.hocVien.hoTen
                    }}</span>
                    <span v-if="item.thuTu != 1">
                      đã cập nhật trạng thái
                      <span style="font-weight:bold;font-size:15px;">{{
                        item.trangThai.tenTrangThai
                      }}</span>
                      cho chi tiết
                    </span>
                    <span v-if="item.thuTu == 1"> đã tạo ra </span>
                    <span style="font-weight:bold;font-size:15px;">{{
                      item.chiTietCongViec.tenChiTietCongViec
                    }}</span>
                  </p>
                  <v-divider dark color="gray" class="mt-2"></v-divider>
                </v-col>
              </v-row>
              <v-row>
                <v-col cols="12" class="pb-0">
                  <div
                    class="mb-3 d-flex justify-space-between"
                    v-for="(item, index) in dSBaoCao"
                    :key="index"
                  >
                    <!-- <v-row>
                      <v-col cols="2" class="text-left pt-0"> -->
                        <v-avatar size="36px"
                          ><img
                            alt="Avatar"
                            src="static/img/anhdaidienmacdinh.jpeg"
                        /></v-avatar>
                      <!-- </v-col> -->
                      <v-col
                      cols="11"
                      class="pb-1"
                        style="background:#f0f2f5;border-radius:20px;"
                      >
                        <span style="font-weight:bold;font-size:15px;">
                          {{ item.thanhVienDuAn.hocVien.hoTen }}
                        </span>
                        <span class="ml-2" style="font-size:13px;color:#5e6c84;">{{formatDate(item.thoiGianTao)}}</span>
                        <p class="mb-0" style="color:#172B4D;">{{ item.noiDung }}</p>
                      </v-col>
                    <!-- </v-row> -->
                  </div>
                </v-col>
                <v-col cols="12" class="pt-0">
                  <div
                    class="mb-3 d-flex justify-space-between "
                  >
                  <v-avatar size="36px" class="mt-3"
                          >
                          <img
                            alt="Avatar"
                            src="static/img/anhdaidienmacdinh.jpeg"/>
                  </v-avatar>
                  <v-col cols="10" class="pt-0">
                    <v-textarea
                      class="pt-0"
                      auto-grow
                      dense
                      rows="1"
                      placeholder="Nhập vào bình luận..."
                      v-model="baoCao.noiDung"
                      rounded
                    >
                    </v-textarea>
                  </v-col>
                  <v-col cols="1" class="text-left pl-0 pt-4">
                      <v-btn @click="themBaoCao()" fab dark small color="blue">
                        <v-icon>send</v-icon>
                      </v-btn>
                    </v-col>
                  </div>
                </v-col>
              </v-row>
            </v-form>
          </v-card-text>
        </v-layout>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import LichSuChiTietCongViecApi, {
  GetLichSuChiTietCongViecParams,
} from "@/apiResources/LichSuChiTietCongViecApi";
import { LichSuChiTietCongViecDTO } from "@/models/LichSuChiTietCongViecDTO";
import BaoCaoApi, { GetBaoCaoParams } from "@/apiResources/BaoCaoApi";
import { BaoCaoDTO } from "@/models/BaoCaoDTO";
export default Vue.extend({
  components: {},
  data() {
    return {
      dialog: false,
      loading: false,
      totalItems: 0 as number | undefined,
      isUpdate: false,
      dSLichSuChiTietCongViec: [] as LichSuChiTietCongViecDTO[],
      filtersLSCTCV: { itemsPerPage: -1 } as GetLichSuChiTietCongViecParams,
      dSBaoCao: [] as BaoCaoDTO[],
      filtersBaoCao: { itemsPerPage: -1 } as GetBaoCaoParams,
      baoCao: {} as BaoCaoDTO,
      chiTietCongViecId: 0 as number,
    };
  },
  methods: {
    show(item: any) {
      this.dialog = true;
      this.chiTietCongViecId = item.id;
      this.filtersLSCTCV.chiTietCongViecId = item.id;
      this.getLichSuChiTietCongViec(this.filtersLSCTCV);
      this.filtersBaoCao.chiTietCongViecId = item.id;
      this.getBaoCao(this.filtersBaoCao);
    },

    hide() {
      this.dialog = false;
      this.baoCao = {} as BaoCaoDTO;
    },
    getLichSuChiTietCongViec(filters: GetLichSuChiTietCongViecParams) {
      LichSuChiTietCongViecApi.getLichSuChiTietCongViec(filters)
        .then((response) => {
          this.dSLichSuChiTietCongViec = response.data;
        })
        .catch((err) => {
          this.$snotify.error(
            "Lây dữ liệu lịch sử chi tiết công việc thất bại!"
          );
        });
    },
    getBaoCao(filters: GetBaoCaoParams) {
      BaoCaoApi.getBaoCaoByChiTietCongViecId(filters)
        .then((response) => {
          this.dSBaoCao = response.data;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu báo cáo thất bại!");
        });
    },
    themBaoCao() {
      this.loading = true;
      this.baoCao.chiTietCongViecId = this.chiTietCongViecId;
      BaoCaoApi.createBaoCao(this.baoCao)
        .then((res) => {
          this.loading = false;
          this.getBaoCao(this.filtersBaoCao);
          this.baoCao = {} as BaoCaoDTO;
        })
        .catch((res) => {
          this.$snotify.error("Thêm thất bại!");
          this.loading = false;
        });
    },
    formatDate(date: Date) {
      if (!date) {
        return "Không xác định";
      } else return this.$moment(date).format("DD/MM/YYYY HH:mm");
    },
  },
});
</script>
