using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordering.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBillingAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuildingAdress_ZipCode",
                table: "Orders",
                newName: "BillingAddress_ZipCode");

            migrationBuilder.RenameColumn(
                name: "BuildingAdress_State",
                table: "Orders",
                newName: "BillingAddress_State");

            migrationBuilder.RenameColumn(
                name: "BuildingAdress_LastName",
                table: "Orders",
                newName: "BillingAddress_LastName");

            migrationBuilder.RenameColumn(
                name: "BuildingAdress_FirstName",
                table: "Orders",
                newName: "BillingAddress_FirstName");

            migrationBuilder.RenameColumn(
                name: "BuildingAdress_EmailAddress",
                table: "Orders",
                newName: "BillingAddress_EmailAddress");

            migrationBuilder.RenameColumn(
                name: "BuildingAdress_Country",
                table: "Orders",
                newName: "BillingAddress_Country");

            migrationBuilder.RenameColumn(
                name: "BuildingAdress_AddressLine",
                table: "Orders",
                newName: "BillingAddress_AddressLine");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BillingAddress_ZipCode",
                table: "Orders",
                newName: "BuildingAdress_ZipCode");

            migrationBuilder.RenameColumn(
                name: "BillingAddress_State",
                table: "Orders",
                newName: "BuildingAdress_State");

            migrationBuilder.RenameColumn(
                name: "BillingAddress_LastName",
                table: "Orders",
                newName: "BuildingAdress_LastName");

            migrationBuilder.RenameColumn(
                name: "BillingAddress_FirstName",
                table: "Orders",
                newName: "BuildingAdress_FirstName");

            migrationBuilder.RenameColumn(
                name: "BillingAddress_EmailAddress",
                table: "Orders",
                newName: "BuildingAdress_EmailAddress");

            migrationBuilder.RenameColumn(
                name: "BillingAddress_Country",
                table: "Orders",
                newName: "BuildingAdress_Country");

            migrationBuilder.RenameColumn(
                name: "BillingAddress_AddressLine",
                table: "Orders",
                newName: "BuildingAdress_AddressLine");
        }
    }
}
