using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeTravian.Controllers
{
    [Authorize]
    public class MinesController : Controller
    {
        Models.ApplicationDbContext dbContext = new Models.ApplicationDbContext();

        // GET: Mines
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var user = dbContext.Users.Find(userId);
            var city = user.Cities.First();
            this.UpdateResources(city);
            return View(city);
        }

        public ActionResult Details(int mineId)
        {
            var mine = dbContext.Mines.Find(mineId);
            return View(mine);
        }

        private void UpdateResources(FakeTravian.Models.City city)
        {
            var start = DateTime.Now;
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
            dbContext.SaveChanges();
        }
    }
}