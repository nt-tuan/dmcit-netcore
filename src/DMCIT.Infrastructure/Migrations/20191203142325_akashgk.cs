using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class akashgk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 251, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 256, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 256, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 256, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 256, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 21, 23, 23, 256, DateTimeKind.Local), new DateTime(2019, 12, 3, 21, 23, 23, 256, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 705, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 705, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 705, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 705, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 3, 10, 32, 5, 705, DateTimeKind.Local), new DateTime(2019, 12, 3, 10, 32, 5, 705, DateTimeKind.Local) });
        }
    }
}
