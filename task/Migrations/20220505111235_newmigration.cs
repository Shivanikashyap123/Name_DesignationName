using Microsoft.EntityFrameworkCore.Migrations;

namespace task.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Grades_GradeGID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Subjects_SubjectID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_SubjectID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Grades_GradeGID",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "GradeGID",
                table: "Grades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeGID",
                table: "Grades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectID",
                table: "Subjects",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_GradeGID",
                table: "Grades",
                column: "GradeGID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Grades_GradeGID",
                table: "Grades",
                column: "GradeGID",
                principalTable: "Grades",
                principalColumn: "GID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Subjects_SubjectID",
                table: "Subjects",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
