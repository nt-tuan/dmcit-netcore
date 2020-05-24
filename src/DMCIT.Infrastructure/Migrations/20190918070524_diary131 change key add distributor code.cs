using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class diary131changekeyadddistributorcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Diary131s",
                table: "Diary131s");

            migrationBuilder.AlterColumn<string>(
                name: "DistributorCode",
                table: "Diary131s",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diary131s",
                table: "Diary131s",
                columns: new[] { "Id", "Source", "DistributorCode" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Diary131s",
                table: "Diary131s");

            migrationBuilder.AlterColumn<string>(
                name: "DistributorCode",
                table: "Diary131s",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diary131s",
                table: "Diary131s",
                columns: new[] { "Id", "Source" });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 218, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 220, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 220, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 220, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 220, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 14, 0, 54, 220, DateTimeKind.Local), new DateTime(2019, 9, 18, 14, 0, 54, 220, DateTimeKind.Local) });
        }
    }
}
