using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CongViec_LoaiCongViec_LoaiCongViecId",
                table: "CongViec");

            migrationBuilder.DropColumn(
                name: "TenLoaiCongViec",
                table: "LoaiCongViec");

            migrationBuilder.AddColumn<int>(
                name: "UngVienId",
                table: "ThanhVienDuAn",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BaiThiId",
                table: "LoaiCongViec",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BaiTuyenDungId",
                table: "LoaiCongViec",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiemPass",
                table: "LoaiCongViec",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DangCauHoi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangCauHoi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangCauHoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoanhNghiep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayUngTuyen = table.Column<DateTime>(nullable: true),
                    TenDoanhNghiep = table.Column<string>(nullable: true),
                    LogoDoanhNghiep = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    SĐT = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    GioiThieu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhNghiep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhoCauHoi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoCauHoi = table.Column<string>(nullable: true),
                    KyHieuKho = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoCauHoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinhVucThi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLinhVucThi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhVucThi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiCongViec1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiCongViec = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiCongViec1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiYeuCau",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiYeuCau = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiYeuCau", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MucDo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMucDo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MucDo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhomKyNang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhomKyNang = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomKyNang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UngVien",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TinhThanhId = table.Column<int>(nullable: true),
                    QuanHuyenId = table.Column<int>(nullable: true),
                    XaPhuongId = table.Column<int>(nullable: true),
                    TruongDaiHocId = table.Column<int>(nullable: true),
                    HoTen = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "Date", nullable: true),
                    Sdt = table.Column<string>(nullable: true),
                    Account = table.Column<string>(maxLength: 150, nullable: true),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    Cmtnd = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    LinkAnhCaNhan = table.Column<string>(nullable: true),
                    LinkAnhMatTruoc = table.Column<string>(nullable: true),
                    LinkAnhMatSau = table.Column<string>(nullable: true),
                    BietQuaFaceBook = table.Column<bool>(nullable: true),
                    BietQuaWeb = table.Column<bool>(nullable: true),
                    BietQuaGioiThieu = table.Column<bool>(nullable: true),
                    TenNguoiGioiThieu = table.Column<string>(maxLength: 150, nullable: true),
                    LinkFaceBook = table.Column<string>(nullable: true),
                    LinkSkype = table.Column<string>(maxLength: 200, nullable: true),
                    LinkZalo = table.Column<string>(maxLength: 200, nullable: true),
                    DaDienDu = table.Column<bool>(nullable: true),
                    TenKhoa = table.Column<string>(nullable: true),
                    NamThu = table.Column<int>(nullable: true),
                    TrangThaiId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UngVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UngVien_QuanHuyen_QuanHuyenId",
                        column: x => x.QuanHuyenId,
                        principalTable: "QuanHuyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UngVien_TinhThanh_TinhThanhId",
                        column: x => x.TinhThanhId,
                        principalTable: "TinhThanh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UngVien_TrangThai_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "TrangThai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UngVien_TruongDaiHoc_TruongDaiHocId",
                        column: x => x.TruongDaiHocId,
                        principalTable: "TruongDaiHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UngVien_XaPhuong_XaPhuongId",
                        column: x => x.XaPhuongId,
                        principalTable: "XaPhuong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaiTuyenDung",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(nullable: true),
                    NgayDang = table.Column<string>(nullable: true),
                    SoLuongTuyen = table.Column<string>(nullable: true),
                    ThanhPho = table.Column<string>(nullable: true),
                    MucLuong = table.Column<string>(nullable: true),
                    KinhNghiem = table.Column<string>(nullable: true),
                    GioiTinh = table.Column<string>(nullable: true),
                    TrinhDo = table.Column<string>(nullable: true),
                    TinhChatCongViec = table.Column<string>(nullable: true),
                    HinhThuc = table.Column<string>(nullable: true),
                    ThoiGianThuViec = table.Column<string>(nullable: true),
                    NganhNghe = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    QuyenLoi = table.Column<string>(nullable: true),
                    DoanhNghiepId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiTuyenDung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaiTuyenDung_DoanhNghiep_DoanhNghiepId",
                        column: x => x.DoanhNghiepId,
                        principalTable: "DoanhNghiep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeThi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDeThi = table.Column<string>(nullable: true),
                    Guid = table.Column<Guid>(nullable: false),
                    LinhVucThiId = table.Column<int>(nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    ThoiGianHieuLuc = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    HienThiSoThuTu = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsShowPublic = table.Column<bool>(nullable: false),
                    SoCau = table.Column<int>(nullable: true),
                    ThoiGianLamBai = table.Column<int>(nullable: true),
                    LaVoHanHieuLuc = table.Column<bool>(nullable: false),
                    PhuongThucTao = table.Column<int>(nullable: true),
                    BaoNgayKetQua = table.Column<bool>(nullable: false),
                    TrangThaiXuatBan = table.Column<int>(nullable: false),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    MetaRobots = table.Column<string>(nullable: true),
                    MetaUrl = table.Column<string>(nullable: true),
                    MetaImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeThi_LinhVucThi_LinhVucThiId",
                        column: x => x.LinhVucThiId,
                        principalTable: "LinhVucThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CauHoi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCauHoi = table.Column<string>(nullable: true),
                    KyHieu = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    TienTo = table.Column<string>(nullable: true),
                    HauTo = table.Column<string>(nullable: true),
                    DangCauHoiId = table.Column<int>(nullable: false),
                    KhoCauHoiId = table.Column<int>(nullable: true),
                    MucDoId = table.Column<int>(nullable: true),
                    GiaTriDapAn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHoi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CauHoi_DangCauHoi_DangCauHoiId",
                        column: x => x.DangCauHoiId,
                        principalTable: "DangCauHoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CauHoi_KhoCauHoi_KhoCauHoiId",
                        column: x => x.KhoCauHoiId,
                        principalTable: "KhoCauHoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CauHoi_MucDo_MucDoId",
                        column: x => x.MucDoId,
                        principalTable: "MucDo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KyNang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKyNang = table.Column<string>(nullable: true),
                    NhomKyNangId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KyNang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KyNang_NhomKyNang_NhomKyNangId",
                        column: x => x.NhomKyNangId,
                        principalTable: "NhomKyNang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CVUngVien",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgaySinh = table.Column<string>(nullable: true),
                    GioiTinh = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    MucTieuCaNhan = table.Column<string>(nullable: true),
                    SoThich = table.Column<string>(nullable: true),
                    UngVienId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVUngVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVUngVien_UngVien_UngVienId",
                        column: x => x.UngVienId,
                        principalTable: "UngVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhGiaChungUngVien",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DanhGiaChungCuaHvit = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    UngVienId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGiaChungUngVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhGiaChungUngVien_UngVien_UngVienId",
                        column: x => x.UngVienId,
                        principalTable: "UngVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UngVienLamBaiTest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KetQua = table.Column<string>(nullable: true),
                    BaiTestTuyenDungId = table.Column<int>(nullable: true),
                    UngVienId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UngVienLamBaiTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UngVienLamBaiTest_LoaiCongViec_BaiTestTuyenDungId",
                        column: x => x.BaiTestTuyenDungId,
                        principalTable: "LoaiCongViec",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UngVienLamBaiTest_UngVien_UngVienId",
                        column: x => x.UngVienId,
                        principalTable: "UngVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UngTuyen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayUngTuyen = table.Column<DateTime>(nullable: true),
                    KetQua = table.Column<string>(nullable: true),
                    DanhGiaCuaNhaTuyenDung = table.Column<string>(nullable: true),
                    BaiTuyenDungId = table.Column<int>(nullable: true),
                    UngVienId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UngTuyen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UngTuyen_BaiTuyenDung_BaiTuyenDungId",
                        column: x => x.BaiTuyenDungId,
                        principalTable: "BaiTuyenDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UngTuyen_UngVien_UngVienId",
                        column: x => x.UngVienId,
                        principalTable: "UngVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YeuCau",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenYeuCau = table.Column<string>(nullable: true),
                    GiaTriSoTu = table.Column<string>(nullable: true),
                    GiaTriSoDen = table.Column<string>(nullable: true),
                    GiaTriNoiDung = table.Column<string>(nullable: true),
                    BaiTuyenDungId = table.Column<int>(nullable: true),
                    LoaiYeuCauId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeuCau", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YeuCau_BaiTuyenDung_BaiTuyenDungId",
                        column: x => x.BaiTuyenDungId,
                        principalTable: "BaiTuyenDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YeuCau_LoaiYeuCau_LoaiYeuCauId",
                        column: x => x.LoaiYeuCauId,
                        principalTable: "LoaiYeuCau",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaiThi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeThiId = table.Column<int>(nullable: false),
                    TaiKhoan = table.Column<string>(nullable: true),
                    ThoiGianTao = table.Column<DateTime>(nullable: false),
                    ThoiGianHoanThanh = table.Column<DateTime>(nullable: true),
                    NgayCham = table.Column<DateTime>(type: "date", nullable: true),
                    TongDiemCham = table.Column<double>(nullable: true),
                    TongDiemToiDa = table.Column<double>(nullable: true),
                    DaNopBai = table.Column<bool>(nullable: false),
                    DaChamDiem = table.Column<bool>(nullable: false),
                    DaBaoKetQua = table.Column<bool>(nullable: false),
                    HocVienId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaiThi_DeThi_DeThiId",
                        column: x => x.DeThiId,
                        principalTable: "DeThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaiThi_HocVien_HocVienId",
                        column: x => x.HocVienId,
                        principalTable: "HocVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CauHinhDoKho",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeThiId = table.Column<int>(nullable: false),
                    MucDoId = table.Column<int>(nullable: true),
                    SoLuongCauHoi = table.Column<int>(nullable: true),
                    Diem = table.Column<double>(nullable: false),
                    DaoDapAn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHinhDoKho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CauHinhDoKho_DeThi_DeThiId",
                        column: x => x.DeThiId,
                        principalTable: "DeThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CauHinhDoKho_MucDo_MucDoId",
                        column: x => x.MucDoId,
                        principalTable: "MucDo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HienThiDeThi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoaHocId = table.Column<int>(nullable: true),
                    DeThiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HienThiDeThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HienThiDeThi_DeThi_DeThiId",
                        column: x => x.DeThiId,
                        principalTable: "DeThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguonDeThi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeThiId = table.Column<int>(nullable: false),
                    KhoCauHoiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguonDeThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguonDeThi_DeThi_DeThiId",
                        column: x => x.DeThiId,
                        principalTable: "DeThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguonDeThi_KhoCauHoi_KhoCauHoiId",
                        column: x => x.KhoCauHoiId,
                        principalTable: "KhoCauHoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDeThi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeThiId = table.Column<int>(nullable: false),
                    CauHoiId = table.Column<int>(nullable: false),
                    BatBuocTraLoi = table.Column<bool>(nullable: false),
                    ThuTu = table.Column<int>(nullable: false),
                    HienThiSoThuTu = table.Column<bool>(nullable: true),
                    PhuThuocVaoCauHoiId = table.Column<int>(nullable: true),
                    GiaTriPhuThuoc = table.Column<string>(nullable: true),
                    DiemToiDa = table.Column<double>(nullable: false),
                    DaoDapAn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDeThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietDeThi_CauHoi_CauHoiId",
                        column: x => x.CauHoiId,
                        principalTable: "CauHoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDeThi_DeThi_DeThiId",
                        column: x => x.DeThiId,
                        principalTable: "DeThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DapAnCauHoi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CauHoiId = table.Column<int>(nullable: false),
                    TenDapAn = table.Column<string>(nullable: true),
                    GiaTri = table.Column<string>(nullable: true),
                    ThuTu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DapAnCauHoi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DapAnCauHoi_CauHoi_CauHoiId",
                        column: x => x.CauHoiId,
                        principalTable: "CauHoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KyNangUngVien",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuDanhGia = table.Column<string>(nullable: true),
                    TuRating = table.Column<string>(nullable: true),
                    HvitDanhGia = table.Column<string>(nullable: true),
                    HvitRating = table.Column<string>(nullable: true),
                    KyNangId = table.Column<int>(nullable: true),
                    UngVienId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KyNangUngVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KyNangUngVien_KyNang_KyNangId",
                        column: x => x.KyNangId,
                        principalTable: "KyNang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KyNangUngVien_UngVien_UngVienId",
                        column: x => x.UngVienId,
                        principalTable: "UngVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BangCapUngVien",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayCap = table.Column<DateTime>(nullable: true),
                    TenBang = table.Column<string>(nullable: true),
                    CVUngVienId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangCapUngVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BangCapUngVien_CVUngVien_CVUngVienId",
                        column: x => x.CVUngVienId,
                        principalTable: "CVUngVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuaTrinhHocTap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianBatDau = table.Column<DateTime>(nullable: true),
                    ThoiGianKetThuc = table.Column<DateTime>(nullable: true),
                    NoiHocTap = table.Column<string>(nullable: true),
                    ChuyenNganh = table.Column<string>(nullable: true),
                    CVUngVienId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuaTrinhHocTap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuaTrinhHocTap_CVUngVien_CVUngVienId",
                        column: x => x.CVUngVienId,
                        principalTable: "CVUngVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuaTrinhLamDuAn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianBatDau = table.Column<DateTime>(nullable: true),
                    ThoiGianKetThuc = table.Column<DateTime>(nullable: true),
                    TenCongTy = table.Column<string>(nullable: true),
                    ViTri = table.Column<string>(nullable: true),
                    MoTaNganDuAn = table.Column<string>(nullable: true),
                    KyNang = table.Column<string>(nullable: true),
                    CVUngVienId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuaTrinhLamDuAn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuaTrinhLamDuAn_CVUngVien_CVUngVienId",
                        column: x => x.CVUngVienId,
                        principalTable: "CVUngVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietBaiThi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaiThiId = table.Column<int>(nullable: false),
                    CauHoiId = table.Column<int>(nullable: false),
                    CauTraLoi = table.Column<string>(nullable: true),
                    DiemCham = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietBaiThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietBaiThi_BaiThi_BaiThiId",
                        column: x => x.BaiThiId,
                        principalTable: "BaiThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietBaiThi_CauHoi_CauHoiId",
                        column: x => x.CauHoiId,
                        principalTable: "CauHoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDapAnDeThi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChiTietDeThiId = table.Column<int>(nullable: false),
                    DapAnCauHoiId = table.Column<int>(nullable: false),
                    ThuTuMoi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDapAnDeThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietDapAnDeThi_ChiTietDeThi_ChiTietDeThiId",
                        column: x => x.ChiTietDeThiId,
                        principalTable: "ChiTietDeThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietDapAnDeThi_DapAnCauHoi_DapAnCauHoiId",
                        column: x => x.DapAnCauHoiId,
                        principalTable: "DapAnCauHoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienDuAn_UngVienId",
                table: "ThanhVienDuAn",
                column: "UngVienId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiCongViec_BaiThiId",
                table: "LoaiCongViec",
                column: "BaiThiId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiCongViec_BaiTuyenDungId",
                table: "LoaiCongViec",
                column: "BaiTuyenDungId");

            migrationBuilder.CreateIndex(
                name: "IX_BaiThi_DeThiId",
                table: "BaiThi",
                column: "DeThiId");

            migrationBuilder.CreateIndex(
                name: "IX_BaiThi_HocVienId",
                table: "BaiThi",
                column: "HocVienId");

            migrationBuilder.CreateIndex(
                name: "IX_BaiTuyenDung_DoanhNghiepId",
                table: "BaiTuyenDung",
                column: "DoanhNghiepId");

            migrationBuilder.CreateIndex(
                name: "IX_BangCapUngVien_CVUngVienId",
                table: "BangCapUngVien",
                column: "CVUngVienId");

            migrationBuilder.CreateIndex(
                name: "IX_CauHinhDoKho_DeThiId",
                table: "CauHinhDoKho",
                column: "DeThiId");

            migrationBuilder.CreateIndex(
                name: "IX_CauHinhDoKho_MucDoId",
                table: "CauHinhDoKho",
                column: "MucDoId");

            migrationBuilder.CreateIndex(
                name: "IX_CauHoi_DangCauHoiId",
                table: "CauHoi",
                column: "DangCauHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_CauHoi_KhoCauHoiId",
                table: "CauHoi",
                column: "KhoCauHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_CauHoi_MucDoId",
                table: "CauHoi",
                column: "MucDoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietBaiThi_BaiThiId",
                table: "ChiTietBaiThi",
                column: "BaiThiId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietBaiThi_CauHoiId",
                table: "ChiTietBaiThi",
                column: "CauHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDapAnDeThi_ChiTietDeThiId",
                table: "ChiTietDapAnDeThi",
                column: "ChiTietDeThiId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDapAnDeThi_DapAnCauHoiId",
                table: "ChiTietDapAnDeThi",
                column: "DapAnCauHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDeThi_CauHoiId",
                table: "ChiTietDeThi",
                column: "CauHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDeThi_DeThiId",
                table: "ChiTietDeThi",
                column: "DeThiId");

            migrationBuilder.CreateIndex(
                name: "IX_CVUngVien_UngVienId",
                table: "CVUngVien",
                column: "UngVienId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGiaChungUngVien_UngVienId",
                table: "DanhGiaChungUngVien",
                column: "UngVienId");

            migrationBuilder.CreateIndex(
                name: "IX_DapAnCauHoi_CauHoiId",
                table: "DapAnCauHoi",
                column: "CauHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_LinhVucThiId",
                table: "DeThi",
                column: "LinhVucThiId");

            migrationBuilder.CreateIndex(
                name: "IX_HienThiDeThi_DeThiId",
                table: "HienThiDeThi",
                column: "DeThiId");

            migrationBuilder.CreateIndex(
                name: "IX_KyNang_NhomKyNangId",
                table: "KyNang",
                column: "NhomKyNangId");

            migrationBuilder.CreateIndex(
                name: "IX_KyNangUngVien_KyNangId",
                table: "KyNangUngVien",
                column: "KyNangId");

            migrationBuilder.CreateIndex(
                name: "IX_KyNangUngVien_UngVienId",
                table: "KyNangUngVien",
                column: "UngVienId");

            migrationBuilder.CreateIndex(
                name: "IX_NguonDeThi_DeThiId",
                table: "NguonDeThi",
                column: "DeThiId");

            migrationBuilder.CreateIndex(
                name: "IX_NguonDeThi_KhoCauHoiId",
                table: "NguonDeThi",
                column: "KhoCauHoiId");

            migrationBuilder.CreateIndex(
                name: "IX_QuaTrinhHocTap_CVUngVienId",
                table: "QuaTrinhHocTap",
                column: "CVUngVienId");

            migrationBuilder.CreateIndex(
                name: "IX_QuaTrinhLamDuAn_CVUngVienId",
                table: "QuaTrinhLamDuAn",
                column: "CVUngVienId");

            migrationBuilder.CreateIndex(
                name: "IX_UngTuyen_BaiTuyenDungId",
                table: "UngTuyen",
                column: "BaiTuyenDungId");

            migrationBuilder.CreateIndex(
                name: "IX_UngTuyen_UngVienId",
                table: "UngTuyen",
                column: "UngVienId");

            migrationBuilder.CreateIndex(
                name: "IX_UngVien_QuanHuyenId",
                table: "UngVien",
                column: "QuanHuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_UngVien_TinhThanhId",
                table: "UngVien",
                column: "TinhThanhId");

            migrationBuilder.CreateIndex(
                name: "IX_UngVien_TrangThaiId",
                table: "UngVien",
                column: "TrangThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_UngVien_TruongDaiHocId",
                table: "UngVien",
                column: "TruongDaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_UngVien_XaPhuongId",
                table: "UngVien",
                column: "XaPhuongId");

            migrationBuilder.CreateIndex(
                name: "IX_UngVienLamBaiTest_BaiTestTuyenDungId",
                table: "UngVienLamBaiTest",
                column: "BaiTestTuyenDungId");

            migrationBuilder.CreateIndex(
                name: "IX_UngVienLamBaiTest_UngVienId",
                table: "UngVienLamBaiTest",
                column: "UngVienId");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCau_BaiTuyenDungId",
                table: "YeuCau",
                column: "BaiTuyenDungId");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCau_LoaiYeuCauId",
                table: "YeuCau",
                column: "LoaiYeuCauId");

            migrationBuilder.AddForeignKey(
                name: "FK_CongViec_LoaiCongViec1_LoaiCongViecId",
                table: "CongViec",
                column: "LoaiCongViecId",
                principalTable: "LoaiCongViec1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiCongViec_BaiThi_BaiThiId",
                table: "LoaiCongViec",
                column: "BaiThiId",
                principalTable: "BaiThi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoaiCongViec_BaiTuyenDung_BaiTuyenDungId",
                table: "LoaiCongViec",
                column: "BaiTuyenDungId",
                principalTable: "BaiTuyenDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhVienDuAn_UngVien_UngVienId",
                table: "ThanhVienDuAn",
                column: "UngVienId",
                principalTable: "UngVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CongViec_LoaiCongViec1_LoaiCongViecId",
                table: "CongViec");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiCongViec_BaiThi_BaiThiId",
                table: "LoaiCongViec");

            migrationBuilder.DropForeignKey(
                name: "FK_LoaiCongViec_BaiTuyenDung_BaiTuyenDungId",
                table: "LoaiCongViec");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhVienDuAn_UngVien_UngVienId",
                table: "ThanhVienDuAn");

            migrationBuilder.DropTable(
                name: "BangCapUngVien");

            migrationBuilder.DropTable(
                name: "CauHinhDoKho");

            migrationBuilder.DropTable(
                name: "ChiTietBaiThi");

            migrationBuilder.DropTable(
                name: "ChiTietDapAnDeThi");

            migrationBuilder.DropTable(
                name: "DanhGiaChungUngVien");

            migrationBuilder.DropTable(
                name: "HienThiDeThi");

            migrationBuilder.DropTable(
                name: "KyNangUngVien");

            migrationBuilder.DropTable(
                name: "LoaiCongViec1");

            migrationBuilder.DropTable(
                name: "NguonDeThi");

            migrationBuilder.DropTable(
                name: "QuaTrinhHocTap");

            migrationBuilder.DropTable(
                name: "QuaTrinhLamDuAn");

            migrationBuilder.DropTable(
                name: "UngTuyen");

            migrationBuilder.DropTable(
                name: "UngVienLamBaiTest");

            migrationBuilder.DropTable(
                name: "YeuCau");

            migrationBuilder.DropTable(
                name: "BaiThi");

            migrationBuilder.DropTable(
                name: "ChiTietDeThi");

            migrationBuilder.DropTable(
                name: "DapAnCauHoi");

            migrationBuilder.DropTable(
                name: "KyNang");

            migrationBuilder.DropTable(
                name: "CVUngVien");

            migrationBuilder.DropTable(
                name: "BaiTuyenDung");

            migrationBuilder.DropTable(
                name: "LoaiYeuCau");

            migrationBuilder.DropTable(
                name: "DeThi");

            migrationBuilder.DropTable(
                name: "CauHoi");

            migrationBuilder.DropTable(
                name: "NhomKyNang");

            migrationBuilder.DropTable(
                name: "UngVien");

            migrationBuilder.DropTable(
                name: "DoanhNghiep");

            migrationBuilder.DropTable(
                name: "LinhVucThi");

            migrationBuilder.DropTable(
                name: "DangCauHoi");

            migrationBuilder.DropTable(
                name: "KhoCauHoi");

            migrationBuilder.DropTable(
                name: "MucDo");

            migrationBuilder.DropIndex(
                name: "IX_ThanhVienDuAn_UngVienId",
                table: "ThanhVienDuAn");

            migrationBuilder.DropIndex(
                name: "IX_LoaiCongViec_BaiThiId",
                table: "LoaiCongViec");

            migrationBuilder.DropIndex(
                name: "IX_LoaiCongViec_BaiTuyenDungId",
                table: "LoaiCongViec");

            migrationBuilder.DropColumn(
                name: "UngVienId",
                table: "ThanhVienDuAn");

            migrationBuilder.DropColumn(
                name: "BaiThiId",
                table: "LoaiCongViec");

            migrationBuilder.DropColumn(
                name: "BaiTuyenDungId",
                table: "LoaiCongViec");

            migrationBuilder.DropColumn(
                name: "DiemPass",
                table: "LoaiCongViec");

            migrationBuilder.AddColumn<string>(
                name: "TenLoaiCongViec",
                table: "LoaiCongViec",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CongViec_LoaiCongViec_LoaiCongViecId",
                table: "CongViec",
                column: "LoaiCongViecId",
                principalTable: "LoaiCongViec",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
