                
using Asteck.SurveyPlus.Data;
              
public class QuestionnaireRepository : Repository<Questionnaire>, IQuestionnaireRepository
{
    private Entities _context;

    public QuestionnaireRepository(Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IQuestionnaireRepository.cs file
}
