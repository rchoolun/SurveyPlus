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
        /// <summary>
        /// Gets all the questions that is found in the DB
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Question> GetAllQuestions()
        {
            var unitOfWork = new UnitOfWork();

            var questions = unitOfWork.Questions.GetAll()
                        .Select(x => new Question
                        {
                            Id = x.Id,
                            Title = x.Title,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            UpdatedBy = x.UpdatedBy,
                            UpdatedOn = x.UpdatedOn,
                        });

            return questions;
        }

        /// <summary>
        /// Get a single question by ID
        /// </summary>
        /// <returns></returns>
        public Question GetQuestion(int id)
        {
            var unitOfWork = new UnitOfWork();

            var questionData = unitOfWork.Questions.GetById(id);

            var question = new Question
                           {
                                Id = questionData.Id,
                                Title = questionData.Title,
                                CreatedBy = questionData.CreatedBy,
                                CreatedOn = questionData.CreatedOn,
                                UpdatedBy = questionData.UpdatedBy,
                                UpdatedOn = questionData.UpdatedOn,
                            };

            return question;
        }

        /// <summary>
        /// Creates a new questionnaire
        /// </summary>
        /// <param name="questionnaire"></param>
        public void CreateQuestion(Question questionn)
        {
            if (questionn == null)
            {
                throw new ArgumentNullException("CreateQuestion parameter is null");
            }

            var unitOfWork = new UnitOfWork();

            //Transform to data entity
            var newQuestion = new Data.Question()
            {
                Title = questionn.Title,
                CreatedOn = questionn.CreatedOn,
                CreatedBy = questionn.CreatedBy
            };

            unitOfWork.Questions.Add(newQuestion);
            unitOfWork.Save();

        }

        /// <summary>
        /// Updates an existing question
        /// </summary>
        /// <param name="questionnaire"></param>
        public void UpdateQuestion(Question question)
        {
            if (question == null)
            {
                throw new ArgumentNullException("UpdateQuestion parameter is null");
            }

            var unitOfWork = new UnitOfWork();

            var questionData = unitOfWork.Questions.GetById(question.Id);
            questionData.Title = question.Title;
            questionData.UpdatedBy = question.UpdatedBy;
            questionData.UpdatedOn = question.UpdatedOn;

            unitOfWork.Save();

        }

        /// <summary>
        /// Deletes a question
        /// </summary>
        /// <param name="questionnaire"></param>
        public void DeleteQuestion(int id)
        {
            var unitOfWork = new UnitOfWork();

            var questionData = unitOfWork.Questions.GetById(id);

            unitOfWork.Questions.Delete(questionData);
            unitOfWork.Save();

        }
    }
}
