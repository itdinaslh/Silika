using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Silika.Migrations
{
    public partial class UpdateJenisKendaraan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KodeJenis",
                table: "JenisKendaraan",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KodeJenis",
                table: "JenisKendaraan");
        }
    }
}
