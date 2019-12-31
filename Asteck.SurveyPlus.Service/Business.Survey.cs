using Asteck.SurveyPlus.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteck.SurveyPlus.Service
{
    public partial class Business
    {
        public Questionnaire GetSurvey(int id)
        {
            var unitOfWork = new UnitOfWork();

            var questionnaire = unitOfWork.Questionnaires.GetById(id);

            Questionnaire questionaireService = new Questionnaire
            {
                Id = questionnaire.Id,
                Name = questionnaire.Name,
                CreatedOn = questionnaire.CreatedOn,
                CreatedBy = questionnaire.CreatedBy,
                UpdatedBy = questionnaire.UpdatedBy,
                UpdatedOn = questionnaire.UpdatedOn
            };


            var questionServiceList = new List<Question>();

            foreach(var q in questionnaire.QuestionnaireQuestions)
            {
                var question = new Question
                {
                    Id = q.Question.Id,
                    Title = q.Question.Title,
                    UpdatedBy = q.Question.UpdatedBy,
                    UpdatedOn = q.Question.UpdatedOn,
                    CreatedBy = q.Question.CreatedBy,
                    CreatedOn = q.Question.CreatedOn
                };


                var answerServiceList = new List<Answer>();

                foreach (var a in q.Question.QuestionAnswers)
                {
                    var answer = new Answer
                    {
                        Id = a.AnswerId,
                        Title = a.Answer.Title,
                        UpdatedBy = a.Answer.UpdatedBy,
                        UpdatedOn = a.Answer.UpdatedOn,
                        CreatedBy = a.Answer.CreatedBy,
                        CreatedOn = a.Answer.CreatedOn
                    };

                    answerServiceList.Add(answer);
                }

                question.Answers = answerServiceList;


                questionServiceList.Add(question);
            }

            questionaireService.Questions = questionServiceList;

            return questionaireService;

        }
    }
}
