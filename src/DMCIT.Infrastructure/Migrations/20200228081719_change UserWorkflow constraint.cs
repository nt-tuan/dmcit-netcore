using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class changeUserWorkflowconstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkflows_AspNetUsers_AppUserId",
                table: "UserWorkflows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWorkflows",
                table: "UserWorkflows");

            migrationBuilder.DropIndex(
                name: "IX_UserWorkflows_AppUserId",
                table: "UserWorkflows");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserWorkflows");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "UserWorkflows",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWorkflows",
                table: "UserWorkflows",
                columns: new[] { "AppUserId", "DefinedWorkflowId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkflows_AspNetUsers_AppUserId",
                table: "UserWorkflows",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkflows_AspNetUsers_AppUserId",
                table: "UserWorkflows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWorkflows",
                table: "UserWorkflows");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "UserWorkflows",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserWorkflows",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWorkflows",
                table: "UserWorkflows",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 591, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 637, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 637, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 637, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 637, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 2, 7, 8, 21, 39, 637, DateTimeKind.Local), new DateTime(2020, 2, 7, 8, 21, 39, 637, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkflows_AppUserId",
                table: "UserWorkflows",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkflows_AspNetUsers_AppUserId",
                table: "UserWorkflows",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
