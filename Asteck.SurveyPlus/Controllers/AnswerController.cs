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
    public class AnswerController : Controller
    {
        // GET: Answer
        public ActionResult Index()
        {
            var answerList = Business.Instance.GetAllAnswers();

            var answerViewList = answerList.Select(x => new AnswerViewModel { Id = x.Id, Title = x.Title });

            return View(answerViewList);
        }

        // GET: Answer/Details/5
        public ActionResult Details(int id)
        {
            var answer = Business.Instance.GetAnswer(id);

            var answerViewModel = new AnswerViewModel { Id = answer.Id, Title = answer.Title };

            return View(answerViewModel);
        }

        // GET: Answer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Answer/Create
        [HttpPost]
        public ActionResult Create(AnswerViewModel collection)
        {
            try
            {
                Business.Instance.CreateAnswer(new Answer
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

        // GET: Answer/Edit/5
        public ActionResult Edit(int id)
        {
            var answer = Business.Instance.GetAnswer(id);

            var answerViewModel = new AnswerViewModel { Id = answer.Id, Title = answer.Title };

            return View(answerViewModel);
        }

        // POST: Answer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AnswerViewModel collection)
        {
            try
            {
                Business.Instance.UpdateAnswer(new Answer
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

        // GET: Answer/Delete/5
        public ActionResult Delete(int id)
        {
            var answer = Business.Instance.GetAnswer(id);

            var answerViewModel = new AnswerViewModel { Id = answer.Id, Title = answer.Title };

            return View(answerViewModel);
        }

        // POST: Answer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AnswerViewModel collection)
        {
            try
            {
                Business.Instance.DeleteAnswer(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
