using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MannariEnterprises.Migrations
{
    /// <inheritdoc />
    public partial class rolemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "Logins");
        }
    }
}
