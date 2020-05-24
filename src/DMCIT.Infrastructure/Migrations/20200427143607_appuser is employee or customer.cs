using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class appuserisemployeeorcustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Businesses_BusinessId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_People_PersonId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_LastModifiedById",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LastModifiedById",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BusinessId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "LastModifiedById",
                table: "Employees",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "AspNetUsers",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "AspNetUsers",
                newName: "CustomerId");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "People",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Businesses",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 132, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 180, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 180, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 180, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 180, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2020, 4, 27, 21, 36, 5, 180, DateTimeKind.Local), new DateTime(2020, 4, 27, 21, 36, 5, 180, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_People_AppUserId",
                table: "People",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DateEffective",
                table: "Employees",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DateEnd",
                table: "Employees",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_AppUserId",
                table: "Businesses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_AspNetUsers_AppUserId",
                table: "Businesses",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_AspNetUsers_AppUserId",
                table: "People",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_AspNetUsers_AppUserId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_People_AspNetUsers_AppUserId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_AppUserId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DateEffective",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DateEnd",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_AppUserId",
                table: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Businesses");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Employees",
                newName: "LastModifiedById");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "AspNetUsers",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "AspNetUsers",
                newName: "BusinessId");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedById",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "Employees",
                nullable: true);

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
                name: "IX_Employees_LastModifiedById",
                table: "Employees",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BusinessId",
                table: "AspNetUsers",
                column: "BusinessId",
                unique: true,
                filter: "[BusinessId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Businesses_BusinessId",
                table: "AspNetUsers",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_People_PersonId",
                table: "AspNetUsers",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_LastModifiedById",
                table: "Employees",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
