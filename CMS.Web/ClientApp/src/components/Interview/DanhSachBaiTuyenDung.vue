<template>
  <div class="px-3">
    <h3 class="contaier mt-4">QUẢN LÝ DANH SÁCH BÀI TUYỂN DỤNG</h3>
    <v-row>
      <v-col cols="8">
        <v-flex xs12 md4>
          <v-tooltip bottom>
            <template v-slot:activator="{ on }">
              <v-text-field
                v-on="on"
                hide-details
                label="Tìm kiếm"
                append-icon="search"
                v-model="search"
              ></v-text-field>
            </template>
            <span>Ấn enter để tìm kiếm</span>
          </v-tooltip>
        </v-flex>
      </v-col>
      <!-- <v-col cols="2"></v-col> -->
      <v-col cols="4" class="d-flex flex-row-reverse align-end">
        <v-btn
          color="primary"
          @click="ShowModalThemSuaDanhSachBaiTuyenDung(false, {})"
          >Thêm mới</v-btn
        >
      </v-col>
    </v-row>
    <!-- <v-data-table
      :items="danhSachBaiTuyenDung"
      :headers="tableHeader"
      class="elevation-0"
      :items-per-page="5"
    >
      <template v-slot:item.thaotac="{ item }">
        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-btn
              v-on="on"
              color="primary"
              icon
              small
              @click="ShowModalThemSuaDanhSachBaiTuyenDung(true, item)"
              class="ma-0"
            >
              <v-icon size="20">edit</v-icon>
            </v-btn>
          </template>
          <span>Sửa</span>
        </v-tooltip>

        <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-btn
              v-on="on"
              @click="confirmDelete()"
              color="red"
              icon
              small
              class="mx-3 ma-0"
            >
              <v-icon size="20">delete</v-icon>
            </v-btn>
          </template>
          <span>Xóa</span>
        </v-tooltip>
      </template>
    </v-data-table> -->
    <div>
      <modal-them-sua-danh-sach-bai-tuyen-dung
        ref="modalThemSuaDanhSachBaiTuyenDung"
      ></modal-them-sua-danh-sach-bai-tuyen-dung>
      <!-- <modal-them-sua-trang-thai
        ref="modalThemSuaTrangThai"
        @updated="getDanhSachTrangThai(filters)"
      ></modal-them-sua-trang-thai> -->
    </div>
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
            @click="dialogConfirmDelete = false"
            >Xác Nhận</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-container>
      <v-row>
        <v-col col="12" md="4">
          <v-card class="mx-auto" max-width="344" outlined>
            <v-list-item three-line>
              <v-list-item-content>
                <div class="overline mb-4">
                  OVERLINE
                </div>
                <v-list-item-title class="headline mb-1">
                  Headline 5
                </v-list-item-title>
                <v-list-item-subtitle
                  >Greyhound divisely hello coldly
                  fonwderfully</v-list-item-subtitle
                >
              </v-list-item-content>

              <v-list-item-avatar
                tile
                size="80"
                color="grey"
              ></v-list-item-avatar>
            </v-list-item>

            <v-card-actions>
              <v-btn outlined rounded text>
                Button
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-col>
        <v-col col="12" md="4">
          <v-card class="mx-auto" max-width="344" outlined>
            <v-list-item three-line>
              <v-list-item-content>
                <div class="overline mb-4">
                  OVERLINE
                </div>
                <v-list-item-title class="headline mb-1">
                  Headline 5
                </v-list-item-title>
                <v-list-item-subtitle
                  >Greyhound divisely hello coldly
                  fonwderfully</v-list-item-subtitle
                >
              </v-list-item-content>

              <v-list-item-avatar
                tile
                size="80"
                color="grey"
              ></v-list-item-avatar>
            </v-list-item>

            <v-card-actions>
              <v-btn outlined rounded text>
                Button
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-col>
        <v-col col="12" md="4">
          <v-card class="mx-auto" max-width="344" outlined>
            <v-list-item three-line>
              <v-list-item-content>
                <div class="overline mb-5">
                  Tuyển dụng lập trình viên Java
                </div>
                <v-list-item-title class="headline mb-1">
                  Headline 5
                </v-list-item-title>
                <v-list-item-subtitle
                  >Greyhound divisely hello coldly
                  fonwderfully</v-list-item-subtitle
                >
              </v-list-item-content>

              <v-list-item-avatar
                tile
                size="80"
                color="grey"
              ></v-list-item-avatar>
            </v-list-item>

            <v-card-actions>
              <v-btn
                outlined
                rounded
                text
                v-on="on"
                color="primary"
                icon
                small
                @click="ShowModalThemSuaDanhSachBaiTuyenDung(true, item)"
                class="ma-0"
              >
                <v-icon size="20">edit</v-icon>
              </v-btn>
              <v-btn
                v-on="on"
                @click="confirmDelete()"
                color="red"
                icon
                small
                class="mx-3 ma-0"
              >
                <v-icon size="20">delete</v-icon>
              </v-btn>
              <!-- <template v-slot:item.thaotac="{ item }">
                <v-tooltip top>
                  <template v-slot:activator="{ on }">
                    <v-btn
                      v-on="on"
                      color="primary"
                      icon
                      small
                      @click="ShowModalThemSuaDanhSachBaiTuyenDung(true, item)"
                      class="ma-0"
                    >
                      <v-icon size="20">edit</v-icon>
                    </v-btn>
                  </template>
                  <span>Sửa</span>
                </v-tooltip>

                <v-tooltip top>
                  <template v-slot:activator="{ on }">
                    <v-btn
                      v-on="on"
                      @click="confirmDelete()"
                      color="red"
                      icon
                      small
                      class="mx-3 ma-0"
                    >
                      <v-icon size="20">delete</v-icon>
                    </v-btn>
                  </template>
                  <span>Xóa</span>
                </v-tooltip>
              </template> -->
            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script lang="ts">
import { Vue } from "vue-property-decorator";
// import { TrangThaiDTO } from "@/models/TaskManagement/TrangThaiDTO";
// import TrangThaiApi, {
//   GetTrangThaiParams,
// } from "../../apiResources/TaskManagement/TrangThaiApi";
import ModalThemSuaDanhSachBaiTuyenDung from "./ModalThemSuaDanhSachBaiTuyenDung.vue";
export default Vue.extend({
  components: {
    ModalThemSuaDanhSachBaiTuyenDung,
  },
  data() {
    return {
      search: "",
      dialogConfirmDelete: false,
      tableHeader: [
        {
          text: "Tên Danh Sách Bài Tuyển Dụng",
          value: "TenDanhSachBaiTuyenDung",
          fixed: true,
          width: "150px",
          sortable: false,
          align: "center",
        },

        {
          text: "Thao tác",
          value: "thaotac",
          fixed: true,
          width: "120px",
          sortable: false,
          align: "center",
        },
      ],
      // danhSachBaiTuyenDung: [
      //   {
      //     TenDanhSachBaiTuyenDung: "Tuyen Lap Trinh Vien Java",
      //   },
      // ],
      totalItems: 0 as number | undefined,
      loading: false,
    };
  },
  methods: {
    confirmDelete(item: any): void {
      this.dialogConfirmDelete = true;
    },
    ShowModalThemSuaDanhSachBaiTuyenDung(isUpdate: boolean, item: any) {
      (this.$refs.modalThemSuaDanhSachBaiTuyenDung as any).show(isUpdate, item);
    },
  },
});
</script>
