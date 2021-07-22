using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieShop.Backend.Migrations
{
    public partial class AddSoftDeleteAttr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Ratings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "createDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "modifyDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPBB0001",
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7954), new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7955) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPBB0002",
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7957), new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7959) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPBB0003",
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7962), new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7963) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPM0001",
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2021, 7, 22, 11, 59, 0, 327, DateTimeKind.Local).AddTicks(3727), new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7372) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPM0002",
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7921), new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7927) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPM0003",
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7930), new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7932) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPWM0001",
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7935), new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7936) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPWM0002",
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7938), new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPWM0003",
                columns: new[] { "createDate", "modifyDate" },
                values: new object[] { new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7949), new DateTime(2021, 7, 22, 11, 59, 0, 328, DateTimeKind.Local).AddTicks(7951) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "createDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "modifyDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Categories");
        }
    }
}
