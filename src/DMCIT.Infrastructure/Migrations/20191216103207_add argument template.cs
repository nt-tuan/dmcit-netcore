using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addargumenttemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Templates_Name_ModelName",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_TemplateParsers_Name",
                table: "TemplateParsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Templates",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArgumentModelName",
                table: "Templates",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TemplateParsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassName",
                table: "TemplateParsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 612, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 612, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 612, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 612, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 612, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 612, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Templates_ModelName",
                table: "Templates",
                column: "ModelName",
                unique: true,
                filter: "[ModelName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateParsers_ClassName",
                table: "TemplateParsers",
                column: "ClassName",
                unique: true,
                filter: "[ClassName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Templates_ModelName",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_TemplateParsers_ClassName",
                table: "TemplateParsers");

            migrationBuilder.DropColumn(
                name: "ArgumentModelName",
                table: "Templates");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Templates",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TemplateParsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassName",
                table: "TemplateParsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 349, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 349, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 349, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 349, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 349, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 349, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Templates_Name_ModelName",
                table: "Templates",
                columns: new[] { "Name", "ModelName" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [ModelName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateParsers_Name",
                table: "TemplateParsers",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }
    }
}
