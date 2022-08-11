namespace QuestionNAnswersForum.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public ApplicationUser User { get; set; }
        public string? UserId { get; set; }
        public Question? Question { get; set; }
        public bool? UpVote { get; set; }
        public bool? DownVote { get; set; }

       
    }
}
