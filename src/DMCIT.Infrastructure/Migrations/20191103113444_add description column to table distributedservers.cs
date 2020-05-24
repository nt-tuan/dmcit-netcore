using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class adddescriptioncolumntotabledistributedservers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DistributedServers",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DistributedServers");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 536, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 602, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 602, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 602, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 602, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 16, 28, 602, DateTimeKind.Local), new DateTime(2019, 11, 1, 16, 16, 28, 602, DateTimeKind.Local) });
        }
    }
}
