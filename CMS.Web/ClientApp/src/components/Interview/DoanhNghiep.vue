<template>
  <v-container
    style="background-color: #fff; min-height: auto"
    class="q-card-shadow q-card-border mt-3"
  >
    <v-row cols="12" md="4">
      <v-col cols="12" md="4">
        <v-container>
          <v-col justify="center">
            <v-tooltip top>
              <template v-slot:activator="{ on, attrs }">
                <v-avatar size="175" v-bind="attrs" v-on="on">
                  <img
                    src="https://cdn.vuetifyjs.com/images/john.jpg"
                    alt="John"
                /></v-avatar>
              </template>
              <span>Ảnh Avatar</span>
            </v-tooltip>
          </v-col>
          <v-card-title class="cyan darken-1">
            <span class="headline white--text">Sarah Mcbeal</span>

            <v-spacer></v-spacer>

            <v-btn dark icon>
              <v-icon>mdi-chevron-left</v-icon>
            </v-btn>

            <v-btn dark icon>
              <v-icon>mdi-pencil</v-icon>
            </v-btn>

            <v-btn dark icon>
              <v-icon>mdi-dots-vertical</v-icon>
            </v-btn>
          </v-card-title>

          <v-list>
            <v-list-item>
              <v-list-item-action>
                <v-icon>mdi-phone</v-icon>
              </v-list-item-action>

              <v-list-item-content>
                <v-list-item-title>(650) 555-1234</v-list-item-title>
              </v-list-item-content>
              <v-list-item-action>
                <v-icon>mdi-message-text</v-icon>
              </v-list-item-action>
            </v-list-item>

            <v-divider inset></v-divider>

            <v-list-item>
              <v-list-item-action>
                <v-icon>mdi-phone</v-icon>
              </v-list-item-action>

              <v-list-item-content>
                <v-list-item-title>(323) 555-6789</v-list-item-title>
              </v-list-item-content>

              <v-list-item-action>
                <v-icon>mdi-message-text</v-icon>
              </v-list-item-action>
            </v-list-item>

            <v-divider inset></v-divider>

            <v-list-item>
              <v-list-item-action>
                <v-icon>mdi-email</v-icon>
              </v-list-item-action>

              <v-list-item-content>
                <v-list-item-title>mcbeal@example.com</v-list-item-title>
              </v-list-item-content>
            </v-list-item>

            <v-divider inset></v-divider>

            <v-list-item>
              <v-list-item-action>
                <v-icon>mdi-map-marker</v-icon>
              </v-list-item-action>

              <v-list-item-content>
                <v-list-item-title>Orlando, FL 79938</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </v-list>

          <v-img
            src="https://picsum.photos/700?image=996"
            height="200px"
          ></v-img>
        </v-container>
      </v-col>
      <v-col cols="12" md="8">
        <v-container>
          <v-col cols="12">
            <h3>Tuyển dụng lập trình viên Java</h3>
          </v-col>
          <v-list>
            <v-list-item>
              <v-list-item-action>
                <v-icon>mdi-phone</v-icon>
              </v-list-item-action>

              <v-list-item-content>
                <v-list-item-title>(650) 555-1234</v-list-item-title>
              </v-list-item-content>
              <v-list-item-action>
                <v-icon>mdi-message-text</v-icon>
              </v-list-item-action>
            </v-list-item>

            <v-divider inset></v-divider>

            <v-list-item>
              <v-list-item-action>
                <v-icon>mdi-phone</v-icon>
              </v-list-item-action>

              <v-list-item-content>
                <v-list-item-title>(323) 555-6789</v-list-item-title>
              </v-list-item-content>

              <v-list-item-action>
                <v-icon>mdi-message-text</v-icon>
              </v-list-item-action>
            </v-list-item>

            <v-divider inset></v-divider>

            <v-list-item>
              <v-list-item-action>
                <v-icon>mdi-email</v-icon>
              </v-list-item-action>

              <v-list-item-content>
                <v-list-item-title>mcbeal@example.com</v-list-item-title>
              </v-list-item-content>
            </v-list-item>

            <v-divider inset></v-divider>

            <v-list-item>
              <v-list-item-action>
                <v-icon>mdi-map-marker</v-icon>
              </v-list-item-action>

              <v-list-item-content>
                <v-list-item-title>Orlando, FL 79938</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </v-list>
          <!-- <v-row>
            <v-col cols="12" md="6">
              <v-col cols="12" md="12">
                <v-col
                  cols="12"
                  md="12"
                  style="padding: 12px 12px 12px 12px"
                  class="pl-md-0"
                >
                  <v-tooltip top>
                    <template v-slot:activator="{ on, attrs }">
                      <v-text-field
                        v-model="mucluong"
                        append-icon="mdi-magnify"
                        label="Mức Lương"
                        v-bind="attrs"
                        v-on="on"
                      ></v-text-field>
                    </template>
                  </v-tooltip>
                </v-col>
                <v-col
                  cols="12"
                  md="12"
                  class="pl-md-0"
                  style="padding: 0px 12px 0px 12px"
                >
                  <v-text-field
                    v-model="valKinhNghiem"
                    :items="kinhnghiem"
                    label="Kinh Nghiệm"
                  ></v-text-field>
                </v-col>
                <v-col cols="12" md="12" class="pl-md-0">
                  <v-autocomplete
                    v-model="valThanhPho"
                    :items="thanhpho"
                    label="Thành Phố"
                  ></v-autocomplete>
                </v-col>
                <v-col
                  cols="12"
                  md="12"
                  style="padding: 0px 12px 0px 12px"
                  class="pl-md-0"
                >
                  <v-text-field
                    v-model="valSoLuong"
                    :items="soluong"
                    label="Số Lượng"
                  ></v-text-field>
                </v-col>

                <v-col cols="12" md="12" class="pl-md-0">
                  <v-autocomplete
                    v-model="valGioiTinh"
                    :items="gioitinh"
                    label="Giới Tính"
                  ></v-autocomplete>
                </v-col>
              </v-col>
            </v-col>
            <v-col cols="12" md="6">
              <v-col cols="12" md="12">
                <v-col
                  cols="12"
                  md="12"
                  style="padding: 12px 12px 12px 12px"
                  class="pl-md-0"
                >
                  <v-tooltip top>
                    <template v-slot:activator="{ on, attrs }">
                      <v-text-field
                        v-model="tringdo"
                        append-icon="mdi-magnify"
                        label="Trình Độ"
                        v-bind="attrs"
                        v-on="on"
                      ></v-text-field>
                    </template>
                  </v-tooltip>
                </v-col>
                <v-col
                  cols="12"
                  md="12"
                  class="pl-md-0"
                  style="padding: 0px 12px 0px 12px"
                >
                  <v-autocomplete
                    v-model="valTinhChatCongViec"
                    :items="tinhchatcongviec"
                    label="Tính Chất Công Việc"
                  ></v-autocomplete>
                </v-col>
                <v-col cols="12" md="12" class="pl-md-0">
                  <v-autocomplete
                    v-model="valThoiGianThuViec"
                    :items="thoigianthuviec"
                    label="Thời Gian Thử Việc"
                  ></v-autocomplete>
                </v-col>
                <v-col
                  cols="12"
                  md="12"
                  style="padding: 0px 12px 0px 12px"
                  class="pl-md-0"
                >
                  <v-text-field
                    v-model="valHinhThuc"
                    :items="hinhthuc"
                    label="Hình Thức"
                  ></v-text-field>
                </v-col>

                <v-col cols="12" md="12" class="pl-md-0">
                  <v-autocomplete
                    v-model="valNganhNghe"
                    :items="nganhnghe"
                    label="Ngành Nghề"
                  ></v-autocomplete>
                </v-col>
              </v-col>
            </v-col>
          </v-row> -->
          <v-card-title>
            <v-row>
              <v-col cols="12" md="12">
                <ul>
                  <li><a class="active" href="#mota">Mô Tả</a></li>
                  <li><a href="#yeucau">Yêu Cầu</a></li>
                  <li><a href="#quyenloi">Quyền Lợi</a></li>
                </ul>
              </v-col>
            </v-row>
          </v-card-title>
        </v-container>
      </v-col>
    </v-row>
  </v-container>
</template>
<style scoped>
ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
  overflow: hidden;
  background-color: #333;
}

li {
  float: left;
}

li a {
  display: block;
  color: white;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
}

li a:hover:not(.active) {
  background-color: #111;
}

.active {
  background-color: #4caf50;
}
</style>
