                
using Asteck.SurveyPlus.Data;
              
public class ResultRepository : Repository<Result>, IResultRepository
{
    private Entities _context;

    public ResultRepository(Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IResultRepository.cs file
}
