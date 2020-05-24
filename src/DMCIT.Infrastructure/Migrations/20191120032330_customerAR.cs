using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class customerAR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerARs_Customers_CustomerId",
                table: "CustomerARs");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerARs_AccountingPeriods_DispatchAccountingPeriodId",
                table: "CustomerARs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerARs",
                table: "CustomerARs");

            migrationBuilder.AlterColumn<int>(
                name: "DispatchAccountingPeriodId",
                table: "CustomerARs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerCode",
                table: "CustomerARs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerARs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerARs",
                table: "CustomerARs",
                columns: new[] { "CustomerCode", "DistributorCode", "DispatchAccountingPeriodId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerARs_CustomerId",
                table: "CustomerARs",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerARs_Customers_CustomerId",
                table: "CustomerARs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerARs_AccountingPeriods_DispatchAccountingPeriodId",
                table: "CustomerARs",
                column: "DispatchAccountingPeriodId",
                principalTable: "AccountingPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerARs_Customers_CustomerId",
                table: "CustomerARs");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerARs_AccountingPeriods_DispatchAccountingPeriodId",
                table: "CustomerARs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerARs",
                table: "CustomerARs");

            migrationBuilder.DropIndex(
                name: "IX_CustomerARs_CustomerId",
                table: "CustomerARs");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerARs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DispatchAccountingPeriodId",
                table: "CustomerARs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CustomerCode",
                table: "CustomerARs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerARs",
                table: "CustomerARs",
                columns: new[] { "CustomerId", "DistributorCode" });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 625, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 625, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 625, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 625, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 625, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 625, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerARs_Customers_CustomerId",
                table: "CustomerARs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerARs_AccountingPeriods_DispatchAccountingPeriodId",
                table: "CustomerARs",
                column: "DispatchAccountingPeriodId",
                principalTable: "AccountingPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
