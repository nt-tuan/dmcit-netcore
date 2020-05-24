using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addselectquerydatafromothersourceissqlclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Query",
                table: "DistributedServerDefinedTable",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Query",
                table: "DistributedServerDefinedTable");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 690, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 690, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 690, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 690, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 690, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 690, DateTimeKind.Local) });
        }
    }
}
