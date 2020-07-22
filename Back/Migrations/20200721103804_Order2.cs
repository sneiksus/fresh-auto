using Microsoft.EntityFrameworkCore.Migrations;

namespace Back.Migrations
{
    public partial class Order2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentar",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentar",
                table: "Orders");
        }
    }
}
