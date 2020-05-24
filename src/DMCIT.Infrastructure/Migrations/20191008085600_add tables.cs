using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CustomerPayments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistributorId",
                table: "CustomerPayments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 91, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 93, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 93, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 93, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 93, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 8, 15, 56, 0, 93, DateTimeKind.Local), new DateTime(2019, 10, 8, 15, 56, 0, 93, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayments_CustomerId",
                table: "CustomerPayments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayments_DistributorId",
                table: "CustomerPayments",
                column: "DistributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPayments_Customers_CustomerId",
                table: "CustomerPayments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPayments_Distributors_DistributorId",
                table: "CustomerPayments",
                column: "DistributorId",
                principalTable: "Distributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPayments_Customers_CustomerId",
                table: "CustomerPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPayments_Distributors_DistributorId",
                table: "CustomerPayments");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPayments_CustomerId",
                table: "CustomerPayments");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPayments_DistributorId",
                table: "CustomerPayments");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerPayments");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "CustomerPayments");

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
    }
}
