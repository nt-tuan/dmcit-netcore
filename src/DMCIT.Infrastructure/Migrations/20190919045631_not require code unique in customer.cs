using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class notrequirecodeuniqueincustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Code",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 521, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 523, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 523, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 523, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 523, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 56, 30, 523, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 56, 30, 523, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 541, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 544, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 544, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 544, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 544, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 11, 32, 50, 544, DateTimeKind.Local), new DateTime(2019, 9, 19, 11, 32, 50, 544, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Code",
                table: "Customers",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }
    }
}
