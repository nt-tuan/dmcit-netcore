using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class customizeroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 826, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 826, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 826, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 826, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 826, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 826, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 93, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 93, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 93, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 93, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 93, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 93, DateTimeKind.Local) });
        }
    }
}
