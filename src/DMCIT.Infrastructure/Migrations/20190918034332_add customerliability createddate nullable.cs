using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addcustomerliabilitycreateddatenullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "GetCustomerPayments",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CustomerLiabilities",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 43, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 45, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 45, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 45, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 45, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 10, 43, 32, 45, DateTimeKind.Local), new DateTime(2019, 9, 18, 10, 43, 32, 45, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "GetCustomerPayments",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CustomerLiabilities",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

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
    }
}
