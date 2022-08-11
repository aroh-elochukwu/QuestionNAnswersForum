using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionNAnswersForum.Data.Migrations
{
    public partial class AddVotesToAnswerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DownVote",
                table: "Answer",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UpVote",
                table: "Answer",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DownVote",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "UpVote",
                table: "Answer");
        }
    }
}
