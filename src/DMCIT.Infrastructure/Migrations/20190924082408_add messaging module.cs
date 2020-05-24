using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addmessagingmodule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Module",
                table: "MessageServiceProviders",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 378, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective", "Module" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 380, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 380, DateTimeKind.Local), "DMCIT.Infrastructure.Providers.Test" });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective", "Module" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 380, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 380, DateTimeKind.Local), "DMCIT.Infrastructure.Providers.Test" });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective", "Module" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 24, 7, 380, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 24, 7, 380, DateTimeKind.Local), "DMCIT.Infrastructure.Providers.Test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Module",
                table: "MessageServiceProviders");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 320, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 322, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 322, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 322, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 322, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 24, 15, 3, 5, 322, DateTimeKind.Local), new DateTime(2019, 9, 24, 15, 3, 5, 322, DateTimeKind.Local) });
        }
    }
}
