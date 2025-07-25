using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Representational_State_Transfer.Migrations
{
    /// <inheritdoc />
    public partial class addedgender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gender",
                table: "Persons");
        }
    }
}
