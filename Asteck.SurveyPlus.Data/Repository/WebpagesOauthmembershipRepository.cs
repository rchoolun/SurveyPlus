                
using Asteck.SurveyPlus.Data;
              
public class WebpagesOauthmembershipRepository : Repository<webpages_OAuthMembership>, IWebpagesOauthmembershipRepository
{
    private Entities _context;

    public WebpagesOauthmembershipRepository(Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IWebpagesOauthmembershipRepository.cs file
}
