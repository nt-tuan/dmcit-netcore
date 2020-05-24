using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addcodeattributetomessageprovider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MessageServiceProviders",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 381, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 383, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 383, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 383, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 383, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 19, 13, 14, 48, 383, DateTimeKind.Local), new DateTime(2019, 9, 19, 13, 14, 48, 383, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "MessageServiceProviders");

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
    }
}
