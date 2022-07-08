using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Silika.Migrations
{
    public partial class UpdateMerkJenisKend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KodeMerk",
                table: "MerkKendaraan",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KodeJenis",
                table: "JenisKendaraan",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KodeMerk",
                table: "MerkKendaraan");

            migrationBuilder.DropColumn(
                name: "KodeJenis",
                table: "JenisKendaraan");
        }
    }
}
