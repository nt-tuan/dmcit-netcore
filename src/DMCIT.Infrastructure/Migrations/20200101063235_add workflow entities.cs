using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addworkflowentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefinedWorkflows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    Xml = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefinedWorkflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefinedWorkflows_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefinedWorkflows_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    ModelName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatusCounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    PendingCount = table.Column<int>(nullable: false),
                    RunningCount = table.Column<int>(nullable: false),
                    DoneCount = table.Column<int>(nullable: false),
                    FailedCount = table.Column<int>(nullable: false),
                    WarningCount = table.Column<int>(nullable: false),
                    DisabledCount = table.Column<int>(nullable: false),
                    StoppedCount = table.Column<int>(nullable: false),
                    DisapprovedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusCounts_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatusCounts_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoryWorkflowEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    DefinedWorkflowId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LaunchType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    Logs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryWorkflowEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryWorkflowEntries_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoryWorkflowEntries_DefinedWorkflows_DefinedWorkflowId",
                        column: x => x.DefinedWorkflowId,
                        principalTable: "DefinedWorkflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryWorkflowEntries_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserWorkflows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true),
                    DefinedWorkflowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWorkflows_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserWorkflows_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserWorkflows_DefinedWorkflows_DefinedWorkflowId",
                        column: x => x.DefinedWorkflowId,
                        principalTable: "DefinedWorkflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWorkflows_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    DefinedWorkflowId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LaunchType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    Logs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowEntries_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowEntries_DefinedWorkflows_DefinedWorkflowId",
                        column: x => x.DefinedWorkflowId,
                        principalTable: "DefinedWorkflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkflowEntries_AspNetUsers_RemovedById",
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

            migrationBuilder.CreateIndex(
                name: "IX_DefinedWorkflows_CreatedById",
                table: "DefinedWorkflows",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DefinedWorkflows_RemovedById",
                table: "DefinedWorkflows",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatedById",
                table: "Events",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Events_RemovedById",
                table: "Events",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryWorkflowEntries_CreatedById",
                table: "HistoryWorkflowEntries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryWorkflowEntries_DefinedWorkflowId",
                table: "HistoryWorkflowEntries",
                column: "DefinedWorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryWorkflowEntries_RemovedById",
                table: "HistoryWorkflowEntries",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCounts_CreatedById",
                table: "StatusCounts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCounts_RemovedById",
                table: "StatusCounts",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkflows_AppUserId",
                table: "UserWorkflows",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkflows_CreatedById",
                table: "UserWorkflows",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkflows_DefinedWorkflowId",
                table: "UserWorkflows",
                column: "DefinedWorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkflows_RemovedById",
                table: "UserWorkflows",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowEntries_CreatedById",
                table: "WorkflowEntries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowEntries_DefinedWorkflowId",
                table: "WorkflowEntries",
                column: "DefinedWorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowEntries_RemovedById",
                table: "WorkflowEntries",
                column: "RemovedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "HistoryWorkflowEntries");

            migrationBuilder.DropTable(
                name: "StatusCounts");

            migrationBuilder.DropTable(
                name: "UserWorkflows");

            migrationBuilder.DropTable(
                name: "WorkflowEntries");

            migrationBuilder.DropTable(
                name: "DefinedWorkflows");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 596, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 612, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 612, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 612, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 612, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 16, 17, 32, 6, 612, DateTimeKind.Local), new DateTime(2019, 12, 16, 17, 32, 6, 612, DateTimeKind.Local) });
        }
    }
}
