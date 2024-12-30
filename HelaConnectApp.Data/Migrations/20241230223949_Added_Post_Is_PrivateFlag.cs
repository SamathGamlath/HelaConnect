using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelaConnect.Migrations
{
    /// <inheritdoc />
    public partial class Added_Post_Is_PrivateFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Posts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Posts");
        }
    }
}
