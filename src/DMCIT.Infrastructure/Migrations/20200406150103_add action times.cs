using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addactiontimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedTime",
                table: "SupportRequests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmTime",
                table: "SupportRequests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishTime",
                table: "SupportRequests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HandleTime",
                table: "SupportRequests",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 139, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 139, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 139, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 139, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 139, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 139, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedTime",
                table: "SupportRequests");

            migrationBuilder.DropColumn(
                name: "ConfirmTime",
                table: "SupportRequests");

            migrationBuilder.DropColumn(
                name: "FinishTime",
                table: "SupportRequests");

            migrationBuilder.DropColumn(
                name: "HandleTime",
                table: "SupportRequests");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 750, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 750, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 750, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 750, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 750, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 750, DateTimeKind.Local) });
        }
    }
}
