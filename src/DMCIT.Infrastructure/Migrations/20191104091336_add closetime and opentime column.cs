using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addclosetimeandopentimecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AccountingPeriods");

            migrationBuilder.AddColumn<DateTime>(
                name: "CloseTime",
                table: "AccountingPeriods",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenTime",
                table: "AccountingPeriods",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 138, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 138, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 138, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 138, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 138, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 138, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseTime",
                table: "AccountingPeriods");

            migrationBuilder.DropColumn(
                name: "OpenTime",
                table: "AccountingPeriods");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AccountingPeriods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 124, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 127, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 127, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 127, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 127, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 3, 18, 34, 43, 127, DateTimeKind.Local), new DateTime(2019, 11, 3, 18, 34, 43, 127, DateTimeKind.Local) });
        }
    }
}
