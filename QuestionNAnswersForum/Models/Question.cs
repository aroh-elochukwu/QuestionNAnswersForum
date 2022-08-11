namespace QuestionNAnswersForum.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ApplicationUser User { get; set; }
        public string? UserId { get; set; }
        public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
        public DateTime DateAsked { get; set; }   
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public bool? UpVote { get; set; }
        public bool? DownVote { get; set; }
       

    }
}
