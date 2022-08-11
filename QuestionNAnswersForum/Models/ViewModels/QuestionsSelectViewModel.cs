using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuestionNAnswersForum.Models.ViewModels
{
    public class QuestionsSelectViewModel
    {
        public List<SelectListItem> QuestionSelect { get; set; }

        public QuestionsSelectViewModel(List<Question> Questions)
        {
            QuestionSelect = new List<SelectListItem>();

            Questions.ForEach(q =>
            {
                QuestionSelect.Add(new SelectListItem(q.Title, q.Id.ToString()));
            });
        }

    }
}
