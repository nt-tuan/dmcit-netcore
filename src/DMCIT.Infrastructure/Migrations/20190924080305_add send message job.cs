using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addsendmessagejob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SendingMessageJobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    JobId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    DistributorCode = table.Column<string>(nullable: true),
                    BatchId = table.Column<int>(nullable: false),
                    MessageBatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendingMessageJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SendingMessageJobs_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SendingMessageJobs_MessageBatches_MessageBatchId",
                        column: x => x.MessageBatchId,
                        principalTable: "MessageBatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SendingMessageJobs_AspNetUsers_RemovedById",
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

            migrationBuilder.CreateIndex(
                name: "IX_SendingMessageJobs_CreatedById",
                table: "SendingMessageJobs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SendingMessageJobs_MessageBatchId",
                table: "SendingMessageJobs",
                column: "MessageBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_SendingMessageJobs_RemovedById",
                table: "SendingMessageJobs",
                column: "RemovedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendingMessageJobs");

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
    }
}
