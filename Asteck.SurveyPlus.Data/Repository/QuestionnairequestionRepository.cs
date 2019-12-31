                
using Asteck.SurveyPlus.Data;
              
public class QuestionnairequestionRepository : Repository<QuestionnaireQuestion>, IQuestionnairequestionRepository
{
    private Entities _context;

    public QuestionnairequestionRepository(Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IQuestionnairequestionRepository.cs file
}
