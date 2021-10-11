using Microsoft.EntityFrameworkCore.Migrations;

namespace AllGoodEdu.Data.Migrations
{
    public partial class ChangeCourseModelColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "Courses",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Courses",
                newName: "description");
        }
    }
}
