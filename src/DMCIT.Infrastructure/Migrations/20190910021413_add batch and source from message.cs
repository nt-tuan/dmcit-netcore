using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addbatchandsourcefrommessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SentMessages_AutoMessageConfigs_AutoMessageConfigId",
                table: "SentMessages");

            migrationBuilder.DropIndex(
                name: "IX_SentMessages_AutoMessageConfigId",
                table: "SentMessages");

            migrationBuilder.DropColumn(
                name: "AutoMessageConfigId",
                table: "SentMessages");

            migrationBuilder.DropColumn(
                name: "SendTime",
                table: "SentMessages");

            migrationBuilder.RenameColumn(
                name: "ReceiveTime",
                table: "SentMessages",
                newName: "SentTime");

            migrationBuilder.AddColumn<int>(
                name: "MessageBatchId",
                table: "SentMessages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ResponseMessage",
                table: "SentMessages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseTime",
                table: "SentMessages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MessageSources",
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageSources_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageSources_MessageSources_OriginId",
                        column: x => x.OriginId,
                        principalTable: "MessageSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageSources_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MessageBatches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    AutoMessageConfigId = table.Column<int>(nullable: true),
                    ActionTime = table.Column<DateTime>(nullable: false),
                    MessageSourceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageBatches_AutoMessageConfigs_AutoMessageConfigId",
                        column: x => x.AutoMessageConfigId,
                        principalTable: "AutoMessageConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageBatches_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageBatches_MessageSources_MessageSourceId",
                        column: x => x.MessageSourceId,
                        principalTable: "MessageSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageBatches_AspNetUsers_RemovedById",
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

            migrationBuilder.CreateIndex(
                name: "IX_SentMessages_MessageBatchId",
                table: "SentMessages",
                column: "MessageBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_SentMessages_ReceiverProviderId",
                table: "SentMessages",
                column: "ReceiverProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageBatches_AutoMessageConfigId",
                table: "MessageBatches",
                column: "AutoMessageConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageBatches_CreatedById",
                table: "MessageBatches",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageBatches_MessageSourceId",
                table: "MessageBatches",
                column: "MessageSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageBatches_RemovedById",
                table: "MessageBatches",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSources_CreatedById",
                table: "MessageSources",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSources_DateEffective",
                table: "MessageSources",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSources_DateEnd",
                table: "MessageSources",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSources_OriginId",
                table: "MessageSources",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSources_RemovedById",
                table: "MessageSources",
                column: "RemovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_SentMessages_MessageBatches_MessageBatchId",
                table: "SentMessages",
                column: "MessageBatchId",
                principalTable: "MessageBatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SentMessages_ReceiverProviders_ReceiverProviderId",
                table: "SentMessages",
                column: "ReceiverProviderId",
                principalTable: "ReceiverProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SentMessages_MessageBatches_MessageBatchId",
                table: "SentMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_SentMessages_ReceiverProviders_ReceiverProviderId",
                table: "SentMessages");

            migrationBuilder.DropTable(
                name: "MessageBatches");

            migrationBuilder.DropTable(
                name: "MessageSources");

            migrationBuilder.DropIndex(
                name: "IX_SentMessages_MessageBatchId",
                table: "SentMessages");

            migrationBuilder.DropIndex(
                name: "IX_SentMessages_ReceiverProviderId",
                table: "SentMessages");

            migrationBuilder.DropColumn(
                name: "MessageBatchId",
                table: "SentMessages");

            migrationBuilder.DropColumn(
                name: "ResponseMessage",
                table: "SentMessages");

            migrationBuilder.DropColumn(
                name: "ResponseTime",
                table: "SentMessages");

            migrationBuilder.RenameColumn(
                name: "SentTime",
                table: "SentMessages",
                newName: "ReceiveTime");

            migrationBuilder.AddColumn<int>(
                name: "AutoMessageConfigId",
                table: "SentMessages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SendTime",
                table: "SentMessages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 211, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 213, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 213, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 213, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 213, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 9, 3, 9, 14, 34, 213, DateTimeKind.Local), new DateTime(2019, 9, 3, 9, 14, 34, 213, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_SentMessages_AutoMessageConfigId",
                table: "SentMessages",
                column: "AutoMessageConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_SentMessages_AutoMessageConfigs_AutoMessageConfigId",
                table: "SentMessages",
                column: "AutoMessageConfigId",
                principalTable: "AutoMessageConfigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
