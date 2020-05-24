using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addinitdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_Countries_CountryId",
                table: "Distributors");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Countries_CountryId",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "People",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Distributors",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Distributors",
                columns: new[] { "Id", "Address", "Code", "CountryId", "CreatedById", "DateCreated", "DateEffective", "DateEnd", "DateRemoved", "DateReplaced", "DiscriptionNote", "Name", "OriginId", "Phone", "RemovedById" },
                values: new object[,]
                {
                    { 1, null, "DT", null, null, new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), null, null, null, null, "Chi nhánh Đồng Tháp", null, null, null },
                    { 2, null, "CT", null, null, new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), null, null, null, null, "Chi nhánh Cần Thơ", null, null, null },
                    { 3, null, "AG", null, null, new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), null, null, null, null, "Chi nhánh An Giang", null, null, null },
                    { 4, null, "TP", null, null, new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), null, null, null, null, "Chi nhánh Hồ Chí Minh", null, null, null },
                    { 5, null, "MD", null, null, new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), null, null, null, null, "Chi nhánh Miền Đông", null, null, null },
                    { 6, null, "TN", null, null, new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), null, null, null, null, "Chi nhánh Tây Nguyên", null, null, null },
                    { 7, null, "DN", null, null, new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), null, null, null, null, "Chi nhánh Đà Nẵng", null, null, null },
                    { 8, null, "VI", null, null, new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), null, null, null, null, "Chi nhánh Vinh", null, null, null },
                    { 9, null, "TH", null, null, new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), null, null, null, null, "Chi nhánh Thái Nguyên", null, null, null },
                    { 10, null, "HN", null, null, new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), null, null, null, null, "Chi nhánh Hà Nội", null, null, null },
                    { 11, null, "HD", null, null, new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), null, null, null, null, "Chi nhánh Hải Dương", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "MessageServiceProviders",
                columns: new[] { "Id", "AddressLabel", "AddressRegex", "CreatedById", "DateCreated", "DateEffective", "DateEnd", "DateRemoved", "DateReplaced", "DiscriptionNote", "Name", "OriginId", "RemovedById" },
                values: new object[,]
                {
                    { 1, null, "(09|01[2|6|8|9])+([0-9]{8})\\b", null, new DateTime(2019, 9, 3, 9, 14, 34, 213, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 213, DateTimeKind.Local), null, null, null, null, "Viettel", null, null },
                    { 2, null, "(09|01[2|6|8|9])+([0-9]{8})\\b", null, new DateTime(2019, 9, 3, 9, 14, 34, 213, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 213, DateTimeKind.Local), null, null, null, null, "Netco", null, null },
                    { 3, null, "", null, new DateTime(2019, 9, 3, 9, 14, 34, 213, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 213, DateTimeKind.Local), null, null, null, null, "Zalo", null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_Countries_CountryId",
                table: "Distributors",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Countries_CountryId",
                table: "People",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_Countries_CountryId",
                table: "Distributors");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Countries_CountryId",
                table: "People");

            migrationBuilder.DeleteData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "People",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Distributors",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_Countries_CountryId",
                table: "Distributors",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Countries_CountryId",
                table: "People",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
