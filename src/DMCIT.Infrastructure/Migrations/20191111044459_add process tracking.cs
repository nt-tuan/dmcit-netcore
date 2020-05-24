using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addprocesstracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SendingMessageJobs_AspNetUsers_CreatedById",
                table: "SendingMessageJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingMessageJobs_MessageBatches_MessageBatchId",
                table: "SendingMessageJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_SendingMessageJobs_AspNetUsers_RemovedById",
                table: "SendingMessageJobs");

            migrationBuilder.DropTable(
                name: "Diary131SynchronizeJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SendingMessageJobs",
                table: "SendingMessageJobs");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "SendingMessageJobs");

            migrationBuilder.RenameTable(
                name: "SendingMessageJobs",
                newName: "BackgroundProcesses");

            migrationBuilder.RenameIndex(
                name: "IX_SendingMessageJobs_RemovedById",
                table: "BackgroundProcesses",
                newName: "IX_BackgroundProcesses_RemovedById");

            migrationBuilder.RenameIndex(
                name: "IX_SendingMessageJobs_MessageBatchId",
                table: "BackgroundProcesses",
                newName: "IX_BackgroundProcesses_MessageBatchId");

            migrationBuilder.RenameIndex(
                name: "IX_SendingMessageJobs_CreatedById",
                table: "BackgroundProcesses",
                newName: "IX_BackgroundProcesses_CreatedById");

            migrationBuilder.AlterColumn<int>(
                name: "BatchId",
                table: "BackgroundProcesses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BackgroundProcesses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BackgroundProcesses",
                table: "BackgroundProcesses",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 94, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 96, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 96, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 96, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 96, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 11, 11, 44, 59, 96, DateTimeKind.Local), new DateTime(2019, 11, 11, 11, 44, 59, 96, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_BackgroundProcesses_MessageBatches_MessageBatchId",
                table: "BackgroundProcesses",
                column: "MessageBatchId",
                principalTable: "MessageBatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BackgroundProcesses_AspNetUsers_CreatedById",
                table: "BackgroundProcesses",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BackgroundProcesses_AspNetUsers_RemovedById",
                table: "BackgroundProcesses",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackgroundProcesses_MessageBatches_MessageBatchId",
                table: "BackgroundProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_BackgroundProcesses_AspNetUsers_CreatedById",
                table: "BackgroundProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_BackgroundProcesses_AspNetUsers_RemovedById",
                table: "BackgroundProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BackgroundProcesses",
                table: "BackgroundProcesses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BackgroundProcesses");

            migrationBuilder.RenameTable(
                name: "BackgroundProcesses",
                newName: "SendingMessageJobs");

            migrationBuilder.RenameIndex(
                name: "IX_BackgroundProcesses_RemovedById",
                table: "SendingMessageJobs",
                newName: "IX_SendingMessageJobs_RemovedById");

            migrationBuilder.RenameIndex(
                name: "IX_BackgroundProcesses_CreatedById",
                table: "SendingMessageJobs",
                newName: "IX_SendingMessageJobs_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_BackgroundProcesses_MessageBatchId",
                table: "SendingMessageJobs",
                newName: "IX_SendingMessageJobs_MessageBatchId");

            migrationBuilder.AlterColumn<int>(
                name: "BatchId",
                table: "SendingMessageJobs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobId",
                table: "SendingMessageJobs",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SendingMessageJobs",
                table: "SendingMessageJobs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Diary131SynchronizeJobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    DistributorCode = table.Column<string>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    JobId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Diary131SynchronizeJobs_CreatedById",
                table: "Diary131SynchronizeJobs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Diary131SynchronizeJobs_RemovedById",
                table: "Diary131SynchronizeJobs",
                column: "RemovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_SendingMessageJobs_AspNetUsers_CreatedById",
                table: "SendingMessageJobs",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingMessageJobs_MessageBatches_MessageBatchId",
                table: "SendingMessageJobs",
                column: "MessageBatchId",
                principalTable: "MessageBatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SendingMessageJobs_AspNetUsers_RemovedById",
                table: "SendingMessageJobs",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
