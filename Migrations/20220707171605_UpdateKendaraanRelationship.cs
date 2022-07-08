using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Silika.Migrations
{
    public partial class UpdateKendaraanRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kendaraan",
                columns: table => new
                {
                    KendaraanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NoPintu = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    NoPolisi = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    MerkKendaraanId = table.Column<int>(type: "integer", nullable: true),
                    TipeKendaraanId = table.Column<int>(type: "integer", nullable: true),
                    JenisKendaraanId = table.Column<int>(type: "integer", nullable: true),
                    Fungsi = table.Column<short>(type: "smallint", nullable: true),
                    BidangAsalId = table.Column<Guid>(type: "uuid", nullable: true),
                    KabupatenAsalId = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    KecamatanAsalId = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    BidangPenugasanId = table.Column<Guid>(type: "uuid", nullable: true),
                    KabupatenPenugasanId = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    KecamatanPenugasanId = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    TahunPengadaan = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    NoRangka = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    KonsumsiBBM = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kendaraan", x => x.KendaraanId);
                    table.ForeignKey(
                        name: "FK_Kendaraan_Bidang_BidangAsalId",
                        column: x => x.BidangAsalId,
                        principalTable: "Bidang",
                        principalColumn: "BidangID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kendaraan_Bidang_BidangPenugasanId",
                        column: x => x.BidangPenugasanId,
                        principalTable: "Bidang",
                        principalColumn: "BidangID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kendaraan_JenisKendaraan_JenisKendaraanId",
                        column: x => x.JenisKendaraanId,
                        principalTable: "JenisKendaraan",
                        principalColumn: "JenisID");
                    table.ForeignKey(
                        name: "FK_Kendaraan_Kabupaten_KabupatenAsalId",
                        column: x => x.KabupatenAsalId,
                        principalTable: "Kabupaten",
                        principalColumn: "KabupatenID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kendaraan_Kabupaten_KabupatenPenugasanId",
                        column: x => x.KabupatenPenugasanId,
                        principalTable: "Kabupaten",
                        principalColumn: "KabupatenID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kendaraan_Kecamatan_KecamatanAsalId",
                        column: x => x.KecamatanAsalId,
                        principalTable: "Kecamatan",
                        principalColumn: "KecamatanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kendaraan_Kecamatan_KecamatanPenugasanId",
                        column: x => x.KecamatanPenugasanId,
                        principalTable: "Kecamatan",
                        principalColumn: "KecamatanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kendaraan_MerkKendaraan_MerkKendaraanId",
                        column: x => x.MerkKendaraanId,
                        principalTable: "MerkKendaraan",
                        principalColumn: "MerkKendaraanId");
                    table.ForeignKey(
                        name: "FK_Kendaraan_TipeKendaraan_TipeKendaraanId",
                        column: x => x.TipeKendaraanId,
                        principalTable: "TipeKendaraan",
                        principalColumn: "TipeKendaraanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_BidangAsalId",
                table: "Kendaraan",
                column: "BidangAsalId");

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_BidangPenugasanId",
                table: "Kendaraan",
                column: "BidangPenugasanId");

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_JenisKendaraanId",
                table: "Kendaraan",
                column: "JenisKendaraanId");

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_KabupatenAsalId",
                table: "Kendaraan",
                column: "KabupatenAsalId");

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_KabupatenPenugasanId",
                table: "Kendaraan",
                column: "KabupatenPenugasanId");

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_KecamatanAsalId",
                table: "Kendaraan",
                column: "KecamatanAsalId");

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_KecamatanPenugasanId",
                table: "Kendaraan",
                column: "KecamatanPenugasanId");

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_MerkKendaraanId",
                table: "Kendaraan",
                column: "MerkKendaraanId");

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_TipeKendaraanId",
                table: "Kendaraan",
                column: "TipeKendaraanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kendaraan");
        }
    }
}
