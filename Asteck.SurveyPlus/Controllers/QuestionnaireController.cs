using Asteck.SurveyPlus.Models;
using Asteck.SurveyPlus.Service;
using Asteck.SurveyPlus.Service.Model;
using System;
using System.Linq;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Asteck.SurveyPlus.Controllers
{
    [Authorize]
    public class QuestionnaireController : Controller
    {
        // GET: Questionnaire
        public ActionResult Index()
        {
            var questionanireList = Business.Instance.GetAllQuestionnaire();

            var questionanireViewList = questionanireList.Select(x => new QuestionnaireViewModel { Id = x.Id, Campaign = x.Campaign, Name = x.Name });

            return View(questionanireViewList);
        }

        // GET: Questionnaire/Details/5
        public ActionResult Details(int id)
        {
            var questionnaire = Business.Instance.GetQuestionnaire(id);

            var questionnaireViewModel = new QuestionnaireViewModel { Id = questionnaire.Id, Name = questionnaire.Name, Campaign = questionnaire.Campaign };

            return View(questionnaireViewModel);
        }

        // GET: Questionnaire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questionnaire/Create
        [HttpPost]
        public ActionResult Create(QuestionnaireViewModel collection)
        {
            try
            {
                Business.Instance.CreateQuestionnaire(new Questionnaire
                {
                    Name = collection.Name,
                    Campaign = collection.Campaign,
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

        // GET: Questionnaire/Edit/5
        public ActionResult Edit(int id)
        {
            var questionnaire = Business.Instance.GetQuestionnaire(id);

            var questionnaireViewModel = new QuestionnaireViewModel { Id = questionnaire.Id, Name = questionnaire.Name, Campaign = questionnaire.Campaign };

            return View(questionnaireViewModel);
        }

        // POST: Questionnaire/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, QuestionnaireViewModel collection)
        {
            try
            {
                Business.Instance.UpdateQuestionnaire(new Questionnaire
                {
                    Id = id,
                    Name = collection.Name,
                    Campaign = collection.Campaign,
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

        // GET: Questionnaire/Delete/5
        public ActionResult Delete(int id)
        {
            var questionnaire = Business.Instance.GetQuestionnaire(id);

            var questionnaireViewModel = new QuestionnaireViewModel { Id = questionnaire.Id, Name = questionnaire.Name, Campaign = questionnaire.Campaign };

            return View(questionnaireViewModel);
        }

        // POST: Questionnaire/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Business.Instance.DeleteQuestionnaire(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
