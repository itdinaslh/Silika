using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Silika.Migrations
{
    public partial class CreateTps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StatusLahan",
                type: "boolean",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tps",
                columns: table => new
                {
                    TpsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TpsCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    JenisTpsId = table.Column<int>(type: "integer", nullable: false),
                    KelurahanID = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    KodePos = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Keterangan = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Longitude = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Alamat = table.Column<string>(type: "text", nullable: false),
                    StatusLahanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tps", x => x.TpsId);
                    table.ForeignKey(
                        name: "FK_Tps_JenisTps_JenisTpsId",
                        column: x => x.JenisTpsId,
                        principalTable: "JenisTps",
                        principalColumn: "JenisID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tps_Kelurahan_KelurahanID",
                        column: x => x.KelurahanID,
                        principalTable: "Kelurahan",
                        principalColumn: "KelurahanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tps_StatusLahan_StatusLahanId",
                        column: x => x.StatusLahanId,
                        principalTable: "StatusLahan",
                        principalColumn: "StatusLahanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tps_JenisTpsId",
                table: "Tps",
                column: "JenisTpsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tps_KelurahanID",
                table: "Tps",
                column: "KelurahanID");

            migrationBuilder.CreateIndex(
                name: "IX_Tps_StatusLahanId",
                table: "Tps",
                column: "StatusLahanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tps");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StatusLahan");
        }
    }
}
