using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyQuestions.Models;

namespace SurveyQuestions.Controllers
{
    public class QuestionController : Controller
    {
        private IQuestionRepository repository;
        public QuestionController(IQuestionRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Questions);

        public ViewResult EditQ(int questionNo) =>
 View(repository.Questions
 .FirstOrDefault(p => p.QuestionNum == questionNo));

        [HttpPost]
        public IActionResult EditQ(Question question)
        {
            if (ModelState.IsValid)
            {
                repository.SaveQuestion(question);
                TempData["message"] = "Your question has been saved";
                return RedirectToAction("List");
            }
            else
            {
                // there is something wrong with the data values
                return View(question);
            }

           
        }
        public ViewResult AddQ() => View("EditQ", new Question());

        [HttpPost]
        public IActionResult Delete(int QuestionNo)
        {
            Question deletedQuestion = repository.DeleteQuestion(QuestionNo);
            if (deletedQuestion != null)
            {
                TempData["message"] = $"{deletedQuestion.Prompt} was deleted";
            }
            else
            {
                TempData["message"] = $"{deletedQuestion.Prompt} was bugged";
            }
            return RedirectToAction("List");
        }
    }
}
