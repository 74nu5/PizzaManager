using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPateNCal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NCal",
                table: "Pates",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NCal",
                table: "Pates");
        }
    }
}