using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class changesomecolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "CustomerLiabilities",
                newName: "CustomerCode");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 773, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 776, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 776, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 776, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 776, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 19, 15, 48, 19, 776, DateTimeKind.Local), new DateTime(2019, 11, 19, 15, 48, 19, 776, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerCode",
                table: "CustomerLiabilities",
                newName: "Code");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 903, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 905, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 905, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 905, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 905, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 15, 24, 905, DateTimeKind.Local), new DateTime(2019, 11, 13, 16, 15, 24, 905, DateTimeKind.Local) });
        }
    }
}
