import Vue from "vue";
import Router, { Route } from "vue-router";
import QuanLyTaiKhoan from "./components/Interview/QuanLyTaiKhoan.vue";
import UserApi from './apiResources/UserApi';
//import QuanLyHocVien from "./components/NguoiDung/QuanLyHocVien.vue";
import QuanLyTrangThai from "./components/NguoiDung/QuanLyTrangThai.vue";
import QuanLyDuAn from "./components/NguoiDung/QuanLyDuAn.vue";
import QuanLyCongViec from "./components/NguoiDung/QuanLyCongViec.vue";
//import QuanLyQuyen from "./components/NguoiDung/QuanLyQuyen.vue";
import QuanLyLoaiCongViec from "./components/NguoiDung/QuanLyLoaiCongViec.vue";
import DuAnCuaToi from "./components/NguoiDung/DuAnCuaToi.vue";
import ThongTinCaNhanUngVien from "./components/Interview/ThongTinCaNhanUngVien.vue";
import QuanLyUngVien from "./components/Interview/QuanLyUngVien.vue";
import DanhSachBaiDangTuyen from "./components/Interview/DanhSachBaiDangTuyen.vue";
import DanhSachUngVien from "./components/Interview/DanhSachUngVien.vue";
//import DanhSachUngVien from "./components/Interview/DanhSachUngVien.vue";
//import KhoaHoc from "./components/Interview/KhoaHoc.vue"
import QuanLyDoanhNghiep from "./components/Interview/QuanLyDoanhNghiep.vue";
import CVUngVien from "./components/Interview/CVUngVien.vue";
import BaiTuyenDung from "./components/Interview/BaiTuyenDung.vue";
import ChiTietThongTin from "./components/Interview/ChiTietThongTin.vue";
import TrangThai from "./components/Interview/TrangThai.vue";
import NhomKyNang from "./components/Interview/NhomKyNang.vue";
import KyNang from "./components/Interview/KyNang.vue";
//import QuanLyQuyen from "./components/Interview/QuanLyQuyen.vue";
Vue.use(Router);
export default new Router({
  routes: [
    {
      path: "/admin/quanlytaikhoan",
      name: "quanlytaikhoan",
      component: QuanLyTaiKhoan,
      beforeEnter: guardRoute,
    },
    // {
    //   path: "/admin/quanlyquyen",
    //   name: "quanlyquyen",
    //   component: QuanLyQuyen,
    //   beforeEnter: guardRoute,
    // },
    // {
    //   path: "/nguoidung/quanlyhocvien",
    //   name: "quanlyhocvien",
    //   component: QuanLyHocVien,
    //   beforeEnter: guardRoute,
    // },
    {
      path: "/nguoidung/quanlyduan",
      name: "quanlyduan",
      component: QuanLyDuAn,
      beforeEnter: guardRoute,
    },
    {
      path: "/nguoidung/quanlyduan/:duAnId",
      name: "quanlycongviec",
      component: QuanLyCongViec,
      beforeEnter: guardRoute,
    },
    {
      path: "/nguoidung/quanlytrangthai",
      name: "quanlytrangthai",
      component: QuanLyTrangThai,
      beforeEnter: guardRoute,
    },
    // {
    //   path: "/nguoidung/quanlyquyen",
    //   name: "quanlyquyen",
    //   component: QuanLyQuyen,
    //   beforeEnter: guardRoute,
    // },
    {
      path: "/nguoidung/quanlyloaicongviec",
      name: "quanlyloaicongviec",
      component: QuanLyLoaiCongViec,
      beforeEnter: guardRoute,
    },
    {
      path: "/hocvien/duancuatoi",
      name: "duancuatoi",
      component: DuAnCuaToi,
      beforeEnter: guardRoute,
    },
    {
      path: "/ungvien/thongtincanhan",
      name: "thongtincanhan",
      component: ThongTinCaNhanUngVien,
      beforeEnter: guardRoute,
    },
    {
      path: "/ungvien/quanlyungvien",
      name: "quanlyungvien",
      component: QuanLyUngVien,
      beforeEnter: guardRoute,
    },
    // {
    //   path: "/ungvien/quanlyhocvien",
    //   name: "quanlyhocvien",
    //   component: QuanLyHocVien,
    //   beforeEnter: guardRoute,
    // },
    {
      path: "/ungvien/danhsachungvien",
      name: "danhsachungvien",
      component: DanhSachUngVien,
      beforeEnter: guardRoute,
    },
    {
      path: "/admin/danhsachungvien",
      name: "danhsachungvien",
      component: DanhSachUngVien,
      beforeEnter: guardRoute,
    },
    {
      path: "/ungvien/danhsachbaidangtuyen",
      name: "danhsachbaidangtuyen",
      component: DanhSachBaiDangTuyen,
      beforeEnter: guardRoute,
    },
    {
      path: "/doanhnghiep/danhsachbaidangtuyen",
      name: "danhsachbaidangtuyen",
      component: DanhSachBaiDangTuyen,
      beforeEnter: guardRoute,
    },
    {
      path: "/ungvien/quanlydoanhnghiep",
      name: "quanlydoanhnghiep",
      component: QuanLyDoanhNghiep,
      beforeEnter: guardRoute,
    },
    {
      path: "/admin/quanlydoanhnghiep",
      name: "quanlydoanhnghiep",
      component: QuanLyDoanhNghiep,
      beforeEnter: guardRoute,
    },
    {
      path: "/doanhnghiep/quanlydoanhnghiep",
      name: "quanlydoanhnghiep",
      component: QuanLyDoanhNghiep,
      beforeEnter: guardRoute,
    },
    {
      path: "/ungvien/cvungvien",
      name: "cvungvien",
      component: CVUngVien,
      beforeEnter: guardRoute,
    },
    {
      path: "/ungvien/nhomkynang",
      name: "nhomkynang",
      component: NhomKyNang,
      beforeEnter: guardRoute,
    },
    {
      path: "/ungvien/kynang",
      name: "kynang",
      component: KyNang,
      beforeEnter: guardRoute,
    },
    {
      path: "/admin/nhomkynang",
      name: "nhomkynang",
      component: NhomKyNang,
      beforeEnter: guardRoute,
    },
    {
      path: "/admin/kynang",
      name: "kynang",
      component: KyNang,
      beforeEnter: guardRoute,
    },
    {
      path: "/ungvien/cvungvien/:ungVienId",
      name: "cvungvien",
      component: CVUngVien,
      beforeEnter: guardRoute,
    },
    {
      path: "/ungvien/baituyendung",
      name: "baituyendung",
      component: BaiTuyenDung,
      beforeEnter: guardRoute,
    },
    {
      path: "/doanhnghiep/baituyendung",
      name: "baituyendung",
      component: BaiTuyenDung,
      beforeEnter: guardRoute,
    },
    {
      path: "/admin/baituyendung",
      name: "baituyendung",
      component: BaiTuyenDung,
      beforeEnter: guardRoute,
    },
    {
      path: "/ungvien/trangthai",
      name: "trangthai",
      component: TrangThai,
      beforeEnter: guardRoute,
    },
    {
      path: "/admin/trangthai",
      name: "trangthai",
      component: TrangThai,
      beforeEnter: guardRoute,
    },
    {
      path: "/ungvien/danhsachbaidangtuyen/:baiTuyenDungId",
      name: "chitietthongtinbaidangtuyen",
      component: ChiTietThongTin,
      beforeEnter: guardRoute,
    },
    // {
    //   path: "/ungvien/khoahoc",
    //   name: "khoahoc",
    //   component: KhoaHoc,
    //   beforeEnter: guardRoute,
    // },
    // {
    //   path: "/ungvien/danhsachungvien",
    //   name: "danhsachungvien",
    //   component: DanhSachUngVien,
    //   beforeEnter: guardRoute,
    // },
  ],
});

function guardRoute(to: Route, from: Route, next: any): void {
    UserApi.getMyRoles().then(res => {
        if(res.length > 0)  {
            next();
        } else {
            window.location.href = '/Identity/Account/Login';
        }
    })
    .catch(err => {
       window.location.href = '/Identity/Account/Login';
    });
}
