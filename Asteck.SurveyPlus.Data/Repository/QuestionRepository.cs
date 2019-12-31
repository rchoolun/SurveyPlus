                
using Asteck.SurveyPlus.Data;
              
public class QuestionRepository : Repository<Question>, IQuestionRepository
{
    private Entities _context;

    public QuestionRepository(Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IQuestionRepository.cs file
}
