using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Distributors_Code",
                table: "Distributors");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Code",
                table: "Employees",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_Code",
                table: "Distributors",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Diary131s_ReceiptDate",
                table: "Diary131s",
                column: "ReceiptDate");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Code",
                table: "Departments",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Code",
                table: "Customers",
                column: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Code",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Distributors_Code",
                table: "Distributors");

            migrationBuilder.DropIndex(
                name: "IX_Diary131s_ReceiptDate",
                table: "Diary131s");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Code",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Code",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 524, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 524, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 524, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 524, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 20, 38, 524, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 20, 38, 524, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_Code",
                table: "Distributors",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }
    }
}
