using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Infrastructure.Migrations
{
    public partial class ver11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DuAn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDuAn = table.Column<string>(nullable: true),
                    ThoiGianTao = table.Column<DateTime>(nullable: true),
                    ThoiGianCapNhat = table.Column<DateTime>(nullable: true),
                    ThoiGianHetHan = table.Column<DateTime>(nullable: true),
                    MoTa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiCongViec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiCongViec = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiCongViec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quyen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinhThanh",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTinhThanh = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhThanh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrangThai",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuyenDuAn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuAnId = table.Column<int>(nullable: false),
                    QuyenId = table.Column<int>(nullable: true)
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
                name: "HocVien",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TinhThanhId = table.Column<int>(nullable: true),
                    HoTen = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "Date", nullable: true),
                    Sdt = table.Column<string>(nullable: true),
                    Account = table.Column<string>(maxLength: 150, nullable: true),
                    Email = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HocVien_TinhThanh_TinhThanhId",
                        column: x => x.TinhThanhId,
                        principalTable: "TinhThanh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiDuAn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuAnId = table.Column<int>(nullable: true),
                    TrangThaiId = table.Column<int>(nullable: true),
                    ThoiGianTao = table.Column<DateTime>(nullable: false)
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
                name: "ThanhVienDuAn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HocVienId = table.Column<int>(nullable: true),
                    QuyenDuAnId = table.Column<int>(nullable: true),
                    NgayThamGia = table.Column<DateTime>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "CongViec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongViec = table.Column<string>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: false),
                    NgayHetHan = table.Column<DateTime>(nullable: false),
                    TyLeHoanThanh = table.Column<double>(nullable: false),
                    MoTaCongViec = table.Column<string>(nullable: true),
                    DoUuTien = table.Column<string>(nullable: true),
                    NgayHoanThanh = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    DuAnId = table.Column<int>(nullable: true),
                    TrangThaiId = table.Column<int>(nullable: true),
                    LoaiCongViecId = table.Column<int>(nullable: true),
                    ThanhVienDuAnId = table.Column<int>(nullable: true)
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
                        name: "FK_CongViec_LoaiCongViec_LoaiCongViecId",
                        column: x => x.LoaiCongViecId,
                        principalTable: "LoaiCongViec",
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CongViecId = table.Column<int>(nullable: true),
                    TrangThaiId = table.Column<int>(nullable: true),
                    TenChiTietCongViec = table.Column<string>(nullable: true),
                    NgayHetHan = table.Column<DateTime>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CongViecId = table.Column<int>(nullable: true),
                    ThanhVienDuAnId = table.Column<int>(nullable: true),
                    NgayPhanViec = table.Column<DateTime>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChiTietCongViecId = table.Column<int>(nullable: true),
                    ThanhVienDuAnId = table.Column<int>(nullable: true),
                    NoiDung = table.Column<string>(nullable: true),
                    ThoiGianTao = table.Column<DateTime>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThaiId = table.Column<int>(nullable: true),
                    ChiTietCongViecId = table.Column<int>(nullable: true),
                    ThanhVienDuAnId = table.Column<int>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true),
                    ThuTu = table.Column<int>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true)
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_HocVien_TinhThanhId",
                table: "HocVien",
                column: "TinhThanhId");

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
                name: "IX_TrangThaiDuAn_DuAnId",
                table: "TrangThaiDuAn",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiDuAn_TrangThaiId",
                table: "TrangThaiDuAn",
                column: "TrangThaiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BaoCao");

            migrationBuilder.DropTable(
                name: "LichSuChiTietCongViec");

            migrationBuilder.DropTable(
                name: "PhanViec");

            migrationBuilder.DropTable(
                name: "TrangThaiDuAn");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ChiTietCongViec");

            migrationBuilder.DropTable(
                name: "CongViec");

            migrationBuilder.DropTable(
                name: "LoaiCongViec");

            migrationBuilder.DropTable(
                name: "ThanhVienDuAn");

            migrationBuilder.DropTable(
                name: "TrangThai");

            migrationBuilder.DropTable(
                name: "HocVien");

            migrationBuilder.DropTable(
                name: "QuyenDuAn");

            migrationBuilder.DropTable(
                name: "TinhThanh");

            migrationBuilder.DropTable(
                name: "DuAn");

            migrationBuilder.DropTable(
                name: "Quyen");
        }
    }
}
