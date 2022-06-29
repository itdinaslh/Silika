using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Silika.Migrations
{
    public partial class UpdateMerkKerdaraan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KodeMerk",
                table: "MerkKendaraan",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KodeMerk",
                table: "MerkKendaraan");
        }
    }
}
