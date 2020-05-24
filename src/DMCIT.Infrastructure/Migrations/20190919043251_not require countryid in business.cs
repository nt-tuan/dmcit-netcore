using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class notrequirecountryidinbusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Countries_CountryId",
                table: "Businesses");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Businesses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 544, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 544, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 544, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 544, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 544, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 544, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Countries_CountryId",
                table: "Businesses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Countries_CountryId",
                table: "Businesses");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Businesses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 363, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 366, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 366, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 366, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 366, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 5, 24, 366, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 5, 24, 366, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Countries_CountryId",
                table: "Businesses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
