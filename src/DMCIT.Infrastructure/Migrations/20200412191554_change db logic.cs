using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class changedblogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategories_Employees_LastModifiedById",
                table: "PostCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCommentLevel2s_PostComments_CommentPostId",
                table: "PostCommentLevel2s");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportAssistants_AspNetUsers_AssistantId",
                table: "SupportAssistants");

            migrationBuilder.DropIndex(
                name: "IX_PostCommentLevel2s_CommentPostId",
                table: "PostCommentLevel2s");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DateEffective",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DateEnd",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Code",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_DateEffective",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_DateEnd",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "PostCommentLevel2s");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "PostCategories");

            migrationBuilder.RenameColumn(
                name: "CommentPostId",
                table: "PostCommentLevel2s",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "PostCategories",
                newName: "DateReplaced");

            migrationBuilder.RenameColumn(
                name: "LastModifiedById",
                table: "PostCategories",
                newName: "OriginId");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "PostCategories",
                newName: "DateEffective");

            migrationBuilder.RenameIndex(
                name: "IX_PostCategories_LastModifiedById",
                table: "PostCategories",
                newName: "IX_PostCategories_OriginId");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "WorkflowEntries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "WorkflowEntries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "UserWorkflows",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "UserWorkflows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "Templates",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "Templates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "TemplateParsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "TemplateParsers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssistantId",
                table: "SupportAssistants",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "StatusCounts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "StatusCounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "SentMessages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "SentMessages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "PostTags",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "PostTags",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "PostComments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AncestorId",
                table: "PostCommentLevel2s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DecendanntId",
                table: "PostCommentLevel2s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "PostCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscriptionNote",
                table: "PostCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "PostAccessUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "PostAccessUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "MessageBatches",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "MessageBatches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "HistoryWorkflowEntries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "HistoryWorkflowEntries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "EmployeeTitles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "EmployeeTitles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "Diary131s",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "Diary131s",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "DefinedWorkflows",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "DefinedWorkflows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "BackgroundProcesses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "BackgroundProcesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedById",
                table: "AutoMesasgeConfigMessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "AutoMesasgeConfigMessageReceivers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DepartmentRelation",
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
                    AncestorId = table.Column<int>(nullable: false),
                    DecendanntId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentRelation_Departments_AncestorId",
                        column: x => x.AncestorId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentRelation_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentRelation_Departments_DecendanntId",
                        column: x => x.DecendanntId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentRelation_DepartmentRelation_OriginId",
                        column: x => x.OriginId,
                        principalTable: "DepartmentRelation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentRelation_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostCategoryRelations",
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
                    AncestorId = table.Column<int>(nullable: false),
                    DecendanntId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategoryRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCategoryRelations_PostCategories_AncestorId",
                        column: x => x.AncestorId,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategoryRelations_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategoryRelations_PostCategories_DecendanntId",
                        column: x => x.DecendanntId,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategoryRelations_PostCategoryRelations_OriginId",
                        column: x => x.OriginId,
                        principalTable: "PostCategoryRelations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategoryRelations_AspNetUsers_RemovedById",
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
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 243, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 288, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 288, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 288, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 288, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 13, 2, 15, 53, 288, DateTimeKind.Local), new DateTime(2020, 4, 13, 2, 15, 53, 288, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowEntries_LastModifiedById",
                table: "WorkflowEntries",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkflows_LastModifiedById",
                table: "UserWorkflows",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_LastModifiedById",
                table: "Templates",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateParsers_LastModifiedById",
                table: "TemplateParsers",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCounts_LastModifiedById",
                table: "StatusCounts",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_SentMessages_LastModifiedById",
                table: "SentMessages",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_LastModifiedById",
                table: "PostTags",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_ParentId",
                table: "PostComments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentLevel2s_AncestorId",
                table: "PostCommentLevel2s",
                column: "AncestorId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentLevel2s_DecendanntId",
                table: "PostCommentLevel2s",
                column: "DecendanntId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_DateEffective",
                table: "PostCategories",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_DateEnd",
                table: "PostCategories",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_PostAccessUsers_LastModifiedById",
                table: "PostAccessUsers",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageBatches_LastModifiedById",
                table: "MessageBatches",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryWorkflowEntries_LastModifiedById",
                table: "HistoryWorkflowEntries",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LastModifiedById",
                table: "Events",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTitles_LastModifiedById",
                table: "EmployeeTitles",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LastModifiedById",
                table: "Employees",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Diary131s_LastModifiedById",
                table: "Diary131s",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_DefinedWorkflows_LastModifiedById",
                table: "DefinedWorkflows",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LastModifiedById",
                table: "Countries",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundProcesses_LastModifiedById",
                table: "BackgroundProcesses",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_LastModifiedById",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRelation_AncestorId",
                table: "DepartmentRelation",
                column: "AncestorId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRelation_CreatedById",
                table: "DepartmentRelation",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRelation_DateEffective",
                table: "DepartmentRelation",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRelation_DateEnd",
                table: "DepartmentRelation",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRelation_DecendanntId",
                table: "DepartmentRelation",
                column: "DecendanntId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRelation_OriginId",
                table: "DepartmentRelation",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRelation_RemovedById",
                table: "DepartmentRelation",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryRelations_AncestorId",
                table: "PostCategoryRelations",
                column: "AncestorId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryRelations_CreatedById",
                table: "PostCategoryRelations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryRelations_DateEffective",
                table: "PostCategoryRelations",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryRelations_DateEnd",
                table: "PostCategoryRelations",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryRelations_DecendanntId",
                table: "PostCategoryRelations",
                column: "DecendanntId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryRelations_OriginId",
                table: "PostCategoryRelations",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryRelations_RemovedById",
                table: "PostCategoryRelations",
                column: "RemovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoMesasgeConfigMessageReceivers_AspNetUsers_LastModifiedById",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BackgroundProcesses_AspNetUsers_LastModifiedById",
                table: "BackgroundProcesses",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_AspNetUsers_LastModifiedById",
                table: "Countries",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefinedWorkflows_AspNetUsers_LastModifiedById",
                table: "DefinedWorkflows",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diary131s_AspNetUsers_LastModifiedById",
                table: "Diary131s",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_LastModifiedById",
                table: "Employees",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTitles_AspNetUsers_LastModifiedById",
                table: "EmployeeTitles",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_LastModifiedById",
                table: "Events",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryWorkflowEntries_AspNetUsers_LastModifiedById",
                table: "HistoryWorkflowEntries",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageBatches_AspNetUsers_LastModifiedById",
                table: "MessageBatches",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostAccessUsers_AspNetUsers_LastModifiedById",
                table: "PostAccessUsers",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategories_PostCategories_OriginId",
                table: "PostCategories",
                column: "OriginId",
                principalTable: "PostCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCommentLevel2s_PostComments_AncestorId",
                table: "PostCommentLevel2s",
                column: "AncestorId",
                principalTable: "PostComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCommentLevel2s_PostComments_DecendanntId",
                table: "PostCommentLevel2s",
                column: "DecendanntId",
                principalTable: "PostComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_PostComments_ParentId",
                table: "PostComments",
                column: "ParentId",
                principalTable: "PostComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_AspNetUsers_LastModifiedById",
                table: "PostTags",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SentMessages_AspNetUsers_LastModifiedById",
                table: "SentMessages",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusCounts_AspNetUsers_LastModifiedById",
                table: "StatusCounts",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportAssistants_Employees_AssistantId",
                table: "SupportAssistants",
                column: "AssistantId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateParsers_AspNetUsers_LastModifiedById",
                table: "TemplateParsers",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_AspNetUsers_LastModifiedById",
                table: "Templates",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkflows_AspNetUsers_LastModifiedById",
                table: "UserWorkflows",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowEntries_AspNetUsers_LastModifiedById",
                table: "WorkflowEntries",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoMesasgeConfigMessageReceivers_AspNetUsers_LastModifiedById",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropForeignKey(
                name: "FK_BackgroundProcesses_AspNetUsers_LastModifiedById",
                table: "BackgroundProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_AspNetUsers_LastModifiedById",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_DefinedWorkflows_AspNetUsers_LastModifiedById",
                table: "DefinedWorkflows");

            migrationBuilder.DropForeignKey(
                name: "FK_Diary131s_AspNetUsers_LastModifiedById",
                table: "Diary131s");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_LastModifiedById",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTitles_AspNetUsers_LastModifiedById",
                table: "EmployeeTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_LastModifiedById",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryWorkflowEntries_AspNetUsers_LastModifiedById",
                table: "HistoryWorkflowEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageBatches_AspNetUsers_LastModifiedById",
                table: "MessageBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_PostAccessUsers_AspNetUsers_LastModifiedById",
                table: "PostAccessUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCategories_PostCategories_OriginId",
                table: "PostCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCommentLevel2s_PostComments_AncestorId",
                table: "PostCommentLevel2s");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCommentLevel2s_PostComments_DecendanntId",
                table: "PostCommentLevel2s");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_PostComments_ParentId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_AspNetUsers_LastModifiedById",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_SentMessages_AspNetUsers_LastModifiedById",
                table: "SentMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusCounts_AspNetUsers_LastModifiedById",
                table: "StatusCounts");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportAssistants_Employees_AssistantId",
                table: "SupportAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateParsers_AspNetUsers_LastModifiedById",
                table: "TemplateParsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Templates_AspNetUsers_LastModifiedById",
                table: "Templates");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkflows_AspNetUsers_LastModifiedById",
                table: "UserWorkflows");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowEntries_AspNetUsers_LastModifiedById",
                table: "WorkflowEntries");

            migrationBuilder.DropTable(
                name: "DepartmentRelation");

            migrationBuilder.DropTable(
                name: "PostCategoryRelations");

            migrationBuilder.DropIndex(
                name: "IX_WorkflowEntries_LastModifiedById",
                table: "WorkflowEntries");

            migrationBuilder.DropIndex(
                name: "IX_UserWorkflows_LastModifiedById",
                table: "UserWorkflows");

            migrationBuilder.DropIndex(
                name: "IX_Templates_LastModifiedById",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_TemplateParsers_LastModifiedById",
                table: "TemplateParsers");

            migrationBuilder.DropIndex(
                name: "IX_StatusCounts_LastModifiedById",
                table: "StatusCounts");

            migrationBuilder.DropIndex(
                name: "IX_SentMessages_LastModifiedById",
                table: "SentMessages");

            migrationBuilder.DropIndex(
                name: "IX_PostTags_LastModifiedById",
                table: "PostTags");

            migrationBuilder.DropIndex(
                name: "IX_PostComments_ParentId",
                table: "PostComments");

            migrationBuilder.DropIndex(
                name: "IX_PostCommentLevel2s_AncestorId",
                table: "PostCommentLevel2s");

            migrationBuilder.DropIndex(
                name: "IX_PostCommentLevel2s_DecendanntId",
                table: "PostCommentLevel2s");

            migrationBuilder.DropIndex(
                name: "IX_PostCategories_DateEffective",
                table: "PostCategories");

            migrationBuilder.DropIndex(
                name: "IX_PostCategories_DateEnd",
                table: "PostCategories");

            migrationBuilder.DropIndex(
                name: "IX_PostAccessUsers_LastModifiedById",
                table: "PostAccessUsers");

            migrationBuilder.DropIndex(
                name: "IX_MessageBatches_LastModifiedById",
                table: "MessageBatches");

            migrationBuilder.DropIndex(
                name: "IX_HistoryWorkflowEntries_LastModifiedById",
                table: "HistoryWorkflowEntries");

            migrationBuilder.DropIndex(
                name: "IX_Events_LastModifiedById",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTitles_LastModifiedById",
                table: "EmployeeTitles");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LastModifiedById",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Diary131s_LastModifiedById",
                table: "Diary131s");

            migrationBuilder.DropIndex(
                name: "IX_DefinedWorkflows_LastModifiedById",
                table: "DefinedWorkflows");

            migrationBuilder.DropIndex(
                name: "IX_Countries_LastModifiedById",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_BackgroundProcesses_LastModifiedById",
                table: "BackgroundProcesses");

            migrationBuilder.DropIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_LastModifiedById",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "WorkflowEntries");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "WorkflowEntries");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "UserWorkflows");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "UserWorkflows");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "TemplateParsers");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "TemplateParsers");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "StatusCounts");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "StatusCounts");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "SentMessages");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "SentMessages");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "AncestorId",
                table: "PostCommentLevel2s");

            migrationBuilder.DropColumn(
                name: "DecendanntId",
                table: "PostCommentLevel2s");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "DiscriptionNote",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "PostAccessUsers");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "PostAccessUsers");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "MessageBatches");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "MessageBatches");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "HistoryWorkflowEntries");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "HistoryWorkflowEntries");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "EmployeeTitles");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "EmployeeTitles");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Diary131s");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "Diary131s");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "DefinedWorkflows");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "DefinedWorkflows");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "BackgroundProcesses");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "BackgroundProcesses");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "PostCommentLevel2s",
                newName: "CommentPostId");

            migrationBuilder.RenameColumn(
                name: "OriginId",
                table: "PostCategories",
                newName: "LastModifiedById");

            migrationBuilder.RenameColumn(
                name: "DateReplaced",
                table: "PostCategories",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "DateEffective",
                table: "PostCategories",
                newName: "CreatedTime");

            migrationBuilder.RenameIndex(
                name: "IX_PostCategories_OriginId",
                table: "PostCategories",
                newName: "IX_PostCategories_LastModifiedById");

            migrationBuilder.AlterColumn<string>(
                name: "AssistantId",
                table: "SupportAssistants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "PostCommentLevel2s",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "PostCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 139, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 139, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 139, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 139, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 1, 1, 139, DateTimeKind.Local), new DateTime(2020, 4, 6, 22, 1, 1, 139, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentLevel2s_CommentPostId",
                table: "PostCommentLevel2s",
                column: "CommentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DateEffective",
                table: "Employees",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DateEnd",
                table: "Employees",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Code",
                table: "Departments",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_DateEffective",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_DateEnd",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "DateEnd");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategories_Employees_LastModifiedById",
                table: "PostCategories",
                column: "LastModifiedById",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCommentLevel2s_PostComments_CommentPostId",
                table: "PostCommentLevel2s",
                column: "CommentPostId",
                principalTable: "PostComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportAssistants_AspNetUsers_AssistantId",
                table: "SupportAssistants",
                column: "AssistantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
