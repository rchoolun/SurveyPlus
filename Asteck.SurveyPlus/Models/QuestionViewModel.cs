using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asteck.SurveyPlus.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Question")]
        public string Title { get; set; }

        public IEnumerable<AnswerViewModel> Answers { get; set; }

    }
}