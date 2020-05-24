using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class timedependentdistributedserver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistributedServerDefinedTable_DistributedServers_DistributedServerId",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DistributedServers",
                table: "DistributedServers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DistributedServerDefinedTable",
                table: "DistributedServerDefinedTable");

            migrationBuilder.AlterColumn<string>(
                name: "DistributorCode",
                table: "DistributedServers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DistributedServers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "DistributedServers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "DistributedServers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEffective",
                table: "DistributedServers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "DistributedServers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "DistributedServers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReplaced",
                table: "DistributedServers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscriptionNote",
                table: "DistributedServers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "DistributedServers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "DistributedServers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TableName",
                table: "DistributedServerDefinedTable",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "DistributedServerId",
                table: "DistributedServerDefinedTable",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DistributedServerDefinedTable",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "DistributedServerDefinedTable",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "DistributedServerDefinedTable",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEffective",
                table: "DistributedServerDefinedTable",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "DistributedServerDefinedTable",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "DistributedServerDefinedTable",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReplaced",
                table: "DistributedServerDefinedTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscriptionNote",
                table: "DistributedServerDefinedTable",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "DistributedServerDefinedTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "DistributedServerDefinedTable",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DistributedServers",
                table: "DistributedServers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DistributedServerDefinedTable",
                table: "DistributedServerDefinedTable",
                column: "Id");

            var updateValue = new object[] { new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) };
            for (var i = 1; i <= 11; i++)
            {
                migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: i,
                columns: new[] { "DateCreated", "DateEffective" },
                values: updateValue);
            }

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 655, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 655, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 655, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 655, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 15, 19, 2, 11, 655, DateTimeKind.Local), new DateTime(2020, 1, 15, 19, 2, 11, 655, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_DistributedServers_CreatedById",
                table: "DistributedServers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DistributedServers_DateEffective",
                table: "DistributedServers",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_DistributedServers_DateEnd",
                table: "DistributedServers",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_DistributedServers_DistributorCode",
                table: "DistributedServers",
                column: "DistributorCode");

            migrationBuilder.CreateIndex(
                name: "IX_DistributedServers_OriginId",
                table: "DistributedServers",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributedServers_RemovedById",
                table: "DistributedServers",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_DistributedServerDefinedTable_CreatedById",
                table: "DistributedServerDefinedTable",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DistributedServerDefinedTable_DateEffective",
                table: "DistributedServerDefinedTable",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_DistributedServerDefinedTable_DateEnd",
                table: "DistributedServerDefinedTable",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_DistributedServerDefinedTable_DistributedServerId",
                table: "DistributedServerDefinedTable",
                column: "DistributedServerId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributedServerDefinedTable_OriginId",
                table: "DistributedServerDefinedTable",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributedServerDefinedTable_RemovedById",
                table: "DistributedServerDefinedTable",
                column: "RemovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_DistributedServerDefinedTable_AspNetUsers_CreatedById",
                table: "DistributedServerDefinedTable",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DistributedServerDefinedTable_DistributedServers_DistributedServerId",
                table: "DistributedServerDefinedTable",
                column: "DistributedServerId",
                principalTable: "DistributedServers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DistributedServerDefinedTable_DistributedServerDefinedTable_OriginId",
                table: "DistributedServerDefinedTable",
                column: "OriginId",
                principalTable: "DistributedServerDefinedTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DistributedServerDefinedTable_AspNetUsers_RemovedById",
                table: "DistributedServerDefinedTable",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DistributedServers_AspNetUsers_CreatedById",
                table: "DistributedServers",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DistributedServers_DistributedServers_OriginId",
                table: "DistributedServers",
                column: "OriginId",
                principalTable: "DistributedServers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DistributedServers_AspNetUsers_RemovedById",
                table: "DistributedServers",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistributedServerDefinedTable_AspNetUsers_CreatedById",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropForeignKey(
                name: "FK_DistributedServerDefinedTable_DistributedServers_DistributedServerId",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropForeignKey(
                name: "FK_DistributedServerDefinedTable_DistributedServerDefinedTable_OriginId",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropForeignKey(
                name: "FK_DistributedServerDefinedTable_AspNetUsers_RemovedById",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropForeignKey(
                name: "FK_DistributedServers_AspNetUsers_CreatedById",
                table: "DistributedServers");

            migrationBuilder.DropForeignKey(
                name: "FK_DistributedServers_DistributedServers_OriginId",
                table: "DistributedServers");

            migrationBuilder.DropForeignKey(
                name: "FK_DistributedServers_AspNetUsers_RemovedById",
                table: "DistributedServers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DistributedServers",
                table: "DistributedServers");

            migrationBuilder.DropIndex(
                name: "IX_DistributedServers_CreatedById",
                table: "DistributedServers");

            migrationBuilder.DropIndex(
                name: "IX_DistributedServers_DateEffective",
                table: "DistributedServers");

            migrationBuilder.DropIndex(
                name: "IX_DistributedServers_DateEnd",
                table: "DistributedServers");

            migrationBuilder.DropIndex(
                name: "IX_DistributedServers_DistributorCode",
                table: "DistributedServers");

            migrationBuilder.DropIndex(
                name: "IX_DistributedServers_OriginId",
                table: "DistributedServers");

            migrationBuilder.DropIndex(
                name: "IX_DistributedServers_RemovedById",
                table: "DistributedServers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DistributedServerDefinedTable",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropIndex(
                name: "IX_DistributedServerDefinedTable_CreatedById",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropIndex(
                name: "IX_DistributedServerDefinedTable_DateEffective",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropIndex(
                name: "IX_DistributedServerDefinedTable_DateEnd",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropIndex(
                name: "IX_DistributedServerDefinedTable_DistributedServerId",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropIndex(
                name: "IX_DistributedServerDefinedTable_OriginId",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropIndex(
                name: "IX_DistributedServerDefinedTable_RemovedById",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DistributedServers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "DistributedServers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "DistributedServers");

            migrationBuilder.DropColumn(
                name: "DateEffective",
                table: "DistributedServers");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "DistributedServers");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "DistributedServers");

            migrationBuilder.DropColumn(
                name: "DateReplaced",
                table: "DistributedServers");

            migrationBuilder.DropColumn(
                name: "DiscriptionNote",
                table: "DistributedServers");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "DistributedServers");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "DistributedServers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropColumn(
                name: "DateEffective",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropColumn(
                name: "DateReplaced",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropColumn(
                name: "DiscriptionNote",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "DistributedServerDefinedTable");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "DistributedServerDefinedTable");

            migrationBuilder.AlterColumn<string>(
                name: "DistributorCode",
                table: "DistributedServers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TableName",
                table: "DistributedServerDefinedTable",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DistributedServerId",
                table: "DistributedServerDefinedTable",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DistributedServers",
                table: "DistributedServers",
                column: "DistributorCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DistributedServerDefinedTable",
                table: "DistributedServerDefinedTable",
                columns: new[] { "DistributedServerId", "TableName" });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 615, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 618, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 618, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 618, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 618, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 1, 6, 16, 20, 47, 618, DateTimeKind.Local), new DateTime(2020, 1, 6, 16, 20, 47, 618, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_DistributedServerDefinedTable_DistributedServers_DistributedServerId",
                table: "DistributedServerDefinedTable",
                column: "DistributedServerId",
                principalTable: "DistributedServers",
                principalColumn: "DistributorCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
