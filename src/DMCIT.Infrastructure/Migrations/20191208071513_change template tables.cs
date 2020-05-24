using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class changetemplatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "TemplateTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parser",
                table: "Templates",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 502, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 502, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 502, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 502, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 502, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 502, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "TemplateTypes");

            migrationBuilder.DropColumn(
                name: "Parser",
                table: "Templates");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 194, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 197, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 197, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 197, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 197, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 6, 14, 2, 9, 197, DateTimeKind.Local), new DateTime(2019, 12, 6, 14, 2, 9, 197, DateTimeKind.Local) });
        }
    }
}
