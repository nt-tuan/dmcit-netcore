using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addprocessname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Diary131SynchronizeJobs",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 955, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 958, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 958, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 958, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 958, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 19, 4, 1, 958, DateTimeKind.Local), new DateTime(2019, 9, 22, 19, 4, 1, 958, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Diary131SynchronizeJobs");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 684, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 691, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 691, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 691, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 691, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 22, 12, 1, 5, 691, DateTimeKind.Local), new DateTime(2019, 9, 22, 12, 1, 5, 691, DateTimeKind.Local) });
        }
    }
}
