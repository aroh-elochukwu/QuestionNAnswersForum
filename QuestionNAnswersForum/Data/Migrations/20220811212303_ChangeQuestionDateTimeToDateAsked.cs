using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionNAnswersForum.Data.Migrations
{
    public partial class ChangeQuestionDateTimeToDateAsked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Question",
                newName: "DateAsked");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateAsked",
                table: "Question",
                newName: "DateTime");
        }
    }
}
