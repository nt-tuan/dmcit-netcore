using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addsettingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SentMessageDate",
                table: "CustomerPayments");

            migrationBuilder.AddColumn<int>(
                name: "SentMessageId",
                table: "CustomerPayments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DispatchAccountingPeriodId",
                table: "CustomerLiabilities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountingPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AccountingStartTime = table.Column<DateTime>(nullable: true),
                    AccountingEndTime = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountingPeriods_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountingPeriods_AccountingPeriods_OriginId",
                        column: x => x.OriginId,
                        principalTable: "AccountingPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountingPeriods_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    CultureInfo = table.Column<string>(nullable: true),
                    NumbericMoneyFormat = table.Column<string>(nullable: true),
                    ShortDateTimeFormat = table.Column<string>(nullable: true),
                    LongDateTimeFormat = table.Column<string>(nullable: true),
                    TimeOffset = table.Column<int>(nullable: false),
                    PaymentMessageTemplatePath = table.Column<string>(nullable: true),
                    LiabilityMessageTemplatePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Settings_Settings_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Settings_AspNetUsers_RemovedById",
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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayments_SentMessageId",
                table: "CustomerPayments",
                column: "SentMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLiabilities_DispatchAccountingPeriodId",
                table: "CustomerLiabilities",
                column: "DispatchAccountingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPeriods_CreatedById",
                table: "AccountingPeriods",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPeriods_DateEffective",
                table: "AccountingPeriods",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPeriods_DateEnd",
                table: "AccountingPeriods",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPeriods_OriginId",
                table: "AccountingPeriods",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPeriods_RemovedById",
                table: "AccountingPeriods",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_CreatedById",
                table: "Settings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_DateEffective",
                table: "Settings",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_DateEnd",
                table: "Settings",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_OriginId",
                table: "Settings",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_RemovedById",
                table: "Settings",
                column: "RemovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerLiabilities_AccountingPeriods_DispatchAccountingPeriodId",
                table: "CustomerLiabilities",
                column: "DispatchAccountingPeriodId",
                principalTable: "AccountingPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPayments_SentMessages_SentMessageId",
                table: "CustomerPayments",
                column: "SentMessageId",
                principalTable: "SentMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerLiabilities_AccountingPeriods_DispatchAccountingPeriodId",
                table: "CustomerLiabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPayments_SentMessages_SentMessageId",
                table: "CustomerPayments");

            migrationBuilder.DropTable(
                name: "AccountingPeriods");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPayments_SentMessageId",
                table: "CustomerPayments");

            migrationBuilder.DropIndex(
                name: "IX_CustomerLiabilities_DispatchAccountingPeriodId",
                table: "CustomerLiabilities");

            migrationBuilder.DropColumn(
                name: "SentMessageId",
                table: "CustomerPayments");

            migrationBuilder.DropColumn(
                name: "DispatchAccountingPeriodId",
                table: "CustomerLiabilities");

            migrationBuilder.AddColumn<DateTime>(
                name: "SentMessageDate",
                table: "CustomerPayments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 824, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 826, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 826, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 826, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 826, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 10, 16, 14, 53, 31, 826, DateTimeKind.Local), new DateTime(2019, 10, 16, 14, 53, 31, 826, DateTimeKind.Local) });
        }
    }
}
