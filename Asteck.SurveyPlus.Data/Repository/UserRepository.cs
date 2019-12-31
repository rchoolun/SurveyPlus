                
using Asteck.SurveyPlus.Data;
              
public class UserRepository : Repository<User>, IUserRepository
{
    private Entities _context;

    public UserRepository(Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IUserRepository.cs file
}
