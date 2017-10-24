using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hotel.Web01.Migrations
{
    public partial class thuan_000005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Photo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Photo",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Photo",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Photo");
        }
    }
}
