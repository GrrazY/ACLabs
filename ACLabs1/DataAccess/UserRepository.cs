using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        public ApplicationUser GetUser(String userId)
        {
            return dbContext.Users.Find(userId);
        }
    }
}
