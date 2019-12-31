                
using Asteck.SurveyPlus.Data;
              
public class WebpagesMembershipRepository : Repository<webpages_Membership>, IWebpagesMembershipRepository
{
    private Entities _context;

    public WebpagesMembershipRepository(Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IWebpagesMembershipRepository.cs file
}
