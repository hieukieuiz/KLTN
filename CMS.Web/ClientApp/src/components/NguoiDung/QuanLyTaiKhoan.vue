<template>
  <v-layout class="px-7" row wrap>
    <v-flex xs12>
      <v-breadcrumbs class="px-0 py-0" :items="breadcrumbs"></v-breadcrumbs>
    </v-flex>

    <v-flex xs12>
      <v-card>
        <v-card-text>
          <v-layout class="px-7" row wrap>
            <v-flex xs12>
              <h3>QUẢN LÝ TÀI KHOẢN</h3>
            </v-flex>
            <v-flex class="mb-3 mr-2" md4 xs12>
              <v-text-field
                hide-details
                placeholder="Tìm kiếm"
                append-icon="search"
                v-model="filters.keywords"
                @input="getUsers(filters)"
                clearable
              ></v-text-field>
            </v-flex>
            <v-flex xs12 md3>
              <v-autocomplete
                :items="roles"
                item-text="name"
                item-value="id"
                label="Quyền"
                v-model="filters.roles"
                @input="getUsers(filters)"
                clearable
                hide-details
                multiple
              ></v-autocomplete>
            </v-flex>
            <v-spacer></v-spacer>
            <v-btn
              color="primary"
              @click="showModalThemSua(false, {})"
              class="mt-4"
              >Thêm mới</v-btn
            >
            <v-flex xs12>
              <v-data-table
                :items="danhSachTaiKhoan"
                :headers="tableHeader"
                @update:options="getUsers"
                :options.sync="filters"
                :server-items-length="totalUsers"
                :loading="loading"
                class="elevation-1"
              >
                <template v-slot:item.thaotac="{ item }">
                  <v-btn
                    text
                    color="primary"
                    icon
                    small
                    @click="showModalThemSua(true, item)"
                    class="ma-0"
                  >
                    <v-icon small>edit</v-icon>
                  </v-btn>
                  <v-btn
                    text
                    color="red"
                    icon
                    small
                    class="ma-0"
                    @click="confirmDelete(item)"
                  >
                    <v-icon small>delete</v-icon>
                  </v-btn>
                </template>
                <template v-slot:item.lockoutEnd="{ item }">{{
                  $moment(item.lockoutEnd) >= $moment()
                    ? $moment(item.lockoutEnd).format("DD/MM/YYYY, HH:mm")
                    : ""
                }}</template>
              </v-data-table>
            </v-flex>
            <modal-them-tai-khoan
              ref="modalThemTaiKhoan"
              @updated="getUsers(filters)"
            ></modal-them-tai-khoan>
          </v-layout>
        </v-card-text>
      </v-card>
    </v-flex>
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
            @click="deleteUser"
            >Xác Nhận</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-layout>
</template>
<script lang="ts">
import { Vue } from "vue-property-decorator";
import ModalThemTaiKhoan from "./ModalThemTaiKhoan.vue";
import UserApi, { GetUsersParams } from "../../apiResources/UserApi";
import { UserDTO } from "../../models/UserDTO";

export default Vue.extend({
  components: {
    ModalThemTaiKhoan,
  },
  data() {
    return {
      roles: [
        {
          id: "Admin",
          name: "Admin",
        },
        {
          id: "DoanhNghiep",
          name: "Doanh nghiệp",
        },
        {
          id: "UngVien",
          name: "Ứng viên",
        },
      ],
      filters: { itemsPerPage: -1 } as GetUsersParams,
      totalUsers: 0 as number | undefined,
      dialogConfirmDelete: false,
      tableHeader: [
        {
          text: "Thao tác",
          value: "thaotac",
          align: "center",
          sortable: false,
        },
        {
          text: "Tài khoản",
          value: "userName",
          align: "center",
          sortable: false,
        },
        { text: "Email", value: "email", align: "center", sortable: false },
        { text: "SĐT", value: "phoneNumber", align: "center", sortable: false },
        { text: "Quyền", value: "roles", align: "center", sortable: false },
        {
          text: "T.G khóa đến",
          value: "lockoutEnd",
          align: "center",
          sortable: false,
        },
      ],
      danhSachTaiKhoan: [] as UserDTO[],
      userSelected: undefined as UserDTO | undefined,
      loading: false,
    };
  },
  computed: {
    breadcrumbs(): any {
      return [
        {
          text: "Danh sách tài khoản",
          disabled: false,
          to: "/nguoidung/quanlytaikhoan",
          exact: true,
        },
      ];
    },
  },
  mounted() {},
  methods: {
    showModalThemSua(isUpdate: boolean, item: any) {
      (this.$refs.modalThemTaiKhoan as any).show(isUpdate, item);
    },
    getUsers(filters: GetUsersParams) {
      UserApi.getUsers(filters)
        .then((res) => {
          this.danhSachTaiKhoan = res.data;
          this.totalUsers = res.pagination.totalItems;
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Lấy danh sách tài khoản thất bại!");
        });
    },
    confirmDelete(user: any): void {
      this.dialogConfirmDelete = true;
      this.userSelected = user;
    },
    deleteUser(): void {
      UserApi.deleteUser(this.userSelected as UserDTO)
        .then((res) => {
          this.dialogConfirmDelete = false;
          this.userSelected = undefined;
          this.getUsers(this.filters);
        })
        .catch((res) => {
          this.loading = false;
          this.$snotify.error("Xóa thất bại!");
        });
    },
  },
});
</script>
