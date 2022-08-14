using System.ComponentModel.DataAnnotations;

namespace QuestionNAnswersForum.Models
{
    public class QuestionTagBar
    {
        [Key]
        public int Id { get; set; }
        public Question? Question { get; set; }
        public Tag? Tag { get; set; }
    }
}
