using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class changesendpaymentprocess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSentMessage",
                table: "CustomerPayments");

            migrationBuilder.AddColumn<decimal>(
                name: "Liability",
                table: "CustomerPayments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "SentMessageDate",
                table: "CustomerPayments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 947, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective", "Module" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 949, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 949, DateTimeKind.Local), "DMCIT.Infrastructure.Providers.Test" });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 949, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 949, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 949, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 949, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Liability",
                table: "CustomerPayments");

            migrationBuilder.DropColumn(
                name: "SentMessageDate",
                table: "CustomerPayments");

            migrationBuilder.AddColumn<bool>(
                name: "IsSentMessage",
                table: "CustomerPayments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective", "Module" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 659, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 659, DateTimeKind.Local), "DMCIT.Infrastructure.Providers.ViettelSMSProvider" });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 659, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 659, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 659, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 659, DateTimeKind.Local) });
        }
    }
}
