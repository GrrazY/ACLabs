using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MinesRepository : IMinesRepository
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        public Mine GetMine(int mineId)
        {
            return dbContext.Mines.Find(mineId);
        }

        public void UpdateResources()
        {
            dbContext.SaveChanges();
        }
    }
}
