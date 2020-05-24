using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addcustomerliabilityandcustomerpaymentreport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerLiabilities",
                columns: table => new
                {
                    CustomerCode = table.Column<string>(nullable: false),
                    DistributorCode = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLiabilities", x => new { x.CustomerCode, x.DistributorCode });
                });

            migrationBuilder.CreateTable(
                name: "GetCustomerPayments",
                columns: table => new
                {
                    CustomerCode = table.Column<string>(nullable: false),
                    DistributorCode = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    ReceiptDate = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetCustomerPayments", x => new { x.CustomerCode, x.DistributorCode, x.ReceiptDate });
                });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 123, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 126, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 126, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 126, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 126, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 9, 32, 3, 126, DateTimeKind.Local), new DateTime(2019, 9, 18, 9, 32, 3, 126, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerLiabilities");

            migrationBuilder.DropTable(
                name: "GetCustomerPayments");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 85, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 87, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 87, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 87, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 87, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 16, 15, 42, 10, 87, DateTimeKind.Local), new DateTime(2019, 9, 16, 15, 42, 10, 87, DateTimeKind.Local) });
        }
    }
}
