using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class TightSolutiontoHangfire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobId",
                table: "BackgroundProcesses",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 905, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 905, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 905, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 905, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 905, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 905, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobId",
                table: "BackgroundProcesses");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 96, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 96, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 96, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 96, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 96, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 96, DateTimeKind.Local) });
        }
    }
}
