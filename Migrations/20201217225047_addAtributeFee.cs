using Microsoft.EntityFrameworkCore.Migrations;

namespace AlquilerApp.Migrations
{
    public partial class addAtributeFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Sign",
                table: "Fee",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sign",
                table: "Fee");
        }
    }
}
