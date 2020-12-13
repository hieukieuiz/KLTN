<template>
  <div class="py-2" style="background:#0079bf;">
    <div class="pl-1 pr-4">
      <v-col id="search-bar" cols="12" class="d-flex align-center">
        <span
          style="font-size: 18px;font-weight: 700;color:#ffffff;"
          class="mr-2"
          >{{ duAn.tenDuAn }} |</span>
        <span dark @click="showModalThemNhanSu(duAn)" class="btnTrello mr-2">
          <v-icon size="20" style="color:#fff;">account_circle</v-icon>
          Nhân sự
        </span>
        <div class="search-bar mr-2">
          <input
            v-model="filtersTrangThaiDuAn.tenCongViec"
            @input="getTrangThaiDuAn(filtersTrangThaiDuAn)"
            type="text"
            class="search-input"
          />
          <button type="button" class="search-btn">
            <v-icon style="color:#fff;">search</v-icon>
          </button>
        </div>
        <v-menu offset-y>
          <template v-slot:activator="{ on, attrs }">
            <span
              id="searchByLoaiCV"
              class="search-bar mr-2 d-flex align-center pl-2"
              v-bind="attrs"
              v-on="on"
            >
              Tìm theo loại công việc
            </span>
          </template>
          <v-list>
            <v-list-item v-for="(item, index) in dSLoaiCongViec" :key="index">
              <v-list-item-title
                class="searchByLoaiCV"
                @click="searchTheoLCV(item.id)"
              >
                {{ item.tenLoaiCongViec }}
              </v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
        <v-tooltip right top>
          <template v-slot:activator="{ on }">
            <span
              v-if="!isOverdue(duAn.thoiGianHetHan) && !checkRoles(['HocVien'])"
              class="btnTrello pa-1"
              @click="showModalQuanLyCongViec(false,false, {}, duAnId)"
              v-on="on"
            >
              <v-icon color="#fff" size="25">add</v-icon>
            </span>
          </template>
          <span>Thêm Công Việc</span>
        </v-tooltip>
      </v-col>
    </div>
    <div class="d-flex mx-1" id="content">
      <div
        v-for="(item, index) in dSTrangThaiDuAn"
        :key="index"
        class="mx-1"
        style="width:272px;max-height:calc(100vh - 125px);"
      >

        <v-card
          width="272"
          class="text-left pb-1 pl-2"
          style="background:#ebecf0;"
        >
          <h5
            class="py-3 tenTrangThai"
          >
            {{ item.trangThai.tenTrangThai }}
          </h5>
         <perfect-scrollbar>
          <dragable
            v-model="item.trangThai.congViec"
            :disabled="isOverdue(duAn.thoiGianHetHan) || checkRoles(['HocVien'])"
            v-bind="dragOptions"
            class="list-group"
            :move="checkMove"
            @add="onAdd(item.trangThaiId)"
          >
            <div
              v-for="(congViec, index) in item.trangThai.congViec"
              :key="index"
              style="border-radius:5px;background:#ffffff;"
              class="text-left pa-2 pr-1 mb-2 card mr-2"
              
            >
              <div class="d-flex justify-space-between">
                  <span
                    :class="viewCongViec(congViec.isActive)"
                    @click="congViec.isActive?showModalQuanLyCongViec(true,true, congViec, duAnId):add($event)"
                  >
                    {{ congViec.tenCongViec }}
                  </span>
                  <v-menu v-if="!checkRoles(['HocVien'])" class="pb-5 pr-2">
                    <template v-slot:activator="{ on: menu, attrs }">
                      <v-btn
                        dark
                        v-bind="attrs"
                        v-on="{ ...menu }"
                        icon
                        class="black--text pb-5"
                        :disabled="
                          !congViec.isActive && checkRoles(['HocVien'])
                        "
                        >...</v-btn
                      >
                    </template>
                    <v-list>
                      <v-list-item
                        @click="showModalQuanLyCongViec(false,true, congViec, duAnId)"
                      >
                        <v-list-item-title style="font-size:14px;">{{
                          isOverdue(duAn.thoiGianHetHan) ||
                          checkRoles(["HocVien"])
                            ? "Xem"
                            : "Cập nhật"
                        }}</v-list-item-title>
                      </v-list-item>
                      <v-list-item
                        v-if="!checkRoles(['HocVien'])"
                        @click="confirmDelete(congViec)"
                      >
                        <v-list-item-title style="font-size:14px;"
                          >Xóa</v-list-item-title
                        >
                      </v-list-item>
                    </v-list>
                  </v-menu>
              </div>

              <div class="d-flex justify-space-between align-center">
                <span
                  v-if="!isOverdue(congViec.ngayHetHan) && congViec.isActive"
                  :class="colorNgayHetHan(congViec.doUuTien)"
                  style="font-size:12px;border-radius:3px;padding:3px 5px;"
                >
                <v-icon size="16" class="mr-1" color="#fff">mdi-alarm-check</v-icon>
                  {{ formatDate(congViec.ngayHetHan) }}
                </span>
                <span
                  v-if="isOverdue(congViec.ngayHetHan) && congViec.isActive"
                  class="red white--text d-flex align-center"
                  style="font-size:12px;border-radius:3px;padding:3px 5px;"
                >
                  Quá hạn</span
                >
                <span
                  v-if="!congViec.isActive"
                  class="red white--text d-flex align-center"
                  style="font-size:12px;border-radius:3px;padding:3px 5px;"
                >
                  Đã khóa</span
                >
                <span
                  v-if="congViec.soLuongChiTietCongViec!=0"
                  style="font-size:14px;" 
                  class="ml-2">
                  <v-icon size="20" color="green">mdi-checkbox-marked-outline</v-icon>
                  {{
                  congViec.soLuongChiTietCongViecHoanThanh +
                    "/" +
                    congViec.soLuongChiTietCongViec
                }}</span>
                <v-menu>
                  <template v-slot:activator="{ on: menu }">
                    <v-tooltip top>
                      <template v-slot:activator="{ on: tooltip }">
                        <v-btn
                          class="ml-2 mr-2 blue white--text"
                          @focus="showDSPhanViec(congViec.id)"
                          icon
                          small
                          dark
                          v-on="{ ...tooltip, ...menu }"
                        >
                          <v-icon size="20" style="color:#fff;"
                            >mdi-account-cog</v-icon
                          >
                        </v-btn>
                      </template>
                      <span>Xem danh sách người làm</span>
                    </v-tooltip>
                  </template>
                  <v-list class="py-0">
                    <v-list-item v-if="dSPhanViec.length == 0">
                      <v-list-item-title style="font-size:14px;"
                        >Chưa có người làm</v-list-item-title
                      >
                    </v-list-item>
                    <v-list-item
                      v-for="(phanViec, i) in dSPhanViec"
                      :key="i"
                      class="ma-0 py-1"
                      style="min-height:25px;"
                    >
                      <v-list-item-title style="font-size:14px;"
                        >{{ phanViec.thanhVienDuAn.hocVien.hoTen }}
                        <span
                          class="blue--text"
                          style="font-size:14px;"
                          v-show="i == 0"
                        >
                          (người làm chính)</span
                        >
                      </v-list-item-title>
                    </v-list-item>
                  </v-list>
                </v-menu>
              </div>
            </div>
          </dragable>
          </perfect-scrollbar>
        </v-card>
      </div>
    </div>
    <modal-quan-ly-cong-viec
      ref="modalQuanLyCongViec"
      @updated="getTrangThaiDuAn(filtersTrangThaiDuAn)"
    ></modal-quan-ly-cong-viec>
    <modal-them-sua-nhan-su
      ref="modalThemSuaNhanSu"
      @updatedQLCV="getThanhVienDuAn(filtersThanhVienDuAn)"
    ></modal-them-sua-nhan-su>
    <v-dialog v-model="dialogConfirmDelete" max-width="290">
      <v-card>
        <v-card-title class="headline">Xác nhận xóa</v-card-title>
        <v-card-text class="pt-3">Bạn có chắc chắn muốn xóa?</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn @click.native="dialogConfirmDelete = false" text>Hủy</v-btn>
          <v-btn
            :loading="loading"
            color="red darken-1"
            text
            @click="deleteCongViec"
            >Xác Nhận</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import ModalQuanLyCongViec from "./ModalQuanLyCongViec.vue";
