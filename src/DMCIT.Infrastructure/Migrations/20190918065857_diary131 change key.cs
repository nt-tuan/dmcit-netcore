using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class diary131changekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Diary131s",
                table: "Diary131s");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Diary131s",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diary131s",
                table: "Diary131s",
                columns: new[] { "Id", "Source" });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 31, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 34, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 34, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 34, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 34, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 13, 58, 57, 34, DateTimeKind.Local), new DateTime(2019, 9, 18, 13, 58, 57, 34, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Diary131s",
                table: "Diary131s");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Diary131s");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diary131s",
                table: "Diary131s",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 368, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 371, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 371, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 371, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 371, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 18, 11, 5, 17, 371, DateTimeKind.Local), new DateTime(2019, 9, 18, 11, 5, 17, 371, DateTimeKind.Local) });
        }
    }
}
