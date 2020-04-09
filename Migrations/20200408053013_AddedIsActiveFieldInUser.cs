using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIApp.Migrations
{
    public partial class AddedIsActiveFieldInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Users",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Users");
        }
    }
}
