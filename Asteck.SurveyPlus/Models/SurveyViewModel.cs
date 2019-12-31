using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asteck.SurveyPlus.Models
{
    public class SurveyViewModel
    {
        public int Id { get; set; }

        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}