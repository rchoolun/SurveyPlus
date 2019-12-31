                
using Asteck.SurveyPlus.Data;
              
public class UserquestionnaireRepository : Repository<UserQuestionnaire>, IUserquestionnaireRepository
{
    private Entities _context;

    public UserquestionnaireRepository(Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IUserquestionnaireRepository.cs file
}
