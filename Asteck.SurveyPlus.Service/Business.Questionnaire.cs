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
        /// Gets all the questionnaire that is found in the DB
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Questionnaire> GetAllQuestionnaire()
        {
            var unitOfWork = new UnitOfWork();

            var questionnaire = unitOfWork.Questionnaires.GetAll()
                        .Select(x => new Questionnaire
                        {
                            Id = x.Id,
                            Campaign = x.Campaign,
                            Name = x.Name,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            UpdatedBy = x.UpdatedBy,
                            UpdatedOn = x.UpdatedOn,
                        });

            return questionnaire;
        }

        /// Gets all the questionnaire that is found in the DB
        /// </summary>
        /// <returns></returns>
        public Questionnaire GetQuestionnaire(int id)
        {
            var unitOfWork = new UnitOfWork();

            var questionnaire = unitOfWork.Questionnaires.GetById(id);

            return new Questionnaire
            {
                Id = questionnaire.Id,
                Campaign = questionnaire.Campaign,
                Name = questionnaire.Name,
                CreatedBy = questionnaire.CreatedBy,
                CreatedOn = questionnaire.CreatedOn,
                UpdatedBy = questionnaire.UpdatedBy,
                UpdatedOn = questionnaire.UpdatedOn,
            };
        }

        /// <summary>
        /// Creates a new questionnaire
        /// </summary>
        /// <param name="questionnaire"></param>
        public void CreateQuestionnaire(Questionnaire questionnaire)
        {
            if(questionnaire == null)
            {
                throw new ArgumentNullException("CreateQuestionnaire parameter is null");
            }

            var unitOfWork = new UnitOfWork();

            //Transform to data entity
            var newQuestionnaire = new Data.Questionnaire() {
                Name = questionnaire.Name,
                Campaign = questionnaire.Campaign,
                CreatedOn = questionnaire.CreatedOn,
                CreatedBy = questionnaire.CreatedBy };

            unitOfWork.Questionnaires.Add(newQuestionnaire);
            unitOfWork.Save();

        }

        /// <summary>
        /// Updates a new questionnaire
        /// </summary>
        /// <param name="questionnaire"></param>
        public void UpdateQuestionnaire(Questionnaire questionnaire)
        {
            if (questionnaire == null)
            {
                throw new ArgumentNullException("UpdateQuestionnaire parameter is null");
            }

            var unitOfWork = new UnitOfWork();

            var questionnaireData = unitOfWork.Questionnaires.GetById(questionnaire.Id);
            questionnaireData.Name = questionnaire.Name;
            questionnaireData.Campaign = questionnaire.Campaign;
            questionnaireData.UpdatedBy = questionnaire.UpdatedBy;
            questionnaireData.UpdatedOn = questionnaire.UpdatedOn;

            unitOfWork.Save();

        }

        /// <summary>
        /// Deletes a questionnaire
        /// </summary>
        /// <param name="questionnaire"></param>
        public void DeleteQuestionnaire(int id)
        {
            var unitOfWork = new UnitOfWork();

            var questionnaireData = unitOfWork.Questionnaires.GetById(id);

            unitOfWork.Questionnaires.Delete(questionnaireData);
            unitOfWork.Save();

        }
    }
}
