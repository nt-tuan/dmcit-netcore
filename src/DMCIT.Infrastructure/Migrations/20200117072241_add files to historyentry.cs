using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addfilestohistoryentry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Files",
                table: "HistoryWorkflowEntries",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 678, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 678, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 678, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 678, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 678, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 678, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Files",
                table: "HistoryWorkflowEntries");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 595, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 655, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 655, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 655, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 655, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 655, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 655, DateTimeKind.Local) });
        }
    }
}
