using Asteck.SurveyPlus.Models;
using Asteck.SurveyPlus.Service;
using Asteck.SurveyPlus.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Asteck.SurveyPlus.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index()
        {
            var questionList = Business.Instance.GetAllQuestions();

            var questionViewList = questionList.Select(x => new QuestionViewModel { Id = x.Id, Title = x.Title });

            return View(questionViewList);
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            var question = Business.Instance.GetQuestion(id);

            var questionViewModel = new QuestionViewModel { Id = question.Id, Title = question.Title };

            return View(questionViewModel);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(QuestionViewModel collection)
        {
            try
            {
                Business.Instance.CreateQuestion(new Question
                {
                    Title = collection.Title,
                    CreatedOn = DateTime.Now,
                    CreatedBy = WebSecurity.CurrentUserName
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            var question = Business.Instance.GetQuestion(id);

            var questionViewModel = new QuestionViewModel { Id = question.Id, Title = question.Title };

            return View(questionViewModel);
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, QuestionViewModel collection)
        {
            try
            {
                Business.Instance.UpdateQuestion(new Question
                {
                    Id = id,
                    Title = collection.Title,
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = WebSecurity.CurrentUserName
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            var question= Business.Instance.GetQuestion(id);

            var questionViewModel = new QuestionViewModel { Id = question.Id, Title = question.Title };

            return View(questionViewModel);
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Business.Instance.DeleteQuestion(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
