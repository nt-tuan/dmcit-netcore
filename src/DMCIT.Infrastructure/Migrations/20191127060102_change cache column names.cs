using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DMCIT.Infrastructure.Migrations
{
    public partial class changecachecolumnnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "BusinessCountryId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "PersonPhone",
                table: "Customers",
                newName: "CachePersonPhone");

            migrationBuilder.RenameColumn(
                name: "PersonLastName",
                table: "Customers",
                newName: "CachePersonLastName");

            migrationBuilder.RenameColumn(
                name: "PersonIdentityNumber",
                table: "Customers",
                newName: "CachePersonIdentityNumber");

            migrationBuilder.RenameColumn(
                name: "PersonGender",
                table: "Customers",
                newName: "CachePersonGender");

            migrationBuilder.RenameColumn(
                name: "PersonFullName",
                table: "Customers",
                newName: "CachePersonFullName");

            migrationBuilder.RenameColumn(
                name: "PersonFirstName",
                table: "Customers",
                newName: "CachePersonFirstName");

            migrationBuilder.RenameColumn(
                name: "PersonEmail",
                table: "Customers",
                newName: "CachePersonEmail");

            migrationBuilder.RenameColumn(
                name: "PersonDisplayName",
                table: "Customers",
                newName: "CachePersonDisplayName");

            migrationBuilder.RenameColumn(
                name: "PersonBirthday",
                table: "Customers",
                newName: "CachePersonBirthday");

            migrationBuilder.RenameColumn(
                name: "PersonAddress",
                table: "Customers",
                newName: "CachePersonAddress");

            migrationBuilder.RenameColumn(
                name: "BusinessTaxNumber",
                table: "Customers",
                newName: "CacheBusinessTaxNumber");

            migrationBuilder.RenameColumn(
                name: "BusinessPhone",
                table: "Customers",
                newName: "CacheBusinessPhone");

            migrationBuilder.RenameColumn(
                name: "BusinessMobilePhone",
                table: "Customers",
                newName: "CacheBusinessMobilePhone");

            migrationBuilder.RenameColumn(
                name: "BusinessIdentityNumber",
                table: "Customers",
                newName: "CacheBusinessIdentityNumber");

            migrationBuilder.RenameColumn(
                name: "BusinessFullName",
                table: "Customers",
                newName: "CacheBusinessFullName");

            migrationBuilder.RenameColumn(
                name: "BusinessEmail",
                table: "Customers",
                newName: "CacheBusinessEmail");

            migrationBuilder.RenameColumn(
                name: "BusinessDisplayName",
                table: "Customers",
                newName: "CacheBusinessDisplayName");

            migrationBuilder.RenameColumn(
                name: "BusinessAddress",
                table: "Customers",
                newName: "CacheBusinessAddress");

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 687, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 690, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 690, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 690, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 690, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "MessageServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateEffective" },
                values: new object[] { new DateTime(2019, 11, 27, 13, 1, 1, 690, DateTimeKind.Local), new DateTime(2019, 11, 27, 13, 1, 1, 690, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CachePersonPhone",
                table: "Customers",
                newName: "PersonPhone");

            migrationBuilder.RenameColumn(
                name: "CachePersonLastName",
                table: "Customers",
                newName: "PersonLastName");

            migrationBuilder.RenameColumn(
                name: "CachePersonIdentityNumber",
                table: "Customers",
                newName: "PersonIdentityNumber");

            migrationBuilder.RenameColumn(
                name: "CachePersonGender",
                table: "Customers",
                newName: "PersonGender");

            migrationBuilder.RenameColumn(
                name: "CachePersonFullName",
                table: "Customers",
                newName: "PersonFullName");

            migrationBuilder.RenameColumn(
                name: "CachePersonFirstName",
                table: "Customers",
                newName: "PersonFirstName");

            migrationBuilder.RenameColumn(
                name: "CachePersonEmail",
                table: "Customers",
                newName: "PersonEmail");

            migrationBuilder.RenameColumn(
                name: "CachePersonDisplayName",
                table: "Customers",
                newName: "PersonDisplayName");

            migrationBuilder.RenameColumn(
                name: "CachePersonBirthday",
                table: "Customers",
                newName: "PersonBirthday");

            migrationBuilder.RenameColumn(
                name: "CachePersonAddress",
                table: "Customers",
                newName: "PersonAddress");

            migrationBuilder.RenameColumn(
                name: "CacheBusinessTaxNumber",
                table: "Customers",
                newName: "BusinessTaxNumber");

            migrationBuilder.RenameColumn(
                name: "CacheBusinessPhone",
                table: "Customers",
                newName: "BusinessPhone");

            migrationBuilder.RenameColumn(
                name: "CacheBusinessMobilePhone",
                table: "Customers",
                newName: "BusinessMobilePhone");

            migrationBuilder.RenameColumn(
                name: "CacheBusinessIdentityNumber",
                table: "Customers",
                newName: "BusinessIdentityNumber");

            migrationBuilder.RenameColumn(
                name: "CacheBusinessFullName",
                table: "Customers",
                newName: "BusinessFullName");

            migrationBuilder.RenameColumn(
                name: "CacheBusinessEmail",
                table: "Customers",
                newName: "BusinessEmail");

            migrationBuilder.RenameColumn(
                name: "CacheBusinessDisplayName",
                table: "Customers",
                newName: "BusinessDisplayName");

            migrationBuilder.RenameColumn(
                name: "CacheBusinessAddress",
                table: "Customers",
                newName: "BusinessAddress");

            migrationBuilder.AddColumn<int>(
                name: "BusinessCountryId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
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
    }
}
