<template>
  <v-dialog v-model="dialog" max-width="600" scrollable persistent>
    <v-card>
      <v-card-title class="title primary py-1 px-2 white--text">
        <h3>{{isOverdue(duAn.thoiGianHetHan) || checkRoles(['HocVien'])?'Nhân sự nhóm việc':'Cập nhật nhân sự nhóm việc'}}</h3>
        <v-spacer></v-spacer>
        <v-btn class="white--text ma-0" small @click.native="dialog = false" icon dark>
          <v-icon>close</v-icon>
        </v-btn>
      </v-card-title>
      <v-card-text>
        <v-layout row wrap>
         <v-card-text class="px-6">
        <v-form v-model="valid" scope="frmAddEdit">
          <v-row>
            <v-col cols="12" class="ma-0 pa-0">
              <h4>Nhân Sự Hiện Tại:</h4>
            </v-col>
            <v-col cols="12" class="ma-0 pa-0">
                    <v-data-table
                      :items="dSThanhVienDuAn"
                      :headers="headers"
                      @update:options="getThanhVienDuAn"
                      :options.sync="filters"
                      :server-items-length="totalItemsTVDA"
                      class="elevation-0"
                    >
                    <template v-slot:item.ngayThamGia="{ item }">
                      {{formatDate(item.ngayThamGia)}}
                    </template>
                    <template v-slot:item.thaoTac="{ item }">
                        <v-tooltip top>
                          <template v-slot:activator="{ on }">
                            <v-btn v-if="!checkRoles(['HocVien'])" :disabled="isOverdue(duAn.thoiGianHetHan)" v-on="on" @click="confirmDelete(item)" color="red" icon small class="mx-3 ma-0">
                              <v-icon size="20">delete</v-icon>
                            </v-btn>
                          </template>
                          <span>Xóa</span>
                        </v-tooltip>
                      </template>
                    </v-data-table>
            </v-col> 
            <v-col v-if="!isOverdue(duAn.thoiGianHetHan)" cols="12" md="12" class="ma-0 pa-0 pb-3">
              <v-autocomplete
                v-if="!checkRoles(['HocVien'])"
                :items="dSHocVien"
                v-model="thanhVienDuAn.hocVienId"
                item-text="hoTen"
                item-value="id"
                :error-messages="errors.collect('Học Viên', 'frmAddEdit')"
                v-validate="'required'"
                data-vv-scope="frmAddEdit"
                data-vv-name="Học Viên"
                label="Học Viên"
                placeholder="Lựa Chọn Học Viên"
              ></v-autocomplete>
            </v-col>
            <v-col v-if="!isOverdue(duAn.thoiGianHetHan)" cols="12" md="12" class="ma-0 pa-0 ">
              <v-autocomplete
                v-if="!checkRoles(['HocVien'])"
                :items="dSQuyenDuAn"
                v-model="thanhVienDuAn.quyenDuAnId"
                item-text="quyen.tenQuyen"
                item-value="id"
                :error-messages="errors.collect('Vai Trò', 'frmAddEdit')"
                v-validate="'required'"
                data-vv-scope="frmAddEdit"
                data-vv-name="Vai Trò"
                label="Vai Trò"
                placeholder="Lựa Chọn Vai Trò"
                class="ma-0"
              ></v-autocomplete>
            </v-col>
            <v-col v-if="!isOverdue(duAn.thoiGianHetHan)" cols="12" md="12" class="ma-0 pa-0 pb-3">
              <v-datepicker
                v-if="!checkRoles(['HocVien'])"
                v-model="thanhVienDuAn.ngayThamGia"
                :error-messages="errors.collect('Ngày Tham Gia', 'frmAddEdit')"
                v-validate="''"
                data-vv-scope="frmAddEdit"
                data-vv-name="Ngày Tham Gia"
                label="Ngày Tham Gia"
                class="ma-0"
              ></v-datepicker>
            </v-col>
            <v-col v-if="!isOverdue(duAn.thoiGianHetHan)" cols="12" md="12" class="ma-0 pa-0 pb-3">
              <v-textarea
                v-if="!checkRoles(['HocVien'])"
                v-model="thanhVienDuAn.ghiChu"
                :error-messages="errors.collect('Ghi Chú', 'frmAddEdit')"
                v-validate="''"
                data-vv-scope="frmAddEdit"
                data-vv-name="Ghi Chú"
                label="Ghi Chú"
                class="ma-0"
                rows="1"
                auto-grow
              ></v-textarea>
            </v-col>
            <v-col cols="12" class="ma-0 pa-0 pb-3">
              <v-spacer></v-spacer>
              <v-btn v-if="!checkRoles(['HocVien'])" :disabled="isOverdue(duAn.thoiGianHetHan)" @click="save" color="blue" dark >
                Thêm
              </v-btn>
            </v-col>
          </v-row>
        </v-form>
      </v-card-text>
      </v-layout>
      </v-card-text>
    </v-card>
    <v-dialog v-model="dialogConfirmDelete" max-width="290">
      <v-card>
        <v-card-title class="headline">Xác nhận xóa</v-card-title>
        <v-card-text class="pt-3">Bạn có chắc chắn muốn xóa?</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn @click.native="dialogConfirmDelete=false" text>Hủy</v-btn>
          <v-btn :loading="loading" color="red darken-1" text @click="deleteThanhVienDuAn">Xác Nhận</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-dialog>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import { DuAnDTO } from '@/models/DuAnDTO';
