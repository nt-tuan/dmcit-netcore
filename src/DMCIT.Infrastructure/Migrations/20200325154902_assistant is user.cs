using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class assistantisuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportAssistants_Employees_EmployeeId",
                table: "SupportAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportRequests_Posts_PostId",
                table: "SupportRequests");

            migrationBuilder.DropIndex(
                name: "IX_SupportRequests_PostId",
                table: "SupportRequests");

            migrationBuilder.DropIndex(
                name: "IX_SupportAssistants_EmployeeId",
                table: "SupportAssistants");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "SupportRequests");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "SupportAssistants");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "SupportRequests",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssistantId",
                table: "SupportAssistants",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 703, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 750, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 750, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 750, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 750, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 3, 25, 22, 49, 0, 750, DateTimeKind.Local), new DateTime(2020, 3, 25, 22, 49, 0, 750, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_PostId",
                table: "SupportRequests",
                column: "PostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportAssistants_AssistantId",
                table: "SupportAssistants",
                column: "AssistantId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportAssistants_AspNetUsers_AssistantId",
                table: "SupportAssistants",
                column: "AssistantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportRequests_Posts_PostId",
                table: "SupportRequests",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportAssistants_AspNetUsers_AssistantId",
                table: "SupportAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportRequests_Posts_PostId",
                table: "SupportRequests");

            migrationBuilder.DropIndex(
                name: "IX_SupportRequests_PostId",
                table: "SupportRequests");

            migrationBuilder.DropIndex(
                name: "IX_SupportAssistants_AssistantId",
                table: "SupportAssistants");

            migrationBuilder.DropColumn(
                name: "AssistantId",
                table: "SupportAssistants");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "SupportRequests",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "SupportRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "SupportAssistants",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_SupportRequests_PostId",
                table: "SupportRequests",
                column: "PostId",
                unique: true,
                filter: "[PostId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SupportAssistants_EmployeeId",
                table: "SupportAssistants",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportAssistants_Employees_EmployeeId",
                table: "SupportAssistants",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportRequests_Posts_PostId",
                table: "SupportRequests",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
