using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class regex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 656, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddressRegex", "DateCreated", "DateEffective" },
                values: new object[] { "(84)+([0-9]{9})\\b", new DateTime(2019, 10, 1, 4, 3, 10, 659, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 659, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 659, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 659, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 1, 4, 3, 10, 659, DateTimeKind.Local), new DateTime(2019, 10, 1, 4, 3, 10, 659, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 744, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddressRegex", "DateCreated", "DateEffective" },
                values: new object[] { "(09|01[2|6|8|9])+([0-9]{8})\\b", new DateTime(2019, 9, 30, 16, 59, 19, 746, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 746, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 30, 16, 59, 19, 746, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 746, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 30, 16, 59, 19, 746, DateTimeKind.Local), new DateTime(2019, 9, 30, 16, 59, 19, 746, DateTimeKind.Local) });
        }
    }
}
