using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addcurrentcustomerar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Liability",
                table: "CustomerPayments",
                newName: "ARAmount");

            migrationBuilder.CreateTable(
                name: "CustomerARNows",
                columns: table => new
                {
                    CustomerCode = table.Column<string>(nullable: false),
                    DistributorCode = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerARNows", x => new { x.CustomerCode, x.DistributorCode });
                    table.ForeignKey(
                        name: "FK_CustomerARNows_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 113, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 113, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 113, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 113, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 113, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 113, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerARNows_CustomerId",
                table: "CustomerARNows",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerARNows");

            migrationBuilder.RenameColumn(
                name: "ARAmount",
                table: "CustomerPayments",
                newName: "Liability");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 540, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 544, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 544, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 544, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 544, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 23, 29, 544, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 23, 29, 544, DateTimeKind.Local) });
        }
    }
}
