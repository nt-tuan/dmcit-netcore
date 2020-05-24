using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class changedatabasename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GetCustomerPayments",
                table: "GetCustomerPayments");

            migrationBuilder.RenameTable(
                name: "GetCustomerPayments",
                newName: "CustomerPayments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerPayments",
                table: "CustomerPayments",
                columns: new[] { "CustomerCode", "DistributorCode", "ReceiptDate" });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 369, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 371, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 371, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 371, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 371, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 28, 37, 371, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 28, 37, 371, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerPayments",
                table: "CustomerPayments");

            migrationBuilder.RenameTable(
                name: "CustomerPayments",
                newName: "GetCustomerPayments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetCustomerPayments",
                table: "GetCustomerPayments",
                columns: new[] { "CustomerCode", "DistributorCode", "ReceiptDate" });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 667, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 671, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 671, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 671, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 671, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 0, 41, 15, 671, DateTimeKind.Local), new DateTime(2019, 9, 20, 0, 41, 15, 671, DateTimeKind.Local) });
        }
    }
}
