<template>
  <div>
    <v-dialog v-model="dialog" max-width="800" scrollable persistent>
      <v-card>
        <v-card-title class="primary px-4 py-2 white--text">
          <h3 v-if="!isOverdue(duAn.thoiGianHetHan) && !isView">{{ isUpdate ? "Cập nhật công việc" : "Thêm công việc" }}</h3>
          <h3 v-else-if="isOverdue(duAn.thoiGianHetHan)">Chi tiết công việc</h3>
          <h3 v-else-if="isView">Quản lý chi tiết công việc</h3>
          <v-spacer></v-spacer>
          <v-btn
            class="white--text ma-0"
            small
            @click.native="hide()"
            icon
            dark
          >
            <v-icon>close</v-icon>
          </v-btn>
        </v-card-title>
        <v-card-text class="px-6 py-4">
          <v-form v-model="valid" scope="frmAddEdit">
            <v-row>
              <v-col v-if="isUpdate" cols="12" class="pb-1 pt-0 pl-md-0">
                <v-row>
                  <v-col cols="10" class="py-0 d-flex align-center">
                    <span style="font-size:17px;color:black;font-weight:400;">Chi tiết công việc:</span>
                  </v-col>
                  <v-col cols="2" class="text-right py-0">
                    <v-tooltip top>
                      <template v-slot:activator="{ on }">
                        <v-btn
                          v-if="!checkRoles(['HocVien'])"
                          @click="showModalChiTietCongViec(congViec.id)"
                          color="blue"
                          icon
                          v-on="on"
                          :disabled="isOverdue(congViec.ngayHetHan)"
                        >
                          <v-icon size="45">add_circle</v-icon>
                        </v-btn>
                      </template>
                      <span>Thêm chi tiết công việc</span>
                    </v-tooltip>
                  </v-col>
                  <v-col cols="12">
                  <v-row class="py-0">
                    <v-col style="height:40px;" class="py-0 d-flex align-center" cols="12" v-for="(item,index) in dSChiTietCongViec" :key="index">
                      <v-flex md1>
                        <v-checkbox
                          :disabled="isOverdue(congViec.ngayHetHan) || (checkRoles(['HocVien']) && !userInPhanViec(phanViecOfUser))"
                          class="ml-2"
                          style="width:5px;"
                          v-model="item.trangThaiId"
                          :value="4"
                          @change="updateChiTietCongViec(item)"
                        ></v-checkbox>
                      </v-flex>
                      <v-flex md8 class="pr-1">
                        <span 
                        class="chiTietCongViec" 
                        style="cursor:pointer;" 
                        @click="ShowModalThemBaoCao(item)">
                          {{item.tenChiTietCongViec}}
                        </span>
                      </v-flex>
                      <v-flex md2 class="pl-1">
                        <span 
                          class="primary white--text d-flex align-center"
                          v-if="!isOverdue(item.ngayHetHan)" 
                          style="font-size:12px;border-radius:3px;padding:3px 5px;display:inline-block!important;">
                            <v-icon size="16" class="mr-1" color="#fff">mdi-alarm-check</v-icon>
                            {{ formatDate(item.ngayHetHan) }}
                            </span>
                          <span 
                            v-if="isOverdue(item.ngayHetHan)" 
                            style="font-size:12px;border-radius:3px;padding:3px 5px;display:inline-block!important;"
                            class="red white--text d-flex align-center"
                            >
                            Quá hạn</span>
                      </v-flex>
                      <v-flex md1 class="text-right">
                        <v-tooltip top>
                          <template v-slot:activator="{ on }">
                            <v-btn
                              v-on="on"
                              color="red"
                              icon
                              small
                              class="ma-0"
                              @click="confirmDelete(item)"
                              :disabled="isOverdue(congViec.ngayHetHan) "
                              v-if="!checkRoles(['HocVien'])"
                            >
                              <v-icon size="20">delete</v-icon>
                            </v-btn>
                          </template>
                          <span>Xóa</span>
                        </v-tooltip>
                      </v-flex>
                    </v-col>
                  </v-row>
                    <!-- <v-data-table
                      :items="dSChiTietCongViec"
                      :headers="tableHeader"
                      @update:options="getDSChiTietCongViec"
                      :options.sync="filtersChiTietCongViec"
                      :server-items-length="totalItemsCT"
                      :items-per-page="10"
                      class="elevation-0"
                    >
                      <template v-slot:item.trangThai="{ item }">
                        <v-checkbox
                          v-if="!isOverdue(congViec.ngayHetHan)"
                          :disabled="(checkRoles(['HocVien']) && !userInPhanViec(phanViecOfUser))"
                          class="ml-2"
                          style="width:5px;"
                          v-model="item.trangThaiId"
                          :value="4"
                          @change="updateChiTietCongViec(item)"
                        ></v-checkbox>
                      </template>
        
                       <template v-slot:item.tenChiTietCongViec="{ item }">
                        <span class="chiTietCongViec" style="cursor:pointer;" @click="ShowModalThemBaoCao(item)">
                          {{item.tenChiTietCongViec}}
                        </span>
                       </template>

                      <template  v-slot:item.ngayHetHan="{ item }">
                        <span v-if="!isOverdue(item.ngayHetHan)">{{ formatDate(item.ngayHetHan) }}</span>
                        <span v-if="isOverdue(item.ngayHetHan)" style="color:red;">Quá hạn</span>
                      </template>
                      <template v-slot:item.thaoTac="{ item }">
                        <v-tooltip top>
                          <template v-slot:activator="{ on }">
                            <v-btn
                              v-on="on"
                              color="red"
                              icon
                              small
                              class="ma-0"
                              @click="confirmDelete(item)"
                              :disabled="isOverdue(congViec.ngayHetHan) "
                              v-if="!checkRoles(['HocVien'])"
                            >
                              <v-icon size="20">delete</v-icon>
                            </v-btn>
                          </template>
                          <span>Xóa</span>
                        </v-tooltip>
                      </template>
                    </v-data-table> -->
                  </v-col>
                </v-row>
              </v-col>
              <v-col v-if="isUpdate" cols="12" class="pt-1 pb-3 pl-md-0">
                <span style="font-size:17px;color:black;font-weight:400;" class="pr-2">Người làm:</span>
                <v-menu bottom v-for="(phanViec, index) in dSPhanViec"
                      :key="index">
                  <template v-slot:activator="{ on: menu, attrs }">
                    <v-tooltip top>
                      <template v-slot:activator="{ on: tooltip }">
                        <v-avatar
                          class="mr-2"
                          color="gray"
                          size="36px"
                          v-bind="attrs"
                          v-on="{ ...tooltip, ...menu }"
                          ><img
                                  alt="Avatar"
                                  src="data:image/jpeg;base64,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"
                                ></v-avatar>
                      </template>
                      <span>{{ phanViec.thanhVienDuAn.hocVien.hoTen }}</span>
                    </v-tooltip>
                  </template>
                  <v-list class="py-0">
                    <v-list-item
                      v-if="!isOverdue(duAn.thoiGianHetHan)"
                      class="px-2"
                      @click="confirmDeletePhanViec(phanViec)"
                      style="cursor:pointer;"
                    >
                      <v-list-item-title>Xóa</v-list-item-title>
                    </v-list-item>
                  </v-list>
                </v-menu>
                <v-tooltip top>
                  <template v-slot:activator="{ on }">
                    <v-btn
                      @click="showModalPhanViec(congViec.id, duAnId)"
                      color="blue"
                      icon
                      class="ma-0 ml-3"
                      v-on="on"
                      :disabled="isOverdue(congViec.ngayHetHan)"
                      v-if="!checkRoles(['HocVien'])"
                    >
                      <v-icon size="45">add_circle</v-icon>
                    </v-btn>
                  </template>
                  <span>Thêm người làm</span>
                </v-tooltip>
              </v-col>
              <v-col v-if="!isOverdue(duAn.thoiGianHetHan)" cols="12" class="pt-3 pl-md-0">
                <v-autocomplete
                  v-if="!checkRoles(['HocVien']) && !isView"
                  v-model="congViec.loaiCongViecId"
                  :items="dSLoaiCongViec"
                  item-text="tenLoaiCongViec"
                  item-value="id"
                  clearable
                  class="pt-0 pb-3"
                  label="Loại Công Việc:"
                  placeholder="Chọn Loại Công Việc"
                  :error-messages="errors.collect('Loại Công Việc', 'frmAddEdit')"
                  v-validate="'required'"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Loại Công Việc"
                ></v-autocomplete>
              </v-col>
              <v-col v-if="!isOverdue(duAn.thoiGianHetHan)" cols="12" class="pt-0 pl-md-0">
                <v-text-field
                  v-if="!checkRoles(['HocVien'])&& !isView"
                  v-model="congViec.tenCongViec"
                  class="mt-0 pt-0"
                  label="Tên công việc"
                  :error-messages="errors.collect('Tên công việc', 'frmAddEdit')"
                  v-validate="'required'"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Tên công việc"
                ></v-text-field>
              </v-col>
              <v-col v-if="!isOverdue(duAn.thoiGianHetHan)" cols="12" class="pt-3 pb-0 pl-md-0">
                <v-textarea
                  v-if="!checkRoles(['HocVien']) && !isView"
                  v-model="congViec.moTaCongViec"
                  class="mt-0 pt-0"
                  :error-messages="errors.collect('Mô tả', 'frmAddEdit')"
                  v-validate="''"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Mô tả"
                  label="Mô tả công việc"
                  rows="1"
                  auto-grow
                >
                </v-textarea>
              </v-col>
              <v-col v-if="!isOverdue(duAn.thoiGianHetHan)" cols="12" class="py-0 pl-md-0">
                <v-datepicker
                  v-if="!checkRoles(['HocVien'])&& !isView"
                  v-model="congViec.ngayHetHan"
                  class="mt-0 pt-0"
                  :error-messages="errors.collect('Ngày hết hạn', 'frmAddEdit')"
                  v-validate="'required'"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Ngày hết hạn"
                  label="Ngày hết hạn"
                  :max="duAn.thoiGianHetHan"
                ></v-datepicker>
              </v-col>
              <v-col v-if="!isOverdue(duAn.thoiGianHetHan)" cols="12" class="py-1 pl-md-0">
                <v-autocomplete
                  v-if="!checkRoles(['HocVien'])&& !isView"
                  v-model="congViec.doUuTien"
                  :items="dSUuTien"
                  clearable
                  class="pt-0"
                  label="Độ ưu tiên:"
                  placeholder="Chọn độ ưu tiên"
                  :error-messages="errors.collect('Độ ưu tiên', 'frmAddEdit')"
                  v-validate="'required'"
                  data-vv-scope="frmAddEdit"
                  data-vv-name="Độ ưu tiên"
                ></v-autocomplete>
              </v-col>
              <v-col v-if="!isOverdue(duAn.thoiGianHetHan)&& !isView" cols="12" class="pt-0 pl-md-0">
                <v-checkbox
                  v-if="!checkRoles(['HocVien'])"
                  v-model="congViec.isActive"
                  label="Đang hoạt động"
                  class="pt-0 mt-0"
                ></v-checkbox>
              </v-col>
            </v-row>
          </v-form>
        </v-card-text>
        <v-card-actions class="px-4 pb-4">
          <v-spacer></v-spacer>
          <v-btn :disabled="isOverdue(duAn.thoiGianHetHan)" v-if="!checkRoles(['HocVien']) && !isView" class="primary px-4" @click.native="save" :loading="loading">{{
            isUpdate ? "Cập nhật" : "Thêm mới"
          }}</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <!-- dialog xoa chi tiet cong viec -->
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
            @click="deleteChiTietCongViec"
            >Xác Nhận</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>
    <!-- dialog xoa phan viec -->
    <v-dialog v-model="dialogConfirmDeletePhanViec" max-width="290">
      <v-card>
        <v-card-title class="headline">Xác nhận xóa</v-card-title>
        <v-card-text class="pt-3">Bạn có chắc chắn muốn xóa?</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn @click.native="dialogConfirmDeletePhanViec = false" text>Hủy</v-btn>
          <v-btn
            :loading="loading"
            color="red darken-1"
            text
            @click="deletePhanViec"
            >Xác Nhận</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>
    <modal-them-sua-chi-tiet-cong-viec
      ref="ModalThemSuaChiTietCongViec"
      @updated="getDSChiTietCongViec(filtersChiTietCongViec)"
    ></modal-them-sua-chi-tiet-cong-viec>
    <modal-phan-viec
      ref="ModalPhanViec"
      @updated="getPhanViec(filtersPhanViec)"
    ></modal-phan-viec>
    <modal-them-bao-cao ref="ModalThemBaoCao" ></modal-them-bao-cao>
  </div>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import ModalThemSuaChiTietCongViec from "./ModalThemSuaChiTietCongViec.vue";
