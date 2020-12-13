<template>
  <v-navigation-drawer
    id="appDrawer"
    persistent
    v-model="$store.state.app.drawer"
    fixed
    width="230"
    app
    enable-resize-watcher
    color="#f5f6f7"
  >
    <v-toolbar color="primary lighten-1" dark height="45" to="/">
      <a href="/">
        <img
          src="static/img/logo-hvit.png"
          class="mt-1"
          height="36"
          alt="Insight"
        />
      </a>
      <v-toolbar-title class="ml-0 pl-2">
        <span class="hidden-sm-and-down" style="font-size:22px;"
          >HVIT Clan</span
        >
      </v-toolbar-title>
    </v-toolbar>
    <v-list id="leftSideBar">
      <vue-perfect-scrollbar
        class="drawer-menu--scroll"
        :settings="scrollSettings"
      >
        <v-list dense expand>
          <template v-if="dsMenu.length !== 0">
            <template v-for="(item, i) in dsMenu">
              <!--group with subitems-->
              <v-list-group
                v-if="item.items && item.show"
                :key="item.name"
                :group="item.group"
                :prepend-icon="item.icon"
                no-action="no-action"
              >
                <v-list-item slot="activator" ripple="ripple" v-if="item.link">
                  <v-list-item-content>
                    <v-list-item-title>{{ item.title }}</v-list-item-title>
                  </v-list-item-content>
                </v-list-item>
                <template v-for="(subItem, i) in item.items">
                  <!--sub group-->
                  <v-list-group
                    v-if="subItem.items && subItem.show"
                    :key="subItem.name"
                    :group="subItem.group"
                    sub-group="sub-group"
                  >
                    <v-list-item class="pa-0" slot="activator" ripple="ripple">
                      <v-list-item-content>
                        <v-list-item-title>
                          {{ subItem.title }}
                        </v-list-item-title>
                      </v-list-item-content>
                    </v-list-item>
                    <v-list-item
                      v-for="(grand, i) in subItem.children"
                      :key="i"
                      :to="grand.link"
                      :href="grand.href"
                      ripple="ripple"
                    >
                      <v-list-item-content>
                        <v-list-item-title>{{ grand.title }}</v-list-item-title>
                      </v-list-item-content>
                    </v-list-item>
                  </v-list-group>
                  <!--child item-->
                  <v-list-item
                    v-else-if="subItem.show"
                    :key="i"
                    :to="subItem.link"
                    :href="subItem.href"
                    :disabled="subItem.disabled"
                    :target="subItem.target"
                    ripple="ripple"
                  >
                    <v-list-item-content>
                      <v-list-item-title>
                        <span>{{ subItem.title }}</span>
                      </v-list-item-title>
                    </v-list-item-content>
                    <!-- <v-circle class="white--text pa-0 circle-pill" v-if="subItem.badge" color="red" disabled="disabled">{{ subItem.badge }}</v-circle> -->
                    <v-list-item-action v-if="subItem.action">
                      <v-icon
                        :class="[subItem.actionClass || 'success--text']"
                        >{{ subItem.action }}</v-icon
                      >
                    </v-list-item-action>
                  </v-list-item>
                </template>
              </v-list-group>
              <v-subheader v-else-if="item.header && item.show" :key="i">
                {{ item.header }}
              </v-subheader>
              <v-divider
                v-else-if="item.divider && item.show"
                :key="i"
              ></v-divider>
              <!--top-level link-->
              <v-list-item
                v-else-if="item.show"
                :to="item.link"
                :href="item.href"
                ripple="ripple"
                :disabled="item.disabled"
                :target="item.target"
                rel="noopener"
                :key="item.name"
              >
                <v-list-item-action v-if="item.icon">
                  <v-icon>{{ item.icon }}</v-icon>
                </v-list-item-action>
                <v-list-item-content v-if="item.link">
                  <v-list-item-title>{{ item.title }}</v-list-item-title>
                </v-list-item-content>
                <v-list-item-content v-if="item.href">
                  <a
                    style="text-decoration:none;color:#401111"
                    :href="item.href"
                    target="_blank"
                  >
                    <v-list-item-title>{{ item.title }}</v-list-item-title>
                  </a>
                </v-list-item-content>
                <!-- <v-circle class="white--text pa-0 chip--x-small" v-if="item.badge" :color="item.color || 'primary'" disabled="disabled">{{ item.badge }}</v-circle> -->
                <v-list-item-action v-if="item.subAction">
                  <v-icon class="success--text">{{ item.subAction }}</v-icon>
                </v-list-item-action>
                <!-- <v-circle class="caption blue lighten-2 white--text mx-0" v-else-if="item.chip" label="label" small="small">{{ item.chip }}</v-circle> -->
              </v-list-item>
            </template>
          </template>
        </v-list>
      </vue-perfect-scrollbar>
    </v-list>
  </v-navigation-drawer>
</template>

<script>
import VuePerfectScrollbar from "vue-perfect-scrollbar";
import AuthService from "@/AuthService";
import UserApi from "../../apiResources/UserApi";
const authService = new AuthService();

