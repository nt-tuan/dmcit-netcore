using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionTime",
                table: "MessageBatches",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishTime",
                table: "MessageBatches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Diary131s",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerCode",
                table: "Diary131s",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Diary131s",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "Diary131s",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistributorCode",
                table: "Diary131s",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "Diary131s",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "sentMessage",
                table: "Diary131s",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.CreateIndex(
                name: "IX_Diary131s_CreatedById",
                table: "Diary131s",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Diary131s_RemovedById",
                table: "Diary131s",
                column: "RemovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Diary131s_AspNetUsers_CreatedById",
                table: "Diary131s",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diary131s_AspNetUsers_RemovedById",
                table: "Diary131s",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diary131s_AspNetUsers_CreatedById",
                table: "Diary131s");

            migrationBuilder.DropForeignKey(
                name: "FK_Diary131s_AspNetUsers_RemovedById",
                table: "Diary131s");

            migrationBuilder.DropIndex(
                name: "IX_Diary131s_CreatedById",
                table: "Diary131s");

            migrationBuilder.DropIndex(
                name: "IX_Diary131s_RemovedById",
                table: "Diary131s");

            migrationBuilder.DropColumn(
                name: "FinishTime",
                table: "MessageBatches");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Diary131s");

            migrationBuilder.DropColumn(
                name: "CustomerCode",
                table: "Diary131s");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Diary131s");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "Diary131s");

            migrationBuilder.DropColumn(
                name: "DistributorCode",
                table: "Diary131s");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "Diary131s");

            migrationBuilder.DropColumn(
                name: "sentMessage",
                table: "Diary131s");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionTime",
                table: "MessageBatches",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 34, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 34, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 34, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 34, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 34, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 34, DateTimeKind.Local) });
        }
    }
}