import { Vue } from "vue-property-decorator";
import { LoaiCongViecDTO } from "@/models/LoaiCongViecDTO";
import LoaiCongViecApi, {
  GetLoaiCongViecParams,
} from "../../apiResources/LoaiCongViecApi";
import { TrangThaiDuAnDTO } from "@/models/TrangThaiDuAnDTO";
import TrangThaiDuAnApi, {
  GetTrangThaiDuAnParams,
} from "../../apiResources/TrangThaiDuAnApi";
import { CongViecDTO } from "@/models/CongViecDTO";
import CongViecApi, { GetCongViecParams } from "../../apiResources/CongViecApi";
import { DuAnDTO } from "@/models/DuAnDTO";
import DuAnApi, { GetDuAnParams } from "../../apiResources/DuAnApi";
import { ThanhVienDuAnDTO } from "@/models/ThanhVienDuAnDTO";
import ThanhVienDuAnApi, {
  GetThanhVienDuAnParams,
} from "../../apiResources/ThanhVienDuAnApi";
import { PhanViecDTO } from "@/models/PhanViecDTO";
import PhanViecApi, { GetPhanViecParams } from "../../apiResources/PhanViecApi";
import dragable from "vuedraggable";
import ModalThemSuaNhanSu from "./ModalThemSuaNhanSu.vue";
import UserApi from "../../apiResources/UserApi";
import { PerfectScrollbar } from 'vue2-perfect-scrollbar';