import HocVienApi, { GetHocVienParams } from "../../apiResources/HocVienApi";
import QuyenDuAnApi, { GetQuyenDuAnParams } from "../../apiResources/QuyenDuAnApi";
import { ThanhVienDuAnDTO } from '@/models/ThanhVienDuAnDTO';
import { HocVienDTO } from '@/models/HocVienDTO';
import { QuyenDuAnDTO } from '@/models/QuyenDuAnDTO';
import ThanhVienDuAnApi, { GetThanhVienDuAnParams } from '@/apiResources/ThanhVienDuAnApi';
import UserApi from "../../apiResources/UserApi";
export default Vue.extend({
  components: {},
  data() {
    return {
      dialog: false,
      loading: false,
      duAn:{} as DuAnDTO,
      valid: false,
      dialogConfirmDelete:false,
      thanhVienDuAn:{} as ThanhVienDuAnDTO,
      dSThanhVienDuAn:[] as ThanhVienDuAnDTO[],
      filters: { itemsPerPage: 25 } as GetThanhVienDuAnParams,
      totalItemsTVDA: 0 as number | undefined,
      dSHocVien:[] as HocVienDTO[],
      dSQuyenDuAn:[] as QuyenDuAnDTO[],
      filtersQuyenDuAn: { itemsPerPage: 25 } as GetQuyenDuAnParams,
      totalItemsQDA: 0 as number | undefined,
      thanhVienDuAnSelected:{} as ThanhVienDuAnDTO,
      today:new Date(),
      headers: [
        { text: 'Tên Nhân Sự',
          value: 'hocVien.hoTen',
          fixed: true,
          width: "150px",
          sortable: false,
          align: "center",
        },
        { text: 'Vai Trò',
          value: 'quyenDuAn.quyen.tenQuyen' ,
          fixed: true,
          width: "10px",
          sortable: false,
          align: "center",
        },
        { text: 'Ngày Tham Gia',
          value: 'ngayThamGia' ,
          fixed: true,
          width: "30px",
          sortable: false,
          align: "center",
        },
        { text: 'Thao Tác',
          value: 'thaoTac' ,
          fixed: true,
          width: "10px",
          sortable: false,
          align: "center",
        },
        ],
      dsRole:[] as any[],
    };
  },
  mounted() {
    this.getRoles();
  },
  methods: {
    show(item: any) {
      this.dialog = true;
      this.duAn=item;
      if(!this.checkRoles(['HocVien'])){
        this.getDSHocVien();
      }
      this.filtersQuyenDuAn.duAnId=this.duAn.id;
      this.getQuyenDuAn(this.filtersQuyenDuAn);
      this.filters.duAnId=this.duAn.id;
      this.getThanhVienDuAn(this.filters);
      this.thanhVienDuAn={} as ThanhVienDuAnDTO;
    },
   
    hide() {
      this.dialog = false;
      //this.$emit("updated");
    },
    getDSHocVien()
    {
      HocVienApi.getHocVien({ itemsPerPage: -1 })
        .then(response => {
          this.dSHocVien = response.data;
        })
        .catch(err => {
          this.$snotify.error("Lây dữ liệu học viên thất bại!");
        });
    },
    getQuyenDuAn(filters: GetQuyenDuAnParams) {
      QuyenDuAnApi.getQuyenDuAnByDuAnId(filters)
        .then(response => {
          this.dSQuyenDuAn = response.data;
          this.totalItemsQDA = response.pagination.totalItems;
        })
        .catch(err => {
          this.$snotify.error("Lây dữ liệu trạng thái thất bại!");
        });
    },
    getThanhVienDuAn(filters: GetThanhVienDuAnParams) {
      ThanhVienDuAnApi.getThanhVienDuAn(filters)
        .then(response => {
          this.dSThanhVienDuAn = response.data;
          this.totalItemsTVDA = response.pagination.totalItems;
        })
        .catch(err => {
          this.$snotify.error("Lây dữ liệu trạng thái thất bại!");
        });
    },
    formatDate(date: Date) {
      if (!date) {
        return "Không xác định";
      } 
      else 
      return this.$moment(date).format("DD/MM/YYYY");
    },
    save() {
      this.$validator.validateAll("frmAddEdit").then(res => {
        if (res) {
            this.loading = true;
            ThanhVienDuAnApi.createThanhVienDuAn(this.thanhVienDuAn)
              .then(res => {
                this.loading = false;
                this.thanhVienDuAn={} as ThanhVienDuAnDTO;
                this.$snotify.success("Thêm mới thành công!");
                this.getThanhVienDuAn(this.filters);
                this.$emit("updated");
                this.$emit("updatedQLCV");
              })
              .catch(res => {
                this.$snotify.error("Nhân sự đã có!");
                this.loading = false;
              });
        }
      });
    },
    confirmDelete(item:any){
      this.thanhVienDuAnSelected=item;
      this.dialogConfirmDelete=true;
    },
    deleteThanhVienDuAn():void{
      ThanhVienDuAnApi.deleteThanhVienDuAn(this.thanhVienDuAnSelected.id)
        .then(res => {
          this.dialogConfirmDelete = false;
          this.getThanhVienDuAn(this.filters);
          this.$emit("updated");
          this.$emit("updatedQLCV");
        })
        .catch(res => {
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

  }
});
</script>