using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Silika.Migrations
{
    public partial class Bidang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bidang",
                columns: table => new
                {
                    BidangID = table.Column<Guid>(type: "uuid", nullable: false),
                    NamaBidang = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    KepalaBidang = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidang", x => x.BidangID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bidang");
        }
    }
}
