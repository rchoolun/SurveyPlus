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
        public IEnumerable<Answer> GetAllAnswers()
        {
            var unitOfWork = new UnitOfWork();

            var answer = unitOfWork.Answers.GetAll()
                        .Select(x => new Answer
                        {
                            Id = x.Id,
                            Title = x.Title,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            UpdatedBy = x.UpdatedBy,
                            UpdatedOn = x.UpdatedOn,
                        });

            return answer;
        }

        /// <summary>
        /// Get a single question by ID
        /// </summary>
        /// <returns></returns>
        public Answer GetAnswer(int id)
        {
            var unitOfWork = new UnitOfWork();

            var answerData = unitOfWork.Answers.GetById(id);

            var answer = new Answer
            {
                Id = answerData.Id,
                Title = answerData.Title,
                CreatedBy = answerData.CreatedBy,
                CreatedOn = answerData.CreatedOn,
                UpdatedBy = answerData.UpdatedBy,
                UpdatedOn = answerData.UpdatedOn,
            };

            return answer;
        }

        /// <summary>
        /// Creates a new questionnaire
        /// </summary>
        /// <param name="questionnaire"></param>
        public void CreateAnswer(Answer answer)
        {
            if (answer == null)
            {
                throw new ArgumentNullException("CreateAnswer parameter is null");
            }

            var unitOfWork = new UnitOfWork();

            //Transform to data entity
            var newAnswer = new Data.Answer()
            {
                Title = answer.Title,
                CreatedOn = answer.CreatedOn,
                CreatedBy = answer.CreatedBy
            };

            unitOfWork.Answers.Add(newAnswer);
            unitOfWork.Save();

        }

        /// <summary>
        /// Updates an existing question
        /// </summary>
        /// <param name="questionnaire"></param>
        public void UpdateAnswer(Answer answer)
        {
            if (answer == null)
            {
                throw new ArgumentNullException("UpdateQuestion parameter is null");
            }

            var unitOfWork = new UnitOfWork();

            var questionData = unitOfWork.Answers.GetById(answer.Id);
            questionData.Title = answer.Title;
            questionData.UpdatedBy = answer.UpdatedBy;
            questionData.UpdatedOn = answer.UpdatedOn;

            unitOfWork.Save();

        }

        /// <summary>
        /// Deletes a question
        /// </summary>
        /// <param name="questionnaire"></param>
        public void DeleteAnswer(int id)
        {
            var unitOfWork = new UnitOfWork();

            var answerData = unitOfWork.Answers.GetById(id);

            unitOfWork.Answers.Delete(answerData);
            unitOfWork.Save();

        }
    }
}
