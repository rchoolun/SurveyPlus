                
using Asteck.SurveyPlus.Data;
              
public class AnswerRepository : Repository<Answer>, IAnswerRepository
{
    private Entities _context;

    public AnswerRepository(Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IAnswerRepository.cs file
}
