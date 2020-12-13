<template>
  <v-container
    style="background-color: #fff; min-height: auto"
    class="q-card-shadow q-card-border mt-3"
  >
    <v-row>
      <v-col cols="12" style="background-color: #0000">
        <h3>ĐÁNH GIÁ ỨNG VIÊN TỰ DO</h3>
      </v-col>

      <v-col cols="12" md="5" style="padding: 0px 12px">
        <v-row>
          <v-col md="12" style="padding: 0px 12px">
            <v-tooltip top>
              <template v-slot:activator="{ on, attrs }">
                <v-text-field
                  v-model="search"
                  append-icon="mdi-account-tie"
                  label="Học viên"
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
              <span>Học viên</span>
            </v-tooltip>
          </v-col>

          <v-col md="12" style="padding: 0px 12px 0px 12px">
            <v-tooltip top>
              <template v-slot:activator="{ on, attrs }">
                <v-text-field
                  v-model="search"
                  append-icon="mdi-clipboard-play-multiple"
                  label="Kỹ năng"
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
              <span>Kỹ năng</span>
            </v-tooltip>
          </v-col>
          <v-col md="12" style="padding: 0px 12px 0px 12px">
            <v-tooltip top>
              <template v-slot:activator="{ on, attrs }">
                <v-text-field
                  v-model="search"
                  append-icon="mdi-progress-clock"
                  label="Đăng ký"
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
              <span>Đăng ký</span>
            </v-tooltip>
          </v-col>
        </v-row>
      </v-col>

      <v-col cols="12" md="4" style="padding: 17px 12px 0px 12px">
        <a href="#"><i>(Xem CV)</i></a>
      </v-col>

      <v-col cols="12" md="3" style="padding: 0px 12px; text-align: center">
        <v-tooltip top>
          <template v-slot:activator="{ on, attrs }">
            <v-avatar size="175" v-bind="attrs" v-on="on">
              <img src="https://cdn.vuetifyjs.com/images/john.jpg" alt="John"
            /></v-avatar>
          </template>
          <span>Ảnh Avatar</span>
        </v-tooltip>
      </v-col>
    </v-row>

    <v-row>
      <template>
        <v-expansion-panels focusable style="margin: 12px" outline color="red">
          <v-expansion-panel>
            <v-expansion-panel-header style="font-size: 18px"
              >A. Nhóm kỹ năng lập trình
              <template v-slot:actions>
                <v-icon color="primary"> mdi-menu-down-outline </v-icon>
              </template>
            </v-expansion-panel-header>
            <v-expansion-panel-content>
              <v-row style="padding-left: 79px">
                <v-col
                  cols="12"
                  md="5"
                  style="padding: 0px 12px; margin-top: 30px"
                >
                  <v-row>
                    <v-col cols="5" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on, attrs }">
                          <v-text-field
                            v-model="search"
                            append-icon="mdi-clipboard-list"
                            label="1. Học dự án"
                            v-bind="attrs"
                            v-on="on"
                          ></v-text-field>
                        </template>
                        <span>Học dự án</span>
                      </v-tooltip>
                    </v-col>
                    <v-col
                      cols="1"
                      style="
                        padding: 0px;
                        text-align: center;
                        align-self: center;
                        padding-left: 18px;
                      "
                    >
                      {{ chonSao }}
                    </v-col>
                    <v-col cols="1" style="padding: 0px; margin-top: 17px">
                      <v-icon color="red">mdi-star</v-icon>
                    </v-col>
                    <!-- <v-col cols="2" style="padding: 0px; margin-top: 20px">
                      <a @click="dialogChonSao = true"><i>(Sửa)</i></a>
                    </v-col> -->

                    <!-- hvit danh gia  -->
                    <v-col cols="10" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on }">
                          <v-textarea
                            v-on="on"
                            outlined
                            rows="2"
                            style="border-radius: inherit"
                          ></v-textarea>
                        </template>
                        <span>Ứng viên tự đánh giá</span>
                      </v-tooltip>
                    </v-col>
                    <!-- end hvit danh gia -->
                  </v-row>

                  <v-row>
                    <v-col cols="5" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on, attrs }">
                          <v-text-field
                            v-model="search"
                            append-icon="mdi-clipboard-list"
                            label="1. Học dự án"
                            v-bind="attrs"
                            v-on="on"
                          ></v-text-field>
                        </template>
                        <span>Học dự án</span>
                      </v-tooltip>
                    </v-col>
                    <v-col
                      cols="1"
                      style="
                        padding: 0px;
                        text-align: center;
                        align-self: center;
                        padding-left: 18px;
                      "
                    >
                      {{ chonSao }}
                    </v-col>
                    <v-col cols="1" style="padding: 0px; margin-top: 17px">
                      <v-icon color="red">mdi-star</v-icon>
                    </v-col>
                    <!-- <v-col cols="2" style="padding: 0px; margin-top: 20px">
                      <a @click="dialogChonSao = true"><i>(Sửa)</i></a>
                    </v-col> -->

                    <!-- hvit danh gia  -->
                    <v-col cols="10" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on }">
                          <v-textarea
                            v-on="on"
                            outlined
                            rows="2"
                            style="border-radius: inherit"
                          ></v-textarea>
                        </template>
                        <span>Ứng viên tự đánh giá</span>
                      </v-tooltip>
                    </v-col>
                    <!-- end hvit danh gia -->
                  </v-row>
                </v-col>

                <v-col cols="12" md="2">
                  <div
                    style="
                      width: 1px;
                      background-color: rgb(228 228 229);
                      position: absolute;
                      top: 64px;
                      bottom: 0px;
                      margin-left: 38px;
                    "
                  ></div>
                </v-col>

                <v-col
                  cols="12"
                  md="5"
                  style="padding: 0px 12px; margin-top: 30px"
                >
                  <v-row>
                    <v-col cols="5" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on, attrs }">
                          <v-text-field
                            v-model="search"
                            append-icon="mdi-clipboard-list"
                            label="1. Học dự án"
                            v-bind="attrs"
                            v-on="on"
                          ></v-text-field>
                        </template>
                        <span>Học dự án</span>
                      </v-tooltip>
                    </v-col>
                    <v-col
                      cols="1"
                      style="
                        padding: 0px;
                        text-align: center;
                        align-self: center;
                        padding-left: 18px;
                      "
                    >
                      {{ chonSao }}
                    </v-col>
                    <v-col cols="1" style="padding: 0px; margin-top: 17px">
                      <v-icon color="orange">mdi-star</v-icon>
                    </v-col>
                    <v-col cols="2" style="padding: 0px; margin-top: 20px">
                      <a @click="dialogChonSao = true"><i>(Sửa)</i></a>
                    </v-col>

                    <!-- hvit danh gia  -->
                    <v-col cols="10" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on }">
                          <v-textarea
                            v-on="on"
                            outlined
                            rows="2"
                            style="border-radius: inherit"
                          ></v-textarea>
                        </template>
                        <span>Hvit đánh giá</span>
                      </v-tooltip>
                    </v-col>
                    <!-- end hvit danh gia -->
                  </v-row>

                  <v-row>
                    <v-col cols="5" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on, attrs }">
                          <v-text-field
                            v-model="search"
                            append-icon="mdi-clipboard-list"
                            label="1. Học dự án"
                            v-bind="attrs"
                            v-on="on"
                          ></v-text-field>
                        </template>
                        <span>Học dự án</span>
                      </v-tooltip>
                    </v-col>
                    <v-col
                      cols="1"
                      style="
                        padding: 0px;
                        text-align: center;
                        align-self: center;
                        padding-left: 18px;
                      "
                    >
                      {{ chonSao }}
                    </v-col>
                    <v-col cols="1" style="padding: 0px; margin-top: 17px">
                      <v-icon color="orange">mdi-star</v-icon>
                    </v-col>
                    <v-col cols="2" style="padding: 0px; margin-top: 20px">
                      <a @click="dialogChonSao = true"><i>(Sửa)</i></a>
                    </v-col>

                    <!-- hvit danh gia  -->
                    <v-col cols="10" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on }">
                          <v-textarea
                            v-on="on"
                            outlined
                            rows="2"
                            style="border-radius: inherit"
                          ></v-textarea>
                        </template>
                        <span>Hvit đánh giá</span>
                      </v-tooltip>
                    </v-col>
                    <!-- end hvit danh gia -->
                  </v-row>

                  <v-row>
                    <v-col cols="5" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on, attrs }">
                          <v-text-field
                            v-model="search"
                            append-icon="mdi-clipboard-list"
                            label="1. Học dự án"
                            v-bind="attrs"
                            v-on="on"
                          ></v-text-field>
                        </template>
                        <span>Học dự án</span>
                      </v-tooltip>
                    </v-col>
                    <v-col
                      cols="1"
                      style="
                        padding: 0px;
                        text-align: center;
                        align-self: center;
                        padding-left: 18px;
                      "
                    >
                      {{ chonSao }}
                    </v-col>
                    <v-col cols="1" style="padding: 0px; margin-top: 17px">
                      <v-icon color="orange">mdi-star</v-icon>
                    </v-col>
                    <v-col cols="2" style="padding: 0px; margin-top: 20px">
                      <a @click="dialogChonSao = true"><i>(Sửa)</i></a>
                    </v-col>

                    <!-- hvit danh gia  -->
                    <v-col cols="10" style="padding: 0px 12px">
                      <v-tooltip top>
                        <template v-slot:activator="{ on }">
                          <v-textarea
                            v-on="on"
                            outlined
                            rows="2"
                            style="border-radius: inherit"
                          ></v-textarea>
                        </template>
                        <span>Hvit đánh giá</span>
                      </v-tooltip>
                    </v-col>
                    <!-- end hvit danh gia -->
                  </v-row>
                </v-col>
              </v-row>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </template>
      <!-- dialog chon sao -->
      <v-dialog v-model="dialogChonSao" max-width="270px">
        <v-card>
          <v-card-title style="padding: 10px">
            <span>Đánh giá ứng viên</span>
            <v-spacer></v-spacer>
            <v-btn class="ma-0 mr-1" icon small @click="dialogChonSao = false">
              <v-icon color="red">mdi-close</v-icon>
            </v-btn>
          </v-card-title>
          <v-card-actions>
            <v-rating
              v-model="chonSao"
              background-color="red"
              color="orange"
              size="18"
            ></v-rating>
          </v-card-actions>
        </v-card>
      </v-dialog>

      <!-- end chon sao -->
    </v-row>
    <!-- end nhóm kỹ năng lập trình -->

    <v-row style="margin-top: 20px">
      <v-col cols="12" md="4" style="padding: 0px 12px">
        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-autocomplete
              clearable
              v-on="on"
              v-model="valDanhGia"
              :items="danhGiaChung"
              label="Tổng"
            ></v-autocomplete>
          </template>
          <span>Đánh giá chung ứng viên</span>
        </v-tooltip>
      </v-col>

      <v-col cols="4" style="padding: 0px 12px">
        <v-tooltip top>
          <template v-slot:activator="{ on, attrs }">
            <v-text-field
              v-model="search"
              append-icon="mdi-star"
              label="Trọng số"
              v-bind="attrs"
              v-on="on"
            ></v-text-field>
          </template>
          <span>Trung bình số sao đánh giá</span>
        </v-tooltip>
      </v-col>

      <v-col cols="4" style="text-align: end">
        <v-btn color="primary">Lưu</v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      chonSao: 4,
      search: "C/C++",
      dialogChonSao: false,
      danhGiaChung: ["Tốt", "Khá", "Trung bình", "yếu"],
      valDanhGia: null,
    };
  },
};
</script>
<style scoped></style>
