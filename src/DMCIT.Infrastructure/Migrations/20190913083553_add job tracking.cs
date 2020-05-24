using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addjobtracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diary131s",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MoneyAmount = table.Column<decimal>(nullable: false),
                    DebitAccount = table.Column<string>(nullable: true),
                    DetailDebit1 = table.Column<string>(nullable: true),
                    DetailDebit2 = table.Column<string>(nullable: true),
                    DetailDebit3 = table.Column<string>(nullable: true),
                    CreditAccount = table.Column<string>(nullable: true),
                    DetailCredit1 = table.Column<string>(nullable: true),
                    DetailCredit2 = table.Column<string>(nullable: true),
                    DetailCredit3 = table.Column<string>(nullable: true),
                    ReceiptDate = table.Column<DateTime>(nullable: false),
                    ReceiptNo = table.Column<string>(nullable: true),
                    RemovedDate = table.Column<DateTime>(nullable: true),
                    Locked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diary131s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diary131SynchronizeJobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    JobId = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    DistributorCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diary131SynchronizeJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diary131SynchronizeJobs_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diary131SynchronizeJobs_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 32, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 34, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 34, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 34, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 34, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 13, 15, 35, 53, 34, DateTimeKind.Local), new DateTime(2019, 9, 13, 15, 35, 53, 34, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Diary131SynchronizeJobs_CreatedById",
                table: "Diary131SynchronizeJobs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Diary131SynchronizeJobs_RemovedById",
                table: "Diary131SynchronizeJobs",
                column: "RemovedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diary131s");

            migrationBuilder.DropTable(
                name: "Diary131SynchronizeJobs");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 474, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 496, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 496, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 496, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 496, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 12, 496, DateTimeKind.Local), new DateTime(2019, 9, 10, 9, 14, 12, 496, DateTimeKind.Local) });
        }
    }
}
