using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class Addcachecolumntocustomertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "Businesses",
                newName: "DisplayName");

            migrationBuilder.AddColumn<string>(
                name: "BusinessAddress",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessCountryId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessDisplayName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessEmail",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessFullName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessIdentityNumber",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessMobilePhone",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessPhone",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessTaxNumber",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonAddress",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PersonBirthday",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonDisplayName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonEmail",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonFirstName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonFullName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonGender",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PersonIdentityNumber",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonLastName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonPhone",
                table: "Customers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 475, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 497, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 497, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 497, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 497, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 26, 17, 22, 30, 497, DateTimeKind.Local), new DateTime(2019, 11, 26, 17, 22, 30, 497, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BusinessCountryId",
                table: "Customers",
                column: "BusinessCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Countries_BusinessCountryId",
                table: "Customers",
                column: "BusinessCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Countries_CountryId",
                table: "Customers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Countries_BusinessCountryId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Countries_CountryId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_BusinessCountryId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CountryId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessCountryId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessDisplayName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessEmail",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessFullName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessIdentityNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessMobilePhone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessPhone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessTaxNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonBirthday",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonDisplayName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonEmail",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonFirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonFullName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonGender",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonIdentityNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonLastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonPhone",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "Businesses",
                newName: "ShortName");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 110, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 113, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 113, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 113, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 113, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 25, 13, 9, 57, 113, DateTimeKind.Local), new DateTime(2019, 11, 25, 13, 9, 57, 113, DateTimeKind.Local) });
        }
    }
}
