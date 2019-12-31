using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asteck.SurveyPlus.Models
{
    public class QuestionnaireViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Survey Name")]
        public string Name { get; set; }
        public string Campaign { get; set; }
    }
}