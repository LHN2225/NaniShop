using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RookieShop.Backend.Migrations
{
    public partial class AddDateTimeToRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "localDate",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: "RSCA0001",
                column: "name",
                value: "Men");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: "RSCA0002",
                column: "name",
                value: "Women");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: "RSCA0003",
                column: "name",
                value: "Baby");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPBB0001",
                column: "imageUri",
                value: "ProductImage/bb1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPBB0002",
                column: "imageUri",
                value: "ProductImage/bb2.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPBB0003",
                column: "imageUri",
                value: "ProductImage/bb3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPM0001",
                column: "imageUri",
                value: "ProductImage/m1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPM0002",
                column: "imageUri",
                value: "ProductImage/m2.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPM0003",
                column: "imageUri",
                value: "ProductImage/m3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPWM0001",
                column: "imageUri",
                value: "ProductImage/wm1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPWM0002",
                column: "imageUri",
                value: "ProductImage/wm2.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPWM0003",
                column: "imageUri",
                value: "ProductImage/wm3.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "localDate",
                table: "Ratings");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: "RSCA0001",
                column: "name",
                value: "men");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: "RSCA0002",
                column: "name",
                value: "women");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: "RSCA0003",
                column: "name",
                value: "baby");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPBB0001",
                column: "imageUri",
                value: "ShopImage/bb1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPBB0002",
                column: "imageUri",
                value: "ShopImage/bb2.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPBB0003",
                column: "imageUri",
                value: "ShopImage/bb3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPM0001",
                column: "imageUri",
                value: "ShopImage/m1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPM0002",
                column: "imageUri",
                value: "ShopImage/m2.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPM0003",
                column: "imageUri",
                value: "ShopImage/m3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPWM0001",
                column: "imageUri",
                value: "ShopImage/wm1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPWM0002",
                column: "imageUri",
                value: "ShopImage/wm2.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id",
                keyValue: "RSCAPWM0003",
                column: "imageUri",
                value: "ShopImage/wm3.jpg");
        }
    }
}
