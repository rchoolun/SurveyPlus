                
using Asteck.SurveyPlus.Data;
              
public class QuestionanswerRepository : Repository<QuestionAnswer>, IQuestionanswerRepository
{
    private Entities _context;

    public QuestionanswerRepository(Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IQuestionanswerRepository.cs file
}
