using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Representational_State_Transfer.Migrations
{
    /// <inheritdoc />
    public partial class mailchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Persons",
                newName: "mail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mail",
                table: "Persons",
                newName: "email");
        }
    }
}
