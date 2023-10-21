using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MannariEnterprises.Migrations
{
    /// <inheritdoc />
    public partial class emailmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Logins");
        }
    }
}
