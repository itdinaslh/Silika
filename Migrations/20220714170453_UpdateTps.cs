using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Silika.Migrations
{
    public partial class UpdateTps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tps",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tps",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaTps",
                table: "Tps",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tps",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tps");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tps");

            migrationBuilder.DropColumn(
                name: "NamaTps",
                table: "Tps");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tps");
        }
    }
}
