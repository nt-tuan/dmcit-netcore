using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class updateproviderinitvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 522, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddressLabel", "Code", "DateCreated", "DateEffective", "Name" },
                values: new object[] { "Viettel SMS Brandname", "viettel", new DateTime(2019, 9, 19, 13, 20, 38, 524, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 524, DateTimeKind.Local), "Dịch vụ nhắn tin thương hiệu của Viettel" });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddressLabel", "Code", "DateCreated", "DateEffective", "Name" },
                values: new object[] { "Netco SMS", "netco", new DateTime(2019, 9, 19, 13, 20, 38, 524, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 524, DateTimeKind.Local), "Dịch vụ nhắn tin giá rẻ Netco" });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddressLabel", "AddressRegex", "Code", "DateCreated", "DateEffective", "Name" },
                values: new object[] { "Zalo", "(.*?)", "zalo", new DateTime(2019, 9, 19, 13, 20, 38, 524, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 524, DateTimeKind.Local), "Dịch vụ nhắn tin qua Zalo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddressLabel", "Code", "DateCreated", "DateEffective", "Name" },
                values: new object[] { null, null, new DateTime(2019, 9, 19, 13, 14, 48, 383, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 383, DateTimeKind.Local), "Viettel" });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddressLabel", "Code", "DateCreated", "DateEffective", "Name" },
                values: new object[] { null, null, new DateTime(2019, 9, 19, 13, 14, 48, 383, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 383, DateTimeKind.Local), "Netco" });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddressLabel", "AddressRegex", "Code", "DateCreated", "DateEffective", "Name" },
                values: new object[] { null, "", null, new DateTime(2019, 9, 19, 13, 14, 48, 383, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 383, DateTimeKind.Local), "Zalo" });
        }
    }
}
