using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class Addpostandsupportrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    LastModifiedById = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCategories_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategories_Employees_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategories_PostCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategories_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
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
                    FeatureLevel = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true),
                    CanComment = table.Column<bool>(nullable: false),
                    PostRestrictionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_PostCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Posts_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostAccessUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostAccessUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostAccessUsers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostAccessUsers_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostAccessUsers_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostAccessUsers_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
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
                    Content = table.Column<string>(nullable: true),
                    PageId = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComments_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostComments_PostComments_OriginId",
                        column: x => x.OriginId,
                        principalTable: "PostComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostComments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostComments_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    TagId = table.Column<string>(nullable: true),
                    PostId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTags_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId1",
                        column: x => x.PostId1,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostTags_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupportRequests",
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
                    Subject = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    RequestStatusNumber = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Conlusion = table.Column<string>(nullable: true),
                    ConfirmFinishCode = table.Column<string>(nullable: true),
                    RequesterId = table.Column<int>(nullable: false),
                    AssignedById = table.Column<int>(nullable: true),
                    AssignedToId = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportRequests_Employees_AssignedById",
                        column: x => x.AssignedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportRequests_Employees_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportRequests_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportRequests_SupportRequests_OriginId",
                        column: x => x.OriginId,
                        principalTable: "SupportRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportRequests_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportRequests_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportRequests_Employees_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostCommentLevel2s",
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
                    Content = table.Column<string>(nullable: true),
                    CommentPostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCommentLevel2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCommentLevel2s_PostComments_CommentPostId",
                        column: x => x.CommentPostId,
                        principalTable: "PostComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCommentLevel2s_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCommentLevel2s_PostCommentLevel2s_OriginId",
                        column: x => x.OriginId,
                        principalTable: "PostCommentLevel2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCommentLevel2s_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupportAssistants",
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
                    EmployeeId = table.Column<int>(nullable: false),
                    SupportRequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportAssistants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportAssistants_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportAssistants_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportAssistants_SupportAssistants_OriginId",
                        column: x => x.OriginId,
                        principalTable: "SupportAssistants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportAssistants_AspNetUsers_RemovedById",
                        column: x => x.RemovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportAssistants_SupportRequests_SupportRequestId",
                        column: x => x.SupportRequestId,
                        principalTable: "SupportRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 579, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 624, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 624, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 624, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 624, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 24, 1, 46, 45, 624, DateTimeKind.Local), new DateTime(2020, 3, 24, 1, 46, 45, 624, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_PostAccessUsers_AppUserId",
                table: "PostAccessUsers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostAccessUsers_CreatedById",
                table: "PostAccessUsers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostAccessUsers_PostId",
                table: "PostAccessUsers",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostAccessUsers_RemovedById",
                table: "PostAccessUsers",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_CreatedById",
                table: "PostCategories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_LastModifiedById",
                table: "PostCategories",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_ParentId",
                table: "PostCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_RemovedById",
                table: "PostCategories",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentLevel2s_CommentPostId",
                table: "PostCommentLevel2s",
                column: "CommentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentLevel2s_CreatedById",
                table: "PostCommentLevel2s",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentLevel2s_DateEffective",
                table: "PostCommentLevel2s",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentLevel2s_DateEnd",
                table: "PostCommentLevel2s",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentLevel2s_OriginId",
                table: "PostCommentLevel2s",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentLevel2s_RemovedById",
                table: "PostCommentLevel2s",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_CreatedById",
                table: "PostComments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_DateEffective",
                table: "PostComments",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_DateEnd",
                table: "PostComments",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_OriginId",
                table: "PostComments",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_PostId",
                table: "PostComments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_RemovedById",
                table: "PostComments",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CreatedById",
                table: "Posts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_DateEffective",
                table: "Posts",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_DateEnd",
                table: "Posts",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_OriginId",
                table: "Posts",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_RemovedById",
                table: "Posts",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_CreatedById",
                table: "PostTags",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostId",
                table: "PostTags",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostId1",
                table: "PostTags",
                column: "PostId1");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_RemovedById",
                table: "PostTags",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportAssistants_CreatedById",
                table: "SupportAssistants",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SupportAssistants_DateEffective",
                table: "SupportAssistants",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_SupportAssistants_DateEnd",
                table: "SupportAssistants",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_SupportAssistants_EmployeeId",
                table: "SupportAssistants",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportAssistants_OriginId",
                table: "SupportAssistants",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportAssistants_RemovedById",
                table: "SupportAssistants",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_SupportAssistants_SupportRequestId",
                table: "SupportAssistants",
                column: "SupportRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_AssignedById",
                table: "SupportRequests",
                column: "AssignedById");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_AssignedToId",
                table: "SupportRequests",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_CreatedById",
                table: "SupportRequests",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_DateEffective",
                table: "SupportRequests",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_DateEnd",
                table: "SupportRequests",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_OriginId",
                table: "SupportRequests",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_PostId",
                table: "SupportRequests",
                column: "PostId",
                unique: true,
                filter: "[PostId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_RemovedById",
                table: "SupportRequests",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_RequesterId",
                table: "SupportRequests",
                column: "RequesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostAccessUsers");

            migrationBuilder.DropTable(
                name: "PostCommentLevel2s");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "SupportAssistants");

            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "SupportRequests");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 921, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 975, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 975, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 975, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 975, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 28, 15, 17, 17, 975, DateTimeKind.Local), new DateTime(2020, 2, 28, 15, 17, 17, 975, DateTimeKind.Local) });
        }
    }
}
