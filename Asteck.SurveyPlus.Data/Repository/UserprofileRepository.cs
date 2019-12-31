                
using Asteck.SurveyPlus.Data;
              
public class UserprofileRepository : Repository<UserProfile>, IUserprofileRepository
{
    private Entities _context;

    public UserprofileRepository(Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IUserprofileRepository.cs file
}
