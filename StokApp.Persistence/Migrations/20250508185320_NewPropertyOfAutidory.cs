using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewPropertyOfAutidory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Remove",
                table: "Productos",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Remove",
                table: "Categorias",
                type: "bit",
                nullable: true,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remove",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Remove",
                table: "Categorias");
        }
    }
}
