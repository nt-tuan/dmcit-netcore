using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class changesystemsettingstructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CultureInfo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TimeOffset",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "ShortDateTimeFormat",
                table: "Settings",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "PaymentMessageTemplatePath",
                table: "Settings",
                newName: "Summary");

            migrationBuilder.RenameColumn(
                name: "NumbericMoneyFormat",
                table: "Settings",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LongDateTimeFormat",
                table: "Settings",
                newName: "Module");

            migrationBuilder.RenameColumn(
                name: "LiabilityMessageTemplatePath",
                table: "Settings",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 610, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 614, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 614, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 614, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 614, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 29, 16, 5, 6, 614, DateTimeKind.Local), new DateTime(2019, 10, 29, 16, 5, 6, 614, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Settings",
                newName: "ShortDateTimeFormat");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Settings",
                newName: "PaymentMessageTemplatePath");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Settings",
                newName: "NumbericMoneyFormat");

            migrationBuilder.RenameColumn(
                name: "Module",
                table: "Settings",
                newName: "LongDateTimeFormat");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Settings",
                newName: "LiabilityMessageTemplatePath");

            migrationBuilder.AddColumn<string>(
                name: "CultureInfo",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeOffset",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 384, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 390, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 390, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 390, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 390, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 26, 18, 32, 35, 390, DateTimeKind.Local), new DateTime(2019, 10, 26, 18, 32, 35, 390, DateTimeKind.Local) });
        }
    }
}
