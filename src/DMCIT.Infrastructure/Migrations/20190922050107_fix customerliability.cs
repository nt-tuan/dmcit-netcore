using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class fixcustomerliability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerLiabilities",
                table: "CustomerLiabilities");

            migrationBuilder.DropColumn(
                name: "CustomerCode",
                table: "CustomerLiabilities");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CustomerLiabilities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "CustomerLiabilities",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerLiabilities",
                table: "CustomerLiabilities",
                columns: new[] { "CustomerId", "DistributorCode" });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 691, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 691, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 691, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 691, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 691, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 691, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerLiabilities_Customers_CustomerId",
                table: "CustomerLiabilities",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerLiabilities_Customers_CustomerId",
                table: "CustomerLiabilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerLiabilities",
                table: "CustomerLiabilities");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerLiabilities");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "CustomerLiabilities");

            migrationBuilder.AddColumn<string>(
                name: "CustomerCode",
                table: "CustomerLiabilities",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerLiabilities",
                table: "CustomerLiabilities",
                columns: new[] { "CustomerCode", "DistributorCode" });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 877, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 880, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 880, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 880, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 880, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 20, 9, 31, 51, 880, DateTimeKind.Local), new DateTime(2019, 9, 20, 9, 31, 51, 880, DateTimeKind.Local) });
        }
    }
}
