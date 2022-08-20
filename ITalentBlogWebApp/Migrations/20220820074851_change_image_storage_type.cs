using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITalentBlogWebApp.Migrations
{
    public partial class change_image_storage_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Posts",
                newName: "ImageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Posts",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
