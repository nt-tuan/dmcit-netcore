using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class adddefinedcolumnindistributeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DistributedServerDefinedTable",
                columns: table => new
                {
                    DistributedServerId = table.Column<string>(nullable: false),
                    TableName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributedServerDefinedTable", x => new { x.DistributedServerId, x.TableName });
                    table.ForeignKey(
                        name: "FK_DistributedServerDefinedTable_DistributedServers_DistributedServerId",
                        column: x => x.DistributedServerId,
                        principalTable: "DistributedServers",
                        principalColumn: "DistributorCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 120, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 124, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 124, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 124, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 124, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 7, 13, 17, 19, 124, DateTimeKind.Local), new DateTime(2019, 11, 7, 13, 17, 19, 124, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistributedServerDefinedTable");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 135, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 138, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 138, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 138, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 138, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 4, 16, 13, 36, 138, DateTimeKind.Local), new DateTime(2019, 11, 4, 16, 13, 36, 138, DateTimeKind.Local) });
        }
    }
}
