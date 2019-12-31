using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asteck.SurveyPlus.Models
{
    public class AnswerViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Option")]
        public string Title { get; set; }
    }
}