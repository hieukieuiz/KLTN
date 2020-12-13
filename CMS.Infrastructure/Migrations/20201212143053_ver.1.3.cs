using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Infrastructure.Migrations
{
    public partial class ver13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiTuyenDung_DoanhNghiep_DoanhNghiepId",
                table: "BaiTuyenDung");

            migrationBuilder.AlterColumn<int>(
                name: "DoanhNghiepId",
                table: "BaiTuyenDung",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FileUpload",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    FileSize = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true),
                    FileDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUpload", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BaiTuyenDung_DoanhNghiep_DoanhNghiepId",
                table: "BaiTuyenDung",
                column: "DoanhNghiepId",
                principalTable: "DoanhNghiep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiTuyenDung_DoanhNghiep_DoanhNghiepId",
                table: "BaiTuyenDung");

            migrationBuilder.DropTable(
                name: "FileUpload");

            migrationBuilder.AlterColumn<int>(
                name: "DoanhNghiepId",
                table: "BaiTuyenDung",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BaiTuyenDung_DoanhNghiep_DoanhNghiepId",
                table: "BaiTuyenDung",
                column: "DoanhNghiepId",
                principalTable: "DoanhNghiep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
