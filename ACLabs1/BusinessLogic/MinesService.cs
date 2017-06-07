using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MinesService
    {
        MinesRepository mr;
        UserRepository ur;

        public MinesService()
        {
            mr = new MinesRepository();
            ur = new UserRepository();
        }

        public City UpdateResources(String userId)
        {
            var start = DateTime.Now;
            var city = ur.GetUser(userId).Cities.First();
            foreach (var res in city.Resources)
            {
                foreach (var mine in city.Mines)
                {
                    if (mine.Type == res.Type)
                    {
                        res.Value += mine.GetProductionPerHour() * (start - res.LastUpdate).TotalHours;
                    }
                }
                res.LastUpdate = start;
            }
            mr.UpdateResources();

            return city;
        }
    }
}
