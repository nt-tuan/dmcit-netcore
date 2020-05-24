using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class CustomerPaymentnotrequireLiability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Liability",
                table: "CustomerPayments",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 856, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 858, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 858, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 858, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 858, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 56, 7, 858, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 56, 7, 858, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Liability",
                table: "CustomerPayments",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

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
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 10, 26, 3, 949, DateTimeKind.Local), new DateTime(2019, 10, 8, 10, 26, 3, 949, DateTimeKind.Local) });

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
    }
}
