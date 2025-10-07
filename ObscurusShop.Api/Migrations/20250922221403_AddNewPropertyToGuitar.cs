using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObscurusShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertyToGuitar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Guitars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Guitars");
        }
    }
}
