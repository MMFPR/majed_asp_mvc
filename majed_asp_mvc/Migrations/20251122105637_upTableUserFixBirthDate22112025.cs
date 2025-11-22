using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace majed_asp_mvc.Migrations
{
    /// <inheritdoc />
    public partial class upTableUserFixBirthDate22112025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Users",
                newName: "BirthDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Users",
                newName: "Birthday");
        }
    }
}
