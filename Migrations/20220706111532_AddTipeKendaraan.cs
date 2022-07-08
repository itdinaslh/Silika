using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Silika.Migrations
{
    public partial class AddTipeKendaraan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MerkID",
                table: "MerkKendaraan",
                newName: "MerkKendaraanId");

            migrationBuilder.CreateTable(
                name: "TipeKendaraan",
                columns: table => new
                {
                    TipeKendaraanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MerkKendaraanId = table.Column<int>(type: "integer", nullable: true),
                    NamaTipe = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipeKendaraan", x => x.TipeKendaraanId);
                    table.ForeignKey(
                        name: "FK_TipeKendaraan_MerkKendaraan_MerkKendaraanId",
                        column: x => x.MerkKendaraanId,
                        principalTable: "MerkKendaraan",
                        principalColumn: "MerkKendaraanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipeKendaraan_MerkKendaraanId",
                table: "TipeKendaraan",
                column: "MerkKendaraanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipeKendaraan");

            migrationBuilder.RenameColumn(
                name: "MerkKendaraanId",
                table: "MerkKendaraan",
                newName: "MerkID");
        }
    }
}
