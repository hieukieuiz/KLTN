<template>
  <v-dialog v-model="dialog" max-width="500" scrollable persistent>
    <v-card>
      <v-card-title class="title primary py-1 px-2 white--text">
        <h3>{{ isUpdate ? "Cập nhật tài khoản " : "Thêm tài khoản" }}</h3>
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
      <v-card-text class="pt-4">
        <v-layout row wrap>
          <v-flex md12>
            <v-text-field
              label="Tài khoản"
              :disabled="isUpdate"
              v-model="user.userName"
              class="mb-3"
              required
              :error-messages="errors.collect('Tài khoản', 'frmAddEdit')"
              v-validate="'required'"
              data-vv-scope="frmAddEdit"
              data-vv-name="Tài khoản"
            ></v-text-field>
          </v-flex>
          <v-flex md12>
            <v-text-field
              v-model="user.password"
              v-if="!isUpdate"
              class="mb-3"
              :append-icon="showPass ? 'visibility_off' : 'visibility'"
              :type="showPass ? 'text' : 'password'"
              @click:append="showPass = !showPass"
              name="password"
              label="Mật khẩu"
              required
              :error-messages="errors.collect('Mật khẩu', 'frmAddEdit')"
              v-validate="'required|min:6'"
              data-vv-scope="frmAddEdit"
              data-vv-name="Mật khẩu"
            ></v-text-field>
          </v-flex>
          <v-flex md12>
            <v-text-field
              label="Email"
              v-model="user.email"
              class="mb-3"
              required
              :error-messages="errors.collect('Email', 'frmAddEdit')"
              v-validate="'required|email'"
              data-vv-scope="frmAddEdit"
              data-vv-name="Email"
            ></v-text-field>
          </v-flex>
          <v-flex md12>
            <v-text-field
              label="Số điện thoại"
              v-model="user.phoneNumber"
              class="mb-3"
              required
              :error-messages="errors.collect('Số điện thoại', 'frmAddEdit')"
              v-validate="''"
              data-vv-scope="frmAddEdit"
              data-vv-name="Số điện thoại"
            ></v-text-field>
          </v-flex>
          <v-flex md12>
            <v-autocomplete
              :items="roles"
              item-text="name"
              item-value="id"
              label="Quyền"
              v-model="user.roles"
              multiple
              :error-messages="errors.collect('Quyền', 'frmAddEdit')"
              v-validate="'required'"
              data-vv-scope="frmAddEdit"
              data-vv-name="Quyền"
            ></v-autocomplete>
          </v-flex>
          <v-flex md12>
            <v-checkbox v-model="locked" label="Khóa tài khoản"></v-checkbox>
          </v-flex>
          <v-flex md12 v-if="locked">
            <v-datetimepicker
              v-model="user.lockoutEnd"
              label="Thời gian khóa đến"
              :error-messages="
                errors.collect('Thời gian khóa đến', 'frmAddEdit')
              "
              v-validate="'required'"
              data-vv-scope="frmAddEdit"
              data-vv-name="Thời gian khóa đến"
            ></v-datetimepicker>
          </v-flex>
        </v-layout>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn class="primary" @click.native="save" :loading="loading">{{
          isUpdate ? "Cập nhật" : "Thêm mới"
        }}</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Vue } from "vue-property-decorator";
import { UserDTO } from "../../models/UserDTO";
import UserApi from "../../apiResources/UserApi";
export default Vue.extend({
  components: {},
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
      isUpdate: false,
      dialog: false,
      showPass: false,
      user: {} as UserDTO,
      loading: false,
      locked: false,
    };
  },
  methods: {
    show(isUpdate: boolean, user: any) {
      this.dialog = true;
      this.user = Object.assign({}, user);
      this.isUpdate = isUpdate;
      if (this.isUpdate !== true) {
        this.user = {} as any;
      } else {
        if (
          user.lockoutEnd &&
          this.$moment(user.lockoutEnd) >= this.$moment()
        ) {
          this.locked = true;
        }
      }
    },
    hide() {
      this.dialog = false;
    },
    save() {
      this.$validator.validateAll("frmAddEdit").then((res) => {
        if (res) {
          if (this.isUpdate) {
            this.loading = true;
            UserApi.updateUser(this.user)
              .then((res) => {
                this.loading = false;
                this.$snotify.success("Cập nhật thành công!");
                this.$emit("updated");
                this.hide();
              })
              .catch((res) => {
                this.loading = false;
                this.$snotify.error("Cập nhật thất bại!");
              });
          } else {
            this.loading = true;
            UserApi.createUser(this.user)
              .then((res) => {
                this.loading = false;
                this.$snotify.success("Thêm mới thành công!");
                this.$emit("updated");
                this.hide();
              })
              .catch((res) => {
                this.loading = false;
                this.$snotify.error(res.response.data.Errors.join(", "));
              });
          }
        }
      });
    },
  },
});
</script>
