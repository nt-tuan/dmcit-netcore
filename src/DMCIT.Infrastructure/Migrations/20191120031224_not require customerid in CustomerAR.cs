using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class notrequirecustomeridinCustomerAR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerLiabilities");

            migrationBuilder.CreateTable(
                name: "CustomerARs",
                columns: table => new
                {
                    CustomerCode = table.Column<string>(nullable: true),
                    DistributorCode = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    DispatchAccountingPeriodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerARs", x => new { x.CustomerId, x.DistributorCode });
                    table.ForeignKey(
                        name: "FK_CustomerARs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerARs_AccountingPeriods_DispatchAccountingPeriodId",
                        column: x => x.DispatchAccountingPeriodId,
                        principalTable: "AccountingPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 622, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 625, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 625, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 625, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 625, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 20, 10, 12, 23, 625, DateTimeKind.Local), new DateTime(2019, 11, 20, 10, 12, 23, 625, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerARs_DispatchAccountingPeriodId",
                table: "CustomerARs",
                column: "DispatchAccountingPeriodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerARs");

            migrationBuilder.CreateTable(
                name: "CustomerLiabilities",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false),
                    DistributorCode = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CustomerCode = table.Column<string>(nullable: true),
                    DispatchAccountingPeriodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLiabilities", x => new { x.CustomerId, x.DistributorCode });
                    table.ForeignKey(
                        name: "FK_CustomerLiabilities_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerLiabilities_AccountingPeriods_DispatchAccountingPeriodId",
                        column: x => x.DispatchAccountingPeriodId,
                        principalTable: "AccountingPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLiabilities_DispatchAccountingPeriodId",
                table: "CustomerLiabilities",
                column: "DispatchAccountingPeriodId");
        }
    }
}