export default {
  components: { VuePerfectScrollbar },
  data() {
    return {
      scrollSettings: {
        maxScrollbarLength: 160,
      },
      clipped: false,
      drawer: true,
      fixed: true,
      miniVariant: false,
      right: true,
      rightDrawer: false,
      title: "",
      user: this.$store.state.user.Profile,
      dsMenu: [],
      dsRole: [],
      connection: null,
      messages: [],
      connected: false,
      message: { user: "", content: "" },
    };
  },
  computed: {
    isLoggedIn() {
      this.user = this.$store.state.user.Profile;
      return (
        this.$store.state.user &&
        this.$store.state.user.AccessToken &&
        this.$store.state.user.AccessToken.IsAuthenticated
      );
    },
  },
  watch: {
    selectedAcademicYear(newVal, oldVal) {
      this.$eventBus.$emit("academicYearChanged", newVal);
      this.$store.commit("UPDATE_ACADEMICYEAR", newVal);
    },
  },
  created() {
    // this.$eventBus.$on("logged", this.getRoles);
  },
  mounted() {
    this.getRoles();
    this.dsMenu = this.getDSMenu();
  },
  methods: {
    getDSMenu() {
      return [
        {
          icon: "dashboard",
          title: "Dashboard",
          show: true,
          link: "/",
        },
        {
          icon: "account_circle",
          title: "Học viên",
          show: this.checkRoles(["HocVien"]),
          link: "/",
          items: [
            {
              icon: "supervisor_account",
              title: "Nhóm việc của tôi",
              show: this.checkRoles(["HocVien"]),
              link: "/hocvien/duancuatoi",
            },
          ],
        },

        {
          icon: "account_circle",
          title: "Ứng viên",
          show: this.checkRoles(["UngVien"]),
          link: "/",
          items: [
            {
              icon: "supervisor_account",
              title: "Thông tin cá nhân",
              show: this.checkRoles(["UngVien"]),
              link: "/ungvien/thongtincanhan",
            },
            // {
            //   icon: "supervisor_account",
            //   title: "Quản lý ứng viên",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/quanlyungvien",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Danh sách ứng viên",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/danhsachungvien",
            // },
            {
              icon: "supervisor_account",
              title: "Danh sách bài đăng tuyển",
              show: this.checkRoles(["UngVien"]),
              link: "/ungvien/danhsachbaidangtuyen",
            },
            // {
            //   icon: "supervisor_account",
            //   title: "Quản lý doanh nghiệp",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/quanlydoanhnghiep",
            // },
            {
              icon: "supervisor_account",
              title: "CV Ứng Viên",
              show: this.checkRoles(["UngVien"]),
              link: "/ungvien/cvungvien",
            },
            // {
            //   icon: "supervisor_account",
            //   title: "Bài Tuyển Dụng",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/baituyendung",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Trạng Thái",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/trangthai",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Nhóm Kỹ Năng",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/nhomkynang",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Kỹ Năng",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/kynang",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Danh sách ứng viên",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/danhsachungvien",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Danh sách khóa học",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/khoahoc",
            // },
          ],
        },
        {
          icon: "account_circle",
          title: "Quản trị viên",
          show: this.checkRoles(["Admin"]),
          link: "/",
          items: [
            // {
            //   icon: "supervisor_account",
            //   title: "Thông tin cá nhân",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/thongtincanhan",
            // },
            {
              icon: "supervisor_account",
              title: "Bài Tuyển Dụng",
              show: this.checkRoles(["Admin"]),
              link: "/admin/baituyendung",
            },
            {
              icon: "supervisor_account",
              title: "Quản lý ứng viên",
              show: this.checkRoles(["Admin"]),
              link: "/admin/quanlyungvien",
            },
            {
              icon: "supervisor_account",
              title: "Danh sách ứng viên",
              show: this.checkRoles(["Admin"]),
              link: "/admin/danhsachungvien",
            },
            // {
            //   icon: "supervisor_account",
            //   title: "Quản lý bài đăng tuyển",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/danhsachbaidangtuyen",
            // },
            {
              icon: "supervisor_account",
              title: "Quản lý doanh nghiệp",
              show: this.checkRoles(["Admin"]),
              link: "/admin/quanlydoanhnghiep",
            },
            // {
            //   icon: "supervisor_account",
            //   title: "CV Ứng Viên",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/cvungvien",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Bài Tuyển Dụng",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/baituyendung",
            // },
            {
              icon: "supervisor_account",
              title: "Trạng Thái",
              show: this.checkRoles(["Admin"]),
              link: "/admin/trangthai",
            },
            {
              icon: "supervisor_account",
              title: "Nhóm Kỹ Năng",
              show: this.checkRoles(["Admin"]),
              link: "/admin/nhomkynang",
            },
            {
              icon: "supervisor_account",
              title: "Kỹ Năng",
              show: this.checkRoles(["Admin"]),
              link: "/admin/kynang",
            },
            {
              icon: "supervisor_account",
              title: "Danh sách tài khoản",
              show: this.checkRoles(["Admin"]),
              link: "/admin/quanlytaikhoan",
            },
            // {
            //   icon: "supervisor_account",
            //   title: "Quản lý quyền",
            //   show: this.checkRoles(["Admin"]),
            //   link: "/admin/quanlyquyen",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Danh sách ứng viên",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/danhsachungvien",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Danh sách khóa học",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/khoahoc",
            // },
          ],
        },
        {
          icon: "account_circle",
          title: "Doanh nghiệp",
          show: this.checkRoles(["DoanhNghiep"]),
          link: "/",
          items: [
            // {
            //   icon: "supervisor_account",
            //   title: "Thông tin cá nhân",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/thongtincanhan",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Quản lý ứng viên",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/quanlyungvien",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Danh sách ứng viên",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/danhsachungvien",
            // },
            {
              icon: "supervisor_account",
              title: "Danh sách bài đăng tuyển",
              show: this.checkRoles(["DoanhNghiep"]),
              link: "/doanhnghiep/danhsachbaidangtuyen",
            },
            // {
            //   icon: "supervisor_account",
            //   title: "Quản lý doanh nghiệp",
            //   show: this.checkRoles(["DoanhNghiep"]),
            //   link: "/doanhnghiep/quanlydoanhnghiep",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "CV Ứng Viên",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/cvungvien",
            // },
            {
              icon: "supervisor_account",
              title: "Bài Tuyển Dụng",
              show: this.checkRoles(["DoanhNghiep"]),
              link: "/doanhnghiep/baituyendung",
            },
            // {
            //   icon: "supervisor_account",
            //   title: "Trạng Thái",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/trangthai",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Nhóm Kỹ Năng",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/nhomkynang",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Kỹ Năng",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/kynang",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Danh sách ứng viên",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/danhsachungvien",
            // },
            // {
            //   icon: "supervisor_account",
            //   title: "Danh sách khóa học",
            //   show: this.checkRoles(["UngVien"]),
            //   link: "/ungvien/khoahoc",
            // },
          ],
        },
        // {
        //   icon: "account_box",
        //   title: "Người dùng",
        //   show: this.checkRoles(["Admin"]),
        //   link: "/",
        //   items: [
        //     {
        //       icon: "supervisor_account",
        //       title: "Danh sách học viên",
        //       show: this.checkRoles(["Admin"]),
        //       link: "/nguoidung/quanlyhocvien",
        //     },
        //     {
        //       icon: "supervisor_account",
        //       title: "Danh sách tài khoản",
        //       show: this.checkRoles(["Admin"]),
        //       link: "/nguoidung/quanlytaikhoan",
        //     },
        //     {
        //       icon: "supervisor_account",
        //       title: "Quản lý nhóm việc",
        //       show: this.checkRoles(["Admin"]),
        //       link: "/nguoidung/quanlyduan",
        //     },
        //     {
        //       icon: "supervisor_account",
        //       title: "Quản Lý Trạng Thái",
        //       show: this.checkRoles(["Admin"]),
        //       link: "/nguoidung/quanlytrangthai",
        //     },
        //     {
        //       icon: "supervisor_account",
        //       title: "Quản Lý Vai Trò",
        //       show: this.checkRoles(["Admin"]),
        //       link: "/nguoidung/quanlyquyen",
        //     },
        //     {
        //       icon: "supervisor_account",
        //       title: "Quản Lý Loại Công Việc",
        //       show: this.checkRoles(["Admin"]),
        //       link: "/nguoidung/quanlyloaicongviec",
        //     },
        //   ],
        // },
      ];
    },

    checkRole(role) {
      if (this.dsRole) {
        return this.dsRole.indexOf(role) !== -1;
      }
      return false;
    },
    checkRoles(roles) {
      if (this.dsRole) {
        for (let i = 0; i < roles.length; i++) {
          if (this.dsRole.indexOf(roles[i]) !== -1) return true;
        }
      }
      return false;
    },
    getRoles() {
      UserApi.getMyRoles().then((res) => {
        this.dsRole = res;
        this.dsMenu = this.getDSMenu();
        this.$store.commit("UPDATE_USER_ROLES", this.dsRole);
        this.$eventBus.$emit("updateRoles", this.dsRole);
      });
    },
  },
};
</script>

<style>
#leftSideBar .v-list-item__action:first-child,
#appDrawer .v-list-item__icon:first-child {
  margin-right: 5px !important;
}

#leftSideBar
  .v-list-group
  .v-list-group__header
  .v-list-item__icon.v-list-group__header__append-icon {
  min-width: 25px !important;
}

#leftSideBar .v-list-group__header > .v-list-item {
  padding-left: 0 !important;
}

#leftSideBar
  .v-list-group--no-action
  > .v-list-group__items
  > div
  > .v-list-item {
  padding-left: 36px !important;
}

#leftSideBar .v-list-item {
  padding: 0 8px;
}

#leftSideBar .v-list--dense .v-list-item .v-list-item__content,
#leftSideBar .v-list-item--dense .v-list-item__content {
  padding: 8px 5px !important;
}
</style>
