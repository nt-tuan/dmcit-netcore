using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class addwfrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CronExpression",
                table: "DefinedWorkflows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DefinedWorkflows",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnableParallelJobs",
                table: "DefinedWorkflows",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproval",
                table: "DefinedWorkflows",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "DefinedWorkflows",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LauchType",
                table: "DefinedWorkflows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LocalVariablesJSON",
                table: "DefinedWorkflows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DefinedWorkflows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParametersJSON",
                table: "DefinedWorkflows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "DefinedWorkflows",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StopWhenError",
                table: "DefinedWorkflows",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TasksJSON",
                table: "DefinedWorkflows",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CronExpression",
                table: "DefinedWorkflows");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DefinedWorkflows");

            migrationBuilder.DropColumn(
                name: "EnableParallelJobs",
                table: "DefinedWorkflows");

            migrationBuilder.DropColumn(
                name: "IsApproval",
                table: "DefinedWorkflows");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "DefinedWorkflows");

            migrationBuilder.DropColumn(
                name: "LauchType",
                table: "DefinedWorkflows");

            migrationBuilder.DropColumn(
                name: "LocalVariablesJSON",
                table: "DefinedWorkflows");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DefinedWorkflows");

            migrationBuilder.DropColumn(
                name: "ParametersJSON",
                table: "DefinedWorkflows");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "DefinedWorkflows");

            migrationBuilder.DropColumn(
                name: "StopWhenError",
                table: "DefinedWorkflows");

            migrationBuilder.DropColumn(
                name: "TasksJSON",
                table: "DefinedWorkflows");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 678, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 678, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 678, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 678, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 17, 14, 22, 40, 678, DateTimeKind.Local), new DateTime(2020, 1, 17, 14, 22, 40, 678, DateTimeKind.Local) });
        }
    }
}
