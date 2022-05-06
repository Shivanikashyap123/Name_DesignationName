using Microsoft.EntityFrameworkCore.Migrations;

namespace task.Migrations
{
    public partial class newaddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_students_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_students_StudentId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_StudentId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "GradeName",
                table: "students");

            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Grades");

            migrationBuilder.CreateIndex(
                name: "IX_students_GradeId",
                table: "students",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_students_SubjectId",
                table: "students",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_students_Grades_GradeId",
                table: "students",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "GID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_Subjects_SubjectId",
                table: "students",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_Grades_GradeId",
                table: "students");

            migrationBuilder.DropForeignKey(
                name: "FK_students_Subjects_SubjectId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_GradeId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_SubjectId",
                table: "students");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GradeName",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Grades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StudentId",
                table: "Subjects",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_students_StudentId",
                table: "Subjects",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
