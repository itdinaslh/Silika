using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Silika.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JenisKendaraan",
                columns: table => new
                {
                    JenisID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaJenis = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisKendaraan", x => x.JenisID);
                });

            migrationBuilder.CreateTable(
                name: "JenisPencemaran",
                columns: table => new
                {
                    JenisID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaJenis = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisPencemaran", x => x.JenisID);
                });

            migrationBuilder.CreateTable(
                name: "JenisTps",
                columns: table => new
                {
                    JenisID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaJenis = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisTps", x => x.JenisID);
                });

            migrationBuilder.CreateTable(
                name: "JenisWr",
                columns: table => new
                {
                    JenisID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaJenis = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    NoRekening = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisWr", x => x.JenisID);
                });

            migrationBuilder.CreateTable(
                name: "MerkKendaraan",
                columns: table => new
                {
                    MerkID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaMerk = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerkKendaraan", x => x.MerkID);
                });

            migrationBuilder.CreateTable(
                name: "NilaiPencemaran",
                columns: table => new
                {
                    NilaiID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaNilai = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Awal = table.Column<short>(type: "smallint", nullable: false),
                    Akhir = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NilaiPencemaran", x => x.NilaiID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JenisKendaraan");

            migrationBuilder.DropTable(
                name: "JenisPencemaran");

            migrationBuilder.DropTable(
                name: "JenisTps");

            migrationBuilder.DropTable(
                name: "JenisWr");

            migrationBuilder.DropTable(
                name: "MerkKendaraan");

            migrationBuilder.DropTable(
                name: "NilaiPencemaran");
        }
    }
}
