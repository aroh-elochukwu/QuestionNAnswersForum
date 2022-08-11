namespace QuestionNAnswersForum.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public DateTime CreatedDate { get; set; }
        public Question Question { get; set; }
    }
}
