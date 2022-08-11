using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionNAnswersForum.Data.Migrations
{
    public partial class AddUpVoteAndDownVoteToQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DownVote",
                table: "Question",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UpVote",
                table: "Question",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DownVote",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "UpVote",
                table: "Question");
        }
    }
}
