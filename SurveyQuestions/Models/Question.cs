using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SurveyQuestions.Models
{
    public class Question
    {
        [Key]
        public int QuestionNum { get; set; }
        [Required(ErrorMessage = "Please enter a domain number.")]
        public int DomainNum { get; set; }
        [Required(ErrorMessage ="Please enter a prompt.")]
        public string Prompt { get; set; }

    }
}
