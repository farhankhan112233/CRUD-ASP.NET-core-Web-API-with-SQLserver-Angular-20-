using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Representational_State_Transfer.Migrations
{
    /// <inheritdoc />
    public partial class nestedFormdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "street",
                table: "Persons",
                newName: "Address_street");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Persons",
                newName: "Address_country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Persons",
                newName: "Address_city");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_street",
                table: "Persons",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "Address_country",
                table: "Persons",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Address_city",
                table: "Persons",
                newName: "city");
        }
    }
}
