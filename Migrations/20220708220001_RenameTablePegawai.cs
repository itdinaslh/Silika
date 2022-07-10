using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Silika.Migrations
{
    public partial class RenameTablePegawai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kendaraan_JenisKendaraan_JenisKendaraanId",
                table: "Kendaraan");

            migrationBuilder.DropForeignKey(
                name: "FK_Pegawais_Bidang_BidangId",
                table: "Pegawais");

            migrationBuilder.DropForeignKey(
                name: "FK_Pegawais_Kabupaten_KabupatenId",
                table: "Pegawais");

            migrationBuilder.DropForeignKey(
                name: "FK_Pegawais_Kecamatan_KecamatanId",
                table: "Pegawais");

            migrationBuilder.DropForeignKey(
                name: "FK_Pegawais_Kelurahan_KelurahanId",
                table: "Pegawais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pegawais",
                table: "Pegawais");

            migrationBuilder.RenameTable(
                name: "Pegawais",
                newName: "Pegawai");

            migrationBuilder.RenameIndex(
                name: "IX_Pegawais_KelurahanId",
                table: "Pegawai",
                newName: "IX_Pegawai_KelurahanId");

            migrationBuilder.RenameIndex(
                name: "IX_Pegawais_KecamatanId",
                table: "Pegawai",
                newName: "IX_Pegawai_KecamatanId");

            migrationBuilder.RenameIndex(
                name: "IX_Pegawais_KabupatenId",
                table: "Pegawai",
                newName: "IX_Pegawai_KabupatenId");

            migrationBuilder.RenameIndex(
                name: "IX_Pegawais_BidangId",
                table: "Pegawai",
                newName: "IX_Pegawai_BidangId");

            migrationBuilder.AlterColumn<int>(
                name: "JenisKendaraanId",
                table: "Kendaraan",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pegawai",
                table: "Pegawai",
                column: "PegawaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kendaraan_JenisKendaraan_JenisKendaraanId",
                table: "Kendaraan",
                column: "JenisKendaraanId",
                principalTable: "JenisKendaraan",
                principalColumn: "JenisID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pegawai_Bidang_BidangId",
                table: "Pegawai",
                column: "BidangId",
                principalTable: "Bidang",
                principalColumn: "BidangID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pegawai_Kabupaten_KabupatenId",
                table: "Pegawai",
                column: "KabupatenId",
                principalTable: "Kabupaten",
                principalColumn: "KabupatenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pegawai_Kecamatan_KecamatanId",
                table: "Pegawai",
                column: "KecamatanId",
                principalTable: "Kecamatan",
                principalColumn: "KecamatanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pegawai_Kelurahan_KelurahanId",
                table: "Pegawai",
                column: "KelurahanId",
                principalTable: "Kelurahan",
                principalColumn: "KelurahanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kendaraan_JenisKendaraan_JenisKendaraanId",
                table: "Kendaraan");

            migrationBuilder.DropForeignKey(
                name: "FK_Pegawai_Bidang_BidangId",
                table: "Pegawai");

            migrationBuilder.DropForeignKey(
                name: "FK_Pegawai_Kabupaten_KabupatenId",
                table: "Pegawai");

            migrationBuilder.DropForeignKey(
                name: "FK_Pegawai_Kecamatan_KecamatanId",
                table: "Pegawai");

            migrationBuilder.DropForeignKey(
                name: "FK_Pegawai_Kelurahan_KelurahanId",
                table: "Pegawai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pegawai",
                table: "Pegawai");

            migrationBuilder.RenameTable(
                name: "Pegawai",
                newName: "Pegawais");

            migrationBuilder.RenameIndex(
                name: "IX_Pegawai_KelurahanId",
                table: "Pegawais",
                newName: "IX_Pegawais_KelurahanId");

            migrationBuilder.RenameIndex(
                name: "IX_Pegawai_KecamatanId",
                table: "Pegawais",
                newName: "IX_Pegawais_KecamatanId");

            migrationBuilder.RenameIndex(
                name: "IX_Pegawai_KabupatenId",
                table: "Pegawais",
                newName: "IX_Pegawais_KabupatenId");

            migrationBuilder.RenameIndex(
                name: "IX_Pegawai_BidangId",
                table: "Pegawais",
                newName: "IX_Pegawais_BidangId");

            migrationBuilder.AlterColumn<int>(
                name: "JenisKendaraanId",
                table: "Kendaraan",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pegawais",
                table: "Pegawais",
                column: "PegawaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kendaraan_JenisKendaraan_JenisKendaraanId",
                table: "Kendaraan",
                column: "JenisKendaraanId",
                principalTable: "JenisKendaraan",
                principalColumn: "JenisID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pegawais_Bidang_BidangId",
                table: "Pegawais",
                column: "BidangId",
                principalTable: "Bidang",
                principalColumn: "BidangID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pegawais_Kabupaten_KabupatenId",
                table: "Pegawais",
                column: "KabupatenId",
                principalTable: "Kabupaten",
                principalColumn: "KabupatenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pegawais_Kecamatan_KecamatanId",
                table: "Pegawais",
                column: "KecamatanId",
                principalTable: "Kecamatan",
                principalColumn: "KecamatanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pegawais_Kelurahan_KelurahanId",
                table: "Pegawais",
                column: "KelurahanId",
                principalTable: "Kelurahan",
                principalColumn: "KelurahanID");
        }
    }
}
