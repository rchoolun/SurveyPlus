
    
using Asteck.SurveyPlus.Data;
              
public class WebpagesRolesRepository : Repository<webpages_Roles>, IWebpagesRolesRepository
{
    private Entities _context;

    public WebpagesRolesRepository(Entities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IWebpagesRolesRepository.cs file
}
