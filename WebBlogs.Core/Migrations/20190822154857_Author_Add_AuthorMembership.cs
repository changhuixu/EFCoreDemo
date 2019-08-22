using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBlogs.Core.Migrations
{
    public partial class Author_Add_AuthorMembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorMembership",
                table: "Authors",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorMembership",
                table: "Authors");
        }
    }
}
