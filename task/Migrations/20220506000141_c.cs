using Microsoft.EntityFrameworkCore.Migrations;

namespace task.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "Subjects",
                newName: "SubName");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Subjects",
                newName: "SID");

            migrationBuilder.RenameColumn(
                name: "GradeName",
                table: "Grades",
                newName: "GName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubName",
                table: "Subjects",
                newName: "SubjectName");

            migrationBuilder.RenameColumn(
                name: "SID",
                table: "Subjects",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "GName",
                table: "Grades",
                newName: "GradeName");
        }
    }
}