import ModalPhanViec from "./ModalPhanViec.vue";
import { LoaiCongViecDTO } from "@/models/LoaiCongViecDTO";
import LoaiCongViecApi, {
  GetLoaiCongViecParams,
} from "../../apiResources/LoaiCongViecApi";
import { DuAnDTO } from "@/models/DuAnDTO";
import DuAnApi, { GetDuAnParams } from "../../apiResources/DuAnApi";
import { CongViecDTO } from "@/models/CongViecDTO";
import CongViecApi, { GetCongViecParams } from "../../apiResources/CongViecApi";
import { PhanViecDTO } from "@/models/PhanViecDTO";
import PhanViecApi, { GetPhanViecParams } from "../../apiResources/PhanViecApi";
import { HocVienDTO } from "@/models/HocVienDTO";
import { ChiTietCongViecDTO } from "@/models/ChiTietCongViecDTO";
import ChiTietCongViecApi, {
  GetChiTietCongViecParams,
} from "../../apiResources/ChiTietCongViecApi";
import { ThanhVienDuAnDTO } from "@/models/ThanhVienDuAnDTO";
import ThanhVienDuAnApi, {
  GetThanhVienDuAnParams,
} from "../../apiResources/ThanhVienDuAnApi";
import ModalThemBaoCao from "./ModalThemBaoCao.vue";
import UserApi from "../../apiResources/UserApi";
export default Vue.extend({
  components: {
    ModalThemSuaChiTietCongViec,
    ModalPhanViec,
    ModalThemBaoCao
  },
  data() {
    return {
      valid: false,
      dialog: false,
      loading: false,
      isUpdate: false,
      congViec: {} as CongViecDTO,
      dSLoaiCongViec: [] as LoaiCongViecDTO[],
      dSPhanViec: [] as PhanViecDTO[],
      filtersPhanViec: { itemsPerPage: 25 } as GetPhanViecParams,
      totalItemsPV: 0 as number | undefined,
      dSChiTietCongViec: [] as ChiTietCongViecDTO[],
      filtersChiTietCongViec: { itemsPerPage: 25 } as GetChiTietCongViecParams,
      totalItemsCT: 0 as number | undefined,
      tableHeader: [
        {
          text: "#",
          value: "trangThai",
          fixed: true,
          width: "10px",
          sortable: false,
          align: "center",
        },
        {
          text: "Tên chi tiết công việc",
          value: "tenChiTietCongViec",
          fixed: true,
          width: "200px",
          sortable: false,
          align: "left",
        },
        {
          text: "Ngày hết hạn",
          value: "ngayHetHan",
          fixed: true,
          width: "100px",
          sortable: false,
          align: "center",
        },
        {
          text: "Thao tác",
          value: "thaoTac",
          fixed: true,
          width: "5px",
          sortable: false,
          align: "center",
        },
      ],
      dSUuTien: ["bình thường", "cao", "rất cao"],
      duAnId: 0 as number,
      chiTietCongViecSelected: {} as ChiTietCongViecDTO,
      dialogConfirmDelete: false,
      phanViecSelected: {} as PhanViecDTO,
      dialogConfirmDeletePhanViec: false,
      thanhVienDuAn:{} as ThanhVienDuAnDTO,
      today:new Date(),
      duAn:{} as DuAnDTO,
      dsRole:[] as any[],
      phanViecOfUser:[] as PhanViecDTO[],
      hocVien:{} as HocVienDTO,
      isNguoiLam:false,
      isView:false
    };
  },
  mounted() {
    this.getRoles();
  },
  methods: {
    show(isView:boolean,isUpdate: boolean, item: any, duAnId: number) {
      this.isUpdate = isUpdate;
      this.dialog = true;
      this.isView=isView;
      this.duAnId = duAnId;
      this.getDSLoaiCongViec();
      this.congViec=item;
      this.getDuAnById(duAnId);
      if (isUpdate) {
        this.getCongViecById(item.id);
        this.filtersChiTietCongViec.congViecId = this.congViec.id;
        this.getDSChiTietCongViec(this.filtersChiTietCongViec);
      }
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
    showModalChiTietCongViec(congViecId: number) {
      (this.$refs.ModalThemSuaChiTietCongViec as any).show(congViecId);
    },
    showModalPhanViec(congViecId: number, duAnId: number) {
      (this.$refs.ModalPhanViec as any).show(congViecId, duAnId);
    },
     ShowModalThemBaoCao(item:any){
      (this.$refs.ModalThemBaoCao as any).show(item)
    },
    hide() {
      this.dialog = false;
      this.$emit("updated");
    },
    getCongViecById(congViecId: number) {
      CongViecApi.getCongViecById(congViecId)
        .then((response) => {
          this.congViec = response;
          this.filtersPhanViec.congViecId = response.id;
          this.getPhanViec(this.filtersPhanViec);
          this.getPhanViecOfUser(this.filtersPhanViec);
          this.filtersChiTietCongViec.congViecId = this.congViec.id;
          this.getDSChiTietCongViec(this.filtersChiTietCongViec);
        })
        .catch((response) => {
          this.$snotify.error("Lây dữ liệu công việc thất bại!");
        });
    },
    getDSLoaiCongViec() {
      LoaiCongViecApi.getLoaiCongViec({ itemsPerPage: -1 })
        .then((response) => {
          this.dSLoaiCongViec = response.data;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu loại công việc thất bại!");
        });
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
    getDSChiTietCongViec(filters: GetChiTietCongViecParams) {
      ChiTietCongViecApi.getChiTietCongViecByCongViecId(filters)
        .then((response) => {
          this.dSChiTietCongViec = response.data;
          this.totalItemsCT = response.pagination.totalItems;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu chi tiết công việc thất bại!");
        });
    },
    formatDate(date: Date) {
      if (!date) {
        return "Không xác định";
      } else return this.$moment(date).format("DD/MM/YYYY");
    },
    updateChiTietCongViec(chiTietCongViec: any) {
      ChiTietCongViecApi.updateChiTietCongViec(
        chiTietCongViec.id,
        chiTietCongViec
      )
        .then((res) => {
          this.loading = false;
          this.$snotify.success("Cập nhật thành công!");
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Cập nhật thất bại!");
        });
    },
    save() {
      this.$validator.validateAll("frmAddEdit").then((res) => {
        if (res) {
          if (this.isUpdate) {
            this.loading = true;
            CongViecApi.updateCongViec(this.congViec.id, this.congViec)
              .then((res) => {
                this.loading = false;
                this.$snotify.success("Cập nhật thành công!");
                this.hide();
              })
              .catch((res) => {
                this.loading = false;
                this.$snotify.error("Cập nhật thất bại!");
              });
          } else {
            this.loading = true;
            this.congViec.duAnId = this.duAnId;
            this.congViec.tyLeHoanThanh = 0;
            this.congViec.trangThaiId = 1;
            CongViecApi.createCongViec(this.congViec)
              .then((res) => {
                this.loading = false;
                this.$snotify.success("Thêm mới thành công!");
                this.$emit("updated");
                this.hide();
              })
              .catch((res) => {
                this.loading = false;
                this.$snotify.error("Thêm mới thất bại!");
              });
          }
        }
      });
    },
    confirmDelete(chiTietCongViec: any): void {
      this.dialogConfirmDelete = true;
      this.chiTietCongViecSelected = chiTietCongViec;
    },
    deleteChiTietCongViec() {
      ChiTietCongViecApi.deleteChiTietCongViec(this.chiTietCongViecSelected.id)
        .then((res) => {
          this.dialogConfirmDelete = false;
          this.getDSChiTietCongViec(this.filtersChiTietCongViec);
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Xóa thất bại!");
        });
    },
    confirmDeletePhanViec(phanViec: any): void {
      this.dialogConfirmDeletePhanViec = true;
      this.phanViecSelected = phanViec;
    },
    deletePhanViec() {
      PhanViecApi.deletePhanViec(this.phanViecSelected.id)
        .then((res) => {
          this.dialogConfirmDeletePhanViec = false;
          this.getPhanViec(this.filtersPhanViec);
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Xóa thất bại!");
        });
    },
    isOverdue(date:Date){
      return this.$moment(this.today).isAfter(date,'day');
    },
    getRoles() {
      UserApi.getMyRoles().then(res => {
        this.dsRole = res;
        this.$store.commit("UPDATE_USER_ROLES", this.dsRole);
        this.$eventBus.$emit("updateRoles", this.dsRole);
      });
    },
    checkRole(role:any) {
      if (this.dsRole) {
        return this.dsRole.indexOf(role) !== -1;
      }
      return false;
    },
    checkRoles(roles:any) {
      if (this.dsRole) {
        for (let i = 0; i < roles.length; i++) {
          if (this.dsRole.indexOf(roles[i]) !== -1) return true;
        }
      }
      return false;
    },
    
    getPhanViecOfUser(filters: GetPhanViecParams) {
      PhanViecApi.getPhanViecByHocVienAndCongViec(filters)
        .then((response) => {
          this.phanViecOfUser = response.data;
        })
        .catch((err) => {
          this.$snotify.error("Lây dữ liệu phân việc thất bại!");
        });
    },
    userInPhanViec(phanViecOfUser:any){
      return phanViecOfUser.length!=0;
    }
  },
});
</script>
<style>
  .chiTietCongViec:hover{
    color: blue;
    text-decoration: underline;
  }
  
</style>
