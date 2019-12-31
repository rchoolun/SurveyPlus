using Asteck.SurveyPlus.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteck.SurveyPlus.Service
{
    public partial class Business
    {
        public List<User> GetAllUser()
        {
            var unitOfWork = new UnitOfWork();

            var user = unitOfWork.Users.GetAll()
                        .Select(x => new User
                        {
                            Id = x.Id,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            Password = x.Password,
                            HashPassword = x.HashPassword,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            UpdatedBy = x.UpdatedBy,
                            UpdatedOn = x.UpdatedOn,
                            IsAdmin = x.IsAdmin
                        });

            return user.ToList();
        }
    }
}
