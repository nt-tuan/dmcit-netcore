using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class ChangeServerInfoDatastructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DistributedServers",
                columns: table => new
                {
                    DistributorCode = table.Column<string>(nullable: false),
                    Servername = table.Column<string>(nullable: true),
                    ConnectionString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributedServers", x => x.DistributorCode);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistributedServers");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 614, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 614, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 614, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 614, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 614, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 614, DateTimeKind.Local) });
        }
    }
}
