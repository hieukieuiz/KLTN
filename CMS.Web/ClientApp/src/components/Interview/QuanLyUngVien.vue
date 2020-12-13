<template>
  <v-container
    style="background-color: #fff; min-height: 550px"
    class="q-card-shadow q-card-border mt-3"
  >
    <v-row>
      <v-col cols="12">
        <h3>QUẢN LÝ ỨNG VIÊN</h3>
      </v-col>
      <v-col cols="12" md="4" style="padding: 0px 12px 0px 12px">
        <v-tooltip top>
          <template v-slot:activator="{ on, attrs }">
            <v-text-field
              v-model="search"
              append-icon="mdi-magnify"
              label="Tìm kiếm"
              v-bind="attrs"
              v-on="on"
            ></v-text-field>
          </template>
          <span>Nhập từ khoá tìm kiếm</span>
        </v-tooltip>
      </v-col>

      <v-col
        cols="12"
        md="4"
        class="pl-md-0"
        style="padding: 0px 12px 0px 12px"
      >
        <v-autocomplete
          v-model="valNguon"
          :items="nguon"
          label="Nguồn"
        ></v-autocomplete>
      </v-col>
      <v-col
        cols="12"
        md="4"
        class="pl-md-0"
        style="padding: 0px 12px 0px 12px"
      >
        <v-autocomplete
          v-model="valTrangThai"
          :items="trangthai"
          label="Trạng thái"
        ></v-autocomplete>
      </v-col>

      <v-col cols="12" md="4" style="padding: 0px 12px 0px 12px">
        <template>
          <v-menu
            ref="menuNgayDky"
            v-model="menuNgayDky"
            :close-on-content-click="false"
            transition="scale-transition"
            offset-y
            min-width="290px"
          >
            <template v-slot:activator="{ on, attrs }">
              <v-text-field
                v-model="dateDky"
                label="Đăng ký từ"
                append-icon="mdi-calendar"
                readonly
                v-bind="attrs"
                v-on="on"
              ></v-text-field>
            </template>
            <v-date-picker
              ref="picker"
              v-model="dateDky"
              :max="new Date().toISOString().substr(0, 10)"
              min="1950-01-01"
              @change="saveDateDky"
              locale="vi-vn"
            ></v-date-picker>
          </v-menu>
        </template>
      </v-col>

      <v-col
        cols="12"
        md="4"
        style="padding: 0px 12px 0px 12px"
        class="pl-md-0"
      >
        <template>
          <v-menu
            ref="menuNgayDen"
            v-model="menuNgayDen"
            :close-on-content-click="false"
            transition="scale-transition"
            offset-y
            min-width="290px"
          >
            <template v-slot:activator="{ on, attrs }">
              <v-text-field
                v-model="dateDen"
                label="Đến"
                append-icon="mdi-calendar"
                readonly
                v-bind="attrs"
                v-on="on"
              ></v-text-field>
            </template>
            <v-date-picker
              ref="picker2"
              v-model="dateDen"
              :max="new Date().toISOString().substr(0, 10)"
              min="1950-01-01"
              @change="saveDateDen"
              locale="vi-vn"
            ></v-date-picker>
          </v-menu>
        </template>
      </v-col>

      <v-col cols="12">
        <v-data-table :headers="headers" :items="desserts" :search="search">
          <template v-slot:[`item.thaotac`]="{ item }">
            <v-tooltip top>
              <template v-slot:activator="{ on }">
                <v-btn
                  v-on="on"
                  color="primary"
                  icon
                  small
                  @click="showModalThemSuaDuAn(true, item)"
                  class="ma-0"
                >
                  <v-icon size="15">mdi-account-card-details</v-icon>
                </v-btn>
              </template>
              <span>CV</span>
            </v-tooltip>

            <v-tooltip top>
              <template v-slot:activator="{ on }">
                <v-btn
                  v-on="on"
                  @click="confirmDelete(item)"
                  color="red"
                  icon
                  small
                  class="mx-2 ma-0"
                >
                  <v-icon size="17">mdi-account-star</v-icon>
                </v-btn>
              </template>
              <span>Đánh giá</span>
            </v-tooltip>

            <v-tooltip top>
              <template v-slot:activator="{ on }">
                <v-btn
                  :to="item.linkQuanLiViec"
                  class="ma-0 mr-1"
                  icon
                  small
                  v-on="on"
                >
                  <v-icon size="17" color="teal lighten-2">mdi-printer</v-icon>
                </v-btn>
              </template>
              <span>In kết quả</span>
            </v-tooltip>
          </template>
        </v-data-table>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      dateDky: null,
      menuNgayDky: false,
      dateDen: null,
      menuNgayDen: false,
      trangthai: ["Chưa đánh giá", "Tiềm năng", "Loại"],
      valTrangThai: null,
      nguon: ["Tự do", "Nội bộ"],
      valNguon: null,
      search: "",
      headers: [
        {
          text: "#",
          align: "start",
          sortable: false,
          value: "stt",
          fixed: true,
          width: "5px",
          align: "center",
        },
        {
          text: "Họ tên",
          value: "name",
          fixed: true,
          width: "80px",
        },
        {
          text: "Vị trí",
          value: "vitri",
          fixed: true,
          width: "80px",
        },
        {
          text: "Ngày đăng ký",
          value: "ngaydky",
          fixed: true,
          width: "80px",
        },
        {
          text: "Số điện thoại",
          value: "sdt",
          fixed: true,
          width: "80px",
        },
        {
          text: "Trạng thái",
          value: "trangthai",
          fixed: true,
          width: "80px",
        },
        {
          text: "Email",
          value: "email",
          fixed: true,
          width: "80px",
        },
        {
          text: "Thao tác",
          value: "thaotac",
          fixed: true,
          width: "80px",
          align: "center",
        },
      ],
      desserts: [
        {
          name: "Email",
          stt: 0,
          name: "nguyen van a",
          vitri: "abc",
          ngaydky: "4/6/2020",
          sdt: 32232332,
          trangthai: "Loại",
          email: "a@gmail.com",
        },
        {
          name: "Email",
          stt: 0,
          name: "nguyen van a",
          vitri: "abc",
          ngaydky: "4/6/2020",
          sdt: 32232332,
          trangthai: "Loại",
          email: "a@gmail.com",
        },
        {
          name: "Email",
          stt: 0,
          name: "nguyen van b",
          vitri: "abc",
          ngaydky: "4/6/2020",
          sdt: 32232332,
          trangthai: "Tự do",
          email: "a@gmail.com",
        },
        {
          name: "Email",
          stt: 0,
          name: "nguyen van c",
          vitri: "abc",
          ngaydky: "4/6/2020",
          sdt: 32232332,
          trangthai: "Tự do",
          email: "a@gmail.com",
        },
        {
          name: "Email",
          stt: 0,
          name: "nguyen van b",
          vitri: "abc",
          ngaydky: "4/6/2020",
          sdt: 32232332,
          trangthai: "Tự do",
          email: "a@gmail.com",
        },
        {
          name: "Email",
          stt: 0,
          name: "nguyen van b",
          vitri: "abc",
          ngaydky: "4/6/2020",
          sdt: 32232332,
          trangthai: "Tự do",
          email: "a@gmail.com",
        },
        {
          name: "Email",
          stt: 0,
          name: "nguyen van b",
          vitri: "abc",
          ngaydky: "4/6/2020",
          sdt: 32232332,
          trangthai: "Tự do",
          email: "a@gmail.com",
        },
        {
          name: "Email",
          stt: 0,
          name: "nguyen van b",
          vitri: "abc",
          ngaydky: "4/6/2020",
          sdt: 32232332,
          trangthai: "Tự do",
          email: "a@gmail.com",
        },
        {
          name: "Email",
          stt: 0,
          name: "nguyen van b",
          vitri: "abc",
          ngaydky: "4/6/2020",
          sdt: 32232332,
          trangthai: "Tự do",
          email: "a@gmail.com",
        },
        {
          name: "Email",
          stt: 0,
          name: "nguyen van b",
          vitri: "abc",
          ngaydky: "4/6/2020",
          sdt: 32232332,
          trangthai: "Tự do",
          email: "a@gmail.com",
        },
        {
          name: "Email",
          stt: 0,
          name: "nguyen van b",
          vitri: "abc",
          ngaydky: "4/6/2020",
          sdt: 32232332,
          trangthai: "Tự do",
          email: "a@gmail.com",
        },
      ],
    };
  },
  watch: {
    menuNgayDky(val) {
      val && setTimeout(() => (this.$refs.picker.activePicker = "YEAR"));
    },
    menuNgayDen(val) {
      val && setTimeout(() => (this.$refs.picker2.activePicker = "YEAR"));
    },
  },
  methods: {
    saveDateDky(dateDky) {
      this.$refs.menuNgayDky.save(dateDky);
    },
    saveDateDen(dateDen) {
      this.$refs.menuNgayDen.save(dateDen);
    },
  },
};
</script>
