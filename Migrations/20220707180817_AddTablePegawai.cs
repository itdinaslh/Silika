using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Silika.Migrations
{
    public partial class AddTablePegawai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Kendaraan",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Kendaraan",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Kendaraan",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pegawais",
                columns: table => new
                {
                    PegawaiId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaPegawai = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NIK = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    TglLahir = table.Column<DateOnly>(type: "date", nullable: false),
                    NoHP = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    TipePegawai = table.Column<int>(type: "integer", nullable: false),
                    StatusAktif = table.Column<bool>(type: "boolean", nullable: false),
                    TahunMasuk = table.Column<short>(type: "smallint", nullable: true),
                    Catatan = table.Column<string>(type: "text", nullable: true),
                    BidangId = table.Column<Guid>(type: "uuid", nullable: true),
                    KabupatenId = table.Column<string>(type: "character varying(10)", nullable: true),
                    KecamatanId = table.Column<string>(type: "character varying(10)", nullable: true),
                    KelurahanId = table.Column<string>(type: "character varying(15)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pegawais", x => x.PegawaiId);
                    table.ForeignKey(
                        name: "FK_Pegawais_Bidang_BidangId",
                        column: x => x.BidangId,
                        principalTable: "Bidang",
                        principalColumn: "BidangID");
                    table.ForeignKey(
                        name: "FK_Pegawais_Kabupaten_KabupatenId",
                        column: x => x.KabupatenId,
                        principalTable: "Kabupaten",
                        principalColumn: "KabupatenID");
                    table.ForeignKey(
                        name: "FK_Pegawais_Kecamatan_KecamatanId",
                        column: x => x.KecamatanId,
                        principalTable: "Kecamatan",
                        principalColumn: "KecamatanID");
                    table.ForeignKey(
                        name: "FK_Pegawais_Kelurahan_KelurahanId",
                        column: x => x.KelurahanId,
                        principalTable: "Kelurahan",
                        principalColumn: "KelurahanID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pegawais_BidangId",
                table: "Pegawais",
                column: "BidangId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawais_KabupatenId",
                table: "Pegawais",
                column: "KabupatenId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawais_KecamatanId",
                table: "Pegawais",
                column: "KecamatanId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawais_KelurahanId",
                table: "Pegawais",
                column: "KelurahanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pegawais");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Kendaraan");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Kendaraan");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Kendaraan");
        }
    }
}
