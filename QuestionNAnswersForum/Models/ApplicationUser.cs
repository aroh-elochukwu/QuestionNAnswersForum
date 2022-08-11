﻿using Microsoft.AspNetCore.Identity;

namespace QuestionNAnswersForum.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();
        public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();

        public ApplicationUser() : base()
        {

        }

    }
}
