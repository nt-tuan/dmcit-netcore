using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addparameterstoworkflowentry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Parameters",
                table: "WorkflowEntries",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 618, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 618, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 618, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 618, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 618, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 618, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parameters",
                table: "WorkflowEntries");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 607, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 612, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 612, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 612, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 612, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 1, 13, 32, 34, 612, DateTimeKind.Local), new DateTime(2020, 1, 1, 13, 32, 34, 612, DateTimeKind.Local) });
        }
    }
}
