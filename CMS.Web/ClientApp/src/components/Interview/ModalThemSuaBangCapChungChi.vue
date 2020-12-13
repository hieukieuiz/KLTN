<template>
  <v-row justify="center">
    <v-dialog v-model="isShow" persistent max-width="600px">
      <v-card>
        <v-card-title class="headline primary">
          {{
            isUpdate
              ? "Cập nhật bằng cấp, chứng chỉ"
              : "Thêm mới bằng cấp, chứng chỉ"
          }}
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12">
                <v-text-field label="Tên bằng" required></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-datepicker label="Ngày cấp" required></v-datepicker>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="isShow = false">
            Hủy
          </v-btn>
          <v-btn color="blue darken-1" text @click="isShow = false">
            {{ isUpdate ? "Cập nhật" : "Thêm mới" }}
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>
<script lang="ts">
import { Vue } from "vue-property-decorator";
export default Vue.extend({
  data: () => ({
    isShow: false,
    isUpdate: false,
  }),
  methods: {
    hide(): void {
      this.isShow = false;
    },
    show(isUpdate: boolean, item: any): void {
      this.isShow = true;
      this.isUpdate = isUpdate;
    },
  },
});
</script>
