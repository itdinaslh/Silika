using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Silika.Migrations
{
    public partial class CreateTipePegawai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipePegawai",
                table: "Pegawai",
                newName: "TipePegawaiId");

            migrationBuilder.CreateTable(
                name: "TipePegawai",
                columns: table => new
                {
                    TipePegawaiId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaTipe = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipePegawai", x => x.TipePegawaiId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_TipePegawaiId",
                table: "Pegawai",
                column: "TipePegawaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pegawai_TipePegawai_TipePegawaiId",
                table: "Pegawai",
                column: "TipePegawaiId",
                principalTable: "TipePegawai",
                principalColumn: "TipePegawaiId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pegawai_TipePegawai_TipePegawaiId",
                table: "Pegawai");

            migrationBuilder.DropTable(
                name: "TipePegawai");

            migrationBuilder.DropIndex(
                name: "IX_Pegawai_TipePegawaiId",
                table: "Pegawai");

            migrationBuilder.RenameColumn(
                name: "TipePegawaiId",
                table: "Pegawai",
                newName: "TipePegawai");
        }
    }
}
