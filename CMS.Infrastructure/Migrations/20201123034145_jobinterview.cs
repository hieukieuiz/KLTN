using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Infrastructure.Migrations
{
    public partial class jobinterview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiThi_HocVien_HocVienId",
                table: "BaiThi");

            migrationBuilder.DropTable(
                name: "BaoCao");

            migrationBuilder.DropTable(
                name: "LichSuChiTietCongViec");

            migrationBuilder.DropTable(
                name: "PhanViec");

            migrationBuilder.DropTable(
                name: "TrangThaiDuAn");

            migrationBuilder.DropTable(
                name: "ChiTietCongViec");

            migrationBuilder.DropTable(
                name: "CongViec");

            migrationBuilder.DropTable(
                name: "LoaiCongViec1");

            migrationBuilder.DropTable(
                name: "ThanhVienDuAn");

            migrationBuilder.DropTable(
                name: "HocVien");

            migrationBuilder.DropTable(
                name: "QuyenDuAn");

            migrationBuilder.DropTable(
                name: "DuAn");

            migrationBuilder.DropTable(
                name: "Quyen");

            migrationBuilder.DropIndex(
                name: "IX_BaiThi_HocVienId",
                table: "BaiThi");

            migrationBuilder.DropColumn(
                name: "HocVienId",
                table: "BaiThi");

            migrationBuilder.AddColumn<int>(
                name: "UngVienId",
                table: "BaiThi",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaiThi_UngVienId",
                table: "BaiThi",
                column: "UngVienId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiThi_UngVien_UngVienId",
                table: "BaiThi",
                column: "UngVienId",
                principalTable: "UngVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiThi_UngVien_UngVienId",
                table: "BaiThi");

            migrationBuilder.DropIndex(
                name: "IX_BaiThi_UngVienId",
                table: "BaiThi");

            migrationBuilder.DropColumn(
                name: "UngVienId",
                table: "BaiThi");

            migrationBuilder.AddColumn<int>(
                name: "HocVienId",
                table: "BaiThi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DuAn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDuAn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianHetHan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HocVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BietQuaFaceBook = table.Column<bool>(type: "bit", nullable: true),
                    BietQuaGioiThieu = table.Column<bool>(type: "bit", nullable: true),
                    BietQuaWeb = table.Column<bool>(type: "bit", nullable: true),
                    Cmtnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaDienDu = table.Column<bool>(type: "bit", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAnhCaNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAnhMatSau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAnhMatTruoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkFaceBook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkSkype = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LinkZalo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NamThu = table.Column<int>(type: "int", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "Date", nullable: true),
                    QuanHuyenId = table.Column<int>(type: "int", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNguoiGioiThieu = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TinhThanhId = table.Column<int>(type: "int", nullable: true),
                    TruongDaiHocId = table.Column<int>(type: "int", nullable: true),
                    XaPhuongId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HocVien_QuanHuyen_QuanHuyenId",
                        column: x => x.QuanHuyenId,
                        principalTable: "QuanHuyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HocVien_TinhThanh_TinhThanhId",
                        column: x => x.TinhThanhId,
                        principalTable: "TinhThanh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HocVien_TruongDaiHoc_TruongDaiHocId",
                        column: x => x.TruongDaiHocId,
                        principalTable: "TruongDaiHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HocVien_XaPhuong_XaPhuongId",
                        column: x => x.XaPhuongId,
                        principalTable: "XaPhuong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoaiCongViec1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiCongViec = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiCongViec1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiDuAn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuAnId = table.Column<int>(type: "int", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThaiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiDuAn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrangThaiDuAn_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrangThaiDuAn_TrangThai_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "TrangThai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuyenDuAn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuAnId = table.Column<int>(type: "int", nullable: false),
                    QuyenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenDuAn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyenDuAn_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyenDuAn_Quyen_QuyenId",
                        column: x => x.QuyenId,
                        principalTable: "Quyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThanhVienDuAn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HocVienId = table.Column<int>(type: "int", nullable: true),
                    NgayThamGia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuyenDuAnId = table.Column<int>(type: "int", nullable: true),
                    UngVienId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhVienDuAn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhVienDuAn_HocVien_HocVienId",
                        column: x => x.HocVienId,
                        principalTable: "HocVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThanhVienDuAn_QuyenDuAn_QuyenDuAnId",
                        column: x => x.QuyenDuAnId,
                        principalTable: "QuyenDuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThanhVienDuAn_UngVien_UngVienId",
                        column: x => x.UngVienId,
                        principalTable: "UngVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CongViec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoUuTien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuAnId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LoaiCongViecId = table.Column<int>(type: "int", nullable: true),
                    MoTaCongViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHoanThanh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenCongViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThanhVienDuAnId = table.Column<int>(type: "int", nullable: true),
                    TrangThaiId = table.Column<int>(type: "int", nullable: true),
                    TyLeHoanThanh = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongViec", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CongViec_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CongViec_LoaiCongViec1_LoaiCongViecId",
                        column: x => x.LoaiCongViecId,
                        principalTable: "LoaiCongViec1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CongViec_ThanhVienDuAn_ThanhVienDuAnId",
                        column: x => x.ThanhVienDuAnId,
                        principalTable: "ThanhVienDuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CongViec_TrangThai_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "TrangThai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietCongViec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CongViecId = table.Column<int>(type: "int", nullable: true),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenChiTietCongViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietCongViec", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietCongViec_CongViec_CongViecId",
                        column: x => x.CongViecId,
                        principalTable: "CongViec",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietCongViec_TrangThai_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "TrangThai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhanViec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CongViecId = table.Column<int>(type: "int", nullable: true),
                    NgayPhanViec = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThanhVienDuAnId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanViec", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanViec_CongViec_CongViecId",
                        column: x => x.CongViecId,
                        principalTable: "CongViec",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhanViec_ThanhVienDuAn_ThanhVienDuAnId",
                        column: x => x.ThanhVienDuAnId,
                        principalTable: "ThanhVienDuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaoCao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChiTietCongViecId = table.Column<int>(type: "int", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThanhVienDuAnId = table.Column<int>(type: "int", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaoCao_ChiTietCongViec_ChiTietCongViecId",
                        column: x => x.ChiTietCongViecId,
                        principalTable: "ChiTietCongViec",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaoCao_ThanhVienDuAn_ThanhVienDuAnId",
                        column: x => x.ThanhVienDuAnId,
                        principalTable: "ThanhVienDuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LichSuChiTietCongViec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChiTietCongViecId = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThanhVienDuAnId = table.Column<int>(type: "int", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: true),
                    TrangThaiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuChiTietCongViec", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichSuChiTietCongViec_ChiTietCongViec_ChiTietCongViecId",
                        column: x => x.ChiTietCongViecId,
                        principalTable: "ChiTietCongViec",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LichSuChiTietCongViec_ThanhVienDuAn_ThanhVienDuAnId",
                        column: x => x.ThanhVienDuAnId,
                        principalTable: "ThanhVienDuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LichSuChiTietCongViec_TrangThai_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "TrangThai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiThi_HocVienId",
                table: "BaiThi",
                column: "HocVienId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCao_ChiTietCongViecId",
                table: "BaoCao",
                column: "ChiTietCongViecId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCao_ThanhVienDuAnId",
                table: "BaoCao",
                column: "ThanhVienDuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCongViec_CongViecId",
                table: "ChiTietCongViec",
                column: "CongViecId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCongViec_TrangThaiId",
                table: "ChiTietCongViec",
                column: "TrangThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_CongViec_DuAnId",
                table: "CongViec",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_CongViec_LoaiCongViecId",
                table: "CongViec",
                column: "LoaiCongViecId");

            migrationBuilder.CreateIndex(
                name: "IX_CongViec_ThanhVienDuAnId",
                table: "CongViec",
                column: "ThanhVienDuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_CongViec_TrangThaiId",
                table: "CongViec",
                column: "TrangThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_HocVien_QuanHuyenId",
                table: "HocVien",
                column: "QuanHuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_HocVien_TinhThanhId",
                table: "HocVien",
                column: "TinhThanhId");

            migrationBuilder.CreateIndex(
                name: "IX_HocVien_TruongDaiHocId",
                table: "HocVien",
                column: "TruongDaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_HocVien_XaPhuongId",
                table: "HocVien",
                column: "XaPhuongId");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuChiTietCongViec_ChiTietCongViecId",
                table: "LichSuChiTietCongViec",
                column: "ChiTietCongViecId");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuChiTietCongViec_ThanhVienDuAnId",
                table: "LichSuChiTietCongViec",
                column: "ThanhVienDuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuChiTietCongViec_TrangThaiId",
                table: "LichSuChiTietCongViec",
                column: "TrangThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanViec_CongViecId",
                table: "PhanViec",
                column: "CongViecId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanViec_ThanhVienDuAnId",
                table: "PhanViec",
                column: "ThanhVienDuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenDuAn_DuAnId",
                table: "QuyenDuAn",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenDuAn_QuyenId",
                table: "QuyenDuAn",
                column: "QuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienDuAn_HocVienId",
                table: "ThanhVienDuAn",
                column: "HocVienId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienDuAn_QuyenDuAnId",
                table: "ThanhVienDuAn",
                column: "QuyenDuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienDuAn_UngVienId",
                table: "ThanhVienDuAn",
                column: "UngVienId");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiDuAn_DuAnId",
                table: "TrangThaiDuAn",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiDuAn_TrangThaiId",
                table: "TrangThaiDuAn",
                column: "TrangThaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiThi_HocVien_HocVienId",
                table: "BaiThi",
                column: "HocVienId",
                principalTable: "HocVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
