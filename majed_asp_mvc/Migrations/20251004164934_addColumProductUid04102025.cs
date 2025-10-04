using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace majed_asp_mvc.Migrations
{
    /// <inheritdoc />
    public partial class addColumProductUid04102025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Products");
        }
    }
}
