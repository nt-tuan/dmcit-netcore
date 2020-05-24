using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class fixtemplatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_TemplateTypes_TemplateTypeId",
                table: "Templates");

            migrationBuilder.DropTable(
                name: "TemplateTypes");

            migrationBuilder.CreateTable(
                name: "TemplateParsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ClassName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateParsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateParsers_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemplateParsers_AspNetUsers_RemovedById",
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
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 347, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 349, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 349, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 349, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 349, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 9, 9, 43, 34, 349, DateTimeKind.Local), new DateTime(2019, 12, 9, 9, 43, 34, 349, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateParsers_CreatedById",
                table: "TemplateParsers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateParsers_Name",
                table: "TemplateParsers",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateParsers_RemovedById",
                table: "TemplateParsers",
                column: "RemovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_TemplateParsers_TemplateTypeId",
                table: "Templates",
                column: "TemplateTypeId",
                principalTable: "TemplateParsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_TemplateParsers_TemplateTypeId",
                table: "Templates");

            migrationBuilder.DropTable(
                name: "TemplateParsers");

            migrationBuilder.CreateTable(
                name: "TemplateTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateRemoved = table.Column<DateTime>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Initial = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RemovedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateTypes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemplateTypes_AspNetUsers_RemovedById",
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
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 498, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 502, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 502, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 502, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 502, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 12, 8, 14, 15, 12, 502, DateTimeKind.Local), new DateTime(2019, 12, 8, 14, 15, 12, 502, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTypes_CreatedById",
                table: "TemplateTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTypes_Name",
                table: "TemplateTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTypes_RemovedById",
                table: "TemplateTypes",
                column: "RemovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_TemplateTypes_TemplateTypeId",
                table: "Templates",
                column: "TemplateTypeId",
                principalTable: "TemplateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
