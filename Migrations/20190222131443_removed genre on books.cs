using Microsoft.EntityFrameworkCore.Migrations;

namespace graphql_dotnetcore.Migrations
{
    public partial class removedgenreonbooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }
    }
}
