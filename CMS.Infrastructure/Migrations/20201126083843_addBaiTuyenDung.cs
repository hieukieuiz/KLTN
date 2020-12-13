using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Infrastructure.Migrations
{
    public partial class addBaiTuyenDung : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnhDaiDien",
                table: "BaiTuyenDung",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HienThi",
                table: "BaiTuyenDung",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "KyHieu",
                table: "BaiTuyenDung",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkAnhMinhHoa",
                table: "BaiTuyenDung",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnhDaiDien",
                table: "BaiTuyenDung");

            migrationBuilder.DropColumn(
                name: "HienThi",
                table: "BaiTuyenDung");

            migrationBuilder.DropColumn(
                name: "KyHieu",
                table: "BaiTuyenDung");

            migrationBuilder.DropColumn(
                name: "LinkAnhMinhHoa",
                table: "BaiTuyenDung");
        }
    }
}