export default Vue.extend({
  components: {
    dragable,
    ModalQuanLyCongViec,
    ModalThemSuaNhanSu,
    PerfectScrollbar,
  },
  data() {
    return {
      loading: false,
      dSLoaiCongViec: [] as LoaiCongViecDTO[],
      duAn: {} as DuAnDTO,
      duAnId: 0 as number,
      dSTrangThaiDuAn: [] as TrangThaiDuAnDTO[],
      filtersTrangThaiDuAn: { itemsPerPage: 25 } as GetTrangThaiDuAnParams,
      totalItemsTTDA: 0 as number | undefined,
      dSCongViec: [] as CongViecDTO[],
      filtersCongViec: { itemsPerPage: 25 } as GetCongViecParams,
      dSThanhVienDuAn: [] as ThanhVienDuAnDTO[],
      filtersThanhVienDuAn: { itemsPerPage: 25 } as GetThanhVienDuAnParams,
      totalItemsTVDA: 0 as number | undefined,
      filtersPhanViec: { itemsPerPage: 25 } as GetPhanViecParams,
      dSPhanViec: [] as PhanViecDTO[],
      totalItemsPV: 0 as number | undefined,
      dialogConfirmDelete: false,
      congViecSelected: {} as CongViecDTO,
      congViecChanged: {} as CongViecDTO,
      today: new Date(),
      displaySearch: false,
      displaySearchLCV: false,
      dsRole: [] as any[],
      settings: {
        suppressScrollY: true,
        suppressScrollX: false,
        wheelPropagation: false,
      },
    };
  },
  created() {
    this.getDSLoaiCongViec();
    this.duAnId = parseInt(this.$route.params.duAnId);
    this.getDuAnById(this.duAnId);
    this.filtersTrangThaiDuAn.duAnId = this.duAnId;
    this.getTrangThaiDuAn(this.filtersTrangThaiDuAn);
    this.filtersThanhVienDuAn.duAnId = this.duAnId;
    this.getThanhVienDuAn(this.filtersThanhVienDuAn);
  },
  mounted() {
    this.getRoles();
  },
  methods: {
    searchTheoLCV(loaiCongViecId: number) {
      this.filtersTrangThaiDuAn.loaiCongViecId = loaiCongViecId;
      this.getTrangThaiDuAn(this.filtersTrangThaiDuAn);
    },
    getDSLoaiCongViec() {
      LoaiCongViecApi.getLoaiCongViec({ itemsPerPage: -1 })
        .then((response) => {
          this.dSLoaiCongViec = response.data;
          this.dSLoaiCongViec.unshift({
            id: null as any,
            tenLoaiCongViec: "Chọn tất cả",
          });
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu loại công việc thất bại!");
        });
    },
    getTrangThaiDuAn(filters: GetTrangThaiDuAnParams) {
      TrangThaiDuAnApi.getTrangThaiDuAnByDuAnId(filters)
        .then((response) => {
          this.dSTrangThaiDuAn = response.data;
          this.totalItemsTTDA = response.pagination.totalItems;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu trạng thái dự án thất bại!");
        });
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
    getDuAnById(duAnId: number) {
      DuAnApi.getDuAnById(duAnId)
        .then((res) => {
          this.duAn = res;
        })
        .catch((res) => {
          this.$snotify.error("Lấy thông tin dự án thất bại!");
        });
    },
    formatDate(date: Date) {
      if (!date) {
        return "Không xác định";
      } else return this.$moment(date).format("DD/MM/YYYY");
    },
    showDSPhanViec(congViecId: number) {
      this.filtersPhanViec.congViecId = congViecId;
      this.getPhanViec(this.filtersPhanViec);
    },
    getPhanViec(filters: GetPhanViecParams) {
      PhanViecApi.getPhanViecByCongViecId(filters)
        .then((response) => {
          this.dSPhanViec = response.data;
          this.totalItemsPV = response.pagination.totalItems;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu phân việc thất bại!");
        });
    },
    confirmDelete(congViec: any): void {
      this.dialogConfirmDelete = true;
      this.congViecSelected = congViec;
    },
    deleteCongViec(): void {
      CongViecApi.deleteCongViec(this.congViecSelected.id)
        .then((res) => {
          this.dialogConfirmDelete = false;
          this.getTrangThaiDuAn(this.filtersTrangThaiDuAn);
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Xóa thất bại!");
        });
    },
    updateCongViec() {
      this.loading = true;
      CongViecApi.updateCongViec(this.congViecChanged.id, this.congViecChanged)
        .then((res) => {
          this.loading = false;
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Cập nhật thất bại!");
        });
    },
    showModalQuanLyCongViec(isView:boolean,isUpdate: boolean, item: any, duAnId: number) {
      (this.$refs.modalQuanLyCongViec as any).show(isView,isUpdate, item, duAnId);
    },
    showModalThemNhanSu(item: any) {
      (this.$refs.modalThemSuaNhanSu as any).show(item);
    },
    //code dragable
    checkMove: function(evt: any) {
      this.congViecChanged = evt.draggedContext.element;
    },
    onAdd(trangThaiId: number) {
      this.$set(this.congViecChanged, "trangThaiId", trangThaiId);
      this.updateCongViec();
    },
    //end code dragable
    colorNgayHetHan(doUuTien: string) {
      if (doUuTien == "bình thường") return "primary white--text d-flex align-center";
      else if (doUuTien == "cao") return "warning white--text d-flex align-center";
      else if (doUuTien == "rất cao") return "red white--text d-flex align-center";
    },
    viewCongViec(isActive:boolean){
      if(isActive) return "pb-2 congViecIsActive"
      return "pb-2 congViec"
      
    },
    isOverdue(date: Date) {
      return this.$moment(this.today).isAfter(date, "day");
    },
    hideInputSearch() {
      this.displaySearch = false;
      this.filtersTrangThaiDuAn.tenCongViec = "";
      this.getTrangThaiDuAn(this.filtersTrangThaiDuAn);
    },
    hideInputSearchLCV() {
      this.displaySearchLCV = false;
      this.filtersTrangThaiDuAn.loaiCongViecId = undefined;
      this.getTrangThaiDuAn(this.filtersTrangThaiDuAn);
    },
    getRoles() {
      UserApi.getMyRoles().then((res) => {
        this.dsRole = res;
        this.$store.commit("UPDATE_USER_ROLES", this.dsRole);
        this.$eventBus.$emit("updateRoles", this.dsRole);
      });
    },
    checkRole(role: any) {
      if (this.dsRole) {
        return this.dsRole.indexOf(role) !== -1;
      }
      return false;
    },
    checkRoles(roles: any) {
      if (this.dsRole) {
        for (let i = 0; i < roles.length; i++) {
          if (this.dsRole.indexOf(roles[i]) !== -1) return true;
        }
      }
      return false;
    },
    add(event:any) {
            event.target.disabled = true
        }
  },
  computed: {
    dragOptions() {
      return {
        animation: 200,
        group: "list",
        disabled: false,
        ghostClass: "ghost",
      };
    },
  },
});
</script>
<style>
.btnTrello {
  font-size: 14px;
  color: #fff;
  background: hsla(0, 0%, 100%, 0.24);
  padding: 7px;
  border-radius: 3px;
  cursor: pointer;
  padding-left: 7px;
  padding-right: 7px;
}
.btnTrello:hover {
  background: hsla(0, 0%, 100%, 0.32);
}
.search-bar {
  display: flex;
  width: 210px;
  height: 35.3px;
  background: hsla(0, 0%, 100%, 0.24);
  border-radius: 3px;
  color: #fff;
  font-size: 14px;
  cursor: pointer;
}
.search-bar:hover {
  background: hsla(0, 0%, 100%, 0.32);
}
.search-input {
  color: #fff;
  font-size: 14px;
  cursor: pointer;
  outline: 0;
  padding: 6px 10px;
}
.search-btn {
  margin-left: auto;
  margin-right: 6px;
  /* padding: 6px 10px; */
}
#content {
  overflow-x: auto;
  overflow-y: hidden;
  height: calc(100vh - 120px);
  /* max-height: calc(100vh - 120px); */
}
.ps {
  max-height: calc(100vh - 185px);
}
.card {
	z-index: 10;
  box-shadow: 0 1px 0 rgba(9,30,66,.25);
	}
.tenTrangThai{
  color:#172b4d;
  font-size:14px;
  font-weight:600;
}
.searchByLoaiCV{
  cursor: pointer;
}
.searchByLoaiCV:hover{
  color: #0079bf;
}
.congViecIsActive{
  color:#172b4d;
  font-size:14px;
  font-weight:500;
  cursor:pointer;
}
.congViecIsActive:hover{
  color: blue;
}
.congViec{
  color:#172b4d;
  font-size:14px;
  font-weight:500;
}
</style>
<style src="vue2-perfect-scrollbar/dist/vue2-perfect-scrollbar.css"/>

