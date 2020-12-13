using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Infrastructure.Migrations
{
    public partial class ver12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BietQuaFaceBook",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BietQuaGioiThieu",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BietQuaWeb",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cmtnd",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DaDienDu",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkAnhCaNhan",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkAnhMatSau",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkAnhMatTruoc",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkFaceBook",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkSkype",
                table: "HocVien",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkZalo",
                table: "HocVien",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NamThu",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuanHuyenId",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenKhoa",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenNguoiGioiThieu",
                table: "HocVien",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TruongDaiHocId",
                table: "HocVien",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "XaPhuongId",
                table: "HocVien",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuanHuyen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TinhThanhId = table.Column<int>(nullable: false),
                    TenQuanHuyen = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanHuyen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuanHuyen_TinhThanh_TinhThanhId",
                        column: x => x.TinhThanhId,
                        principalTable: "TinhThanh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TruongDaiHoc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTruongDaiHoc = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruongDaiHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "XaPhuong",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuanHuyenId = table.Column<int>(nullable: false),
                    TenXaPhuong = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XaPhuong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XaPhuong_QuanHuyen_QuanHuyenId",
                        column: x => x.QuanHuyenId,
                        principalTable: "QuanHuyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HocVien_QuanHuyenId",
                table: "HocVien",
                column: "QuanHuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_HocVien_TruongDaiHocId",
                table: "HocVien",
                column: "TruongDaiHocId");

            migrationBuilder.CreateIndex(
                name: "IX_HocVien_XaPhuongId",
                table: "HocVien",
                column: "XaPhuongId");

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_TinhThanhId",
                table: "QuanHuyen",
                column: "TinhThanhId");

            migrationBuilder.CreateIndex(
                name: "IX_XaPhuong_QuanHuyenId",
                table: "XaPhuong",
                column: "QuanHuyenId");

            migrationBuilder.AddForeignKey(
                name: "FK_HocVien_QuanHuyen_QuanHuyenId",
                table: "HocVien",
                column: "QuanHuyenId",
                principalTable: "QuanHuyen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HocVien_TruongDaiHoc_TruongDaiHocId",
                table: "HocVien",
                column: "TruongDaiHocId",
                principalTable: "TruongDaiHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HocVien_XaPhuong_XaPhuongId",
                table: "HocVien",
                column: "XaPhuongId",
                principalTable: "XaPhuong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HocVien_QuanHuyen_QuanHuyenId",
                table: "HocVien");

            migrationBuilder.DropForeignKey(
                name: "FK_HocVien_TruongDaiHoc_TruongDaiHocId",
                table: "HocVien");

            migrationBuilder.DropForeignKey(
                name: "FK_HocVien_XaPhuong_XaPhuongId",
                table: "HocVien");

            migrationBuilder.DropTable(
                name: "TruongDaiHoc");

            migrationBuilder.DropTable(
                name: "XaPhuong");

            migrationBuilder.DropTable(
                name: "QuanHuyen");

            migrationBuilder.DropIndex(
                name: "IX_HocVien_QuanHuyenId",
                table: "HocVien");

            migrationBuilder.DropIndex(
                name: "IX_HocVien_TruongDaiHocId",
                table: "HocVien");

            migrationBuilder.DropIndex(
                name: "IX_HocVien_XaPhuongId",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "BietQuaFaceBook",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "BietQuaGioiThieu",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "BietQuaWeb",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "Cmtnd",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "DaDienDu",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "LinkAnhCaNhan",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "LinkAnhMatSau",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "LinkAnhMatTruoc",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "LinkFaceBook",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "LinkSkype",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "LinkZalo",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "NamThu",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "QuanHuyenId",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "TenKhoa",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "TenNguoiGioiThieu",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "TruongDaiHocId",
                table: "HocVien");

            migrationBuilder.DropColumn(
                name: "XaPhuongId",
                table: "HocVien");
        }
    }
}
