using BusinessLogic;
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
        MinesService ms;

        public MinesController()
        {
           ms = new MinesService();
        }

        // GET: Mines
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var city = ms.UpdateResources(userId);
            return View(city);
        }

        /*
        public ActionResult Details(int mineId)
        {
            var mine = mr.GetMine(mineId);
            return View(mine);
        }

        [HttpPost]
        public ActionResult Upgrade(int mineId, bool fastUpgrade)
        {
            var mine = this.dbContext.Mines.Find(mineId);
            var city = mine.City;
            var needed = mine.GetUpgradeRequirements();
            var have = city.Resources;

            if(fastUpgrade)
            {
                needed = needed.Select(n => (amount: n.amount * 10, type: n.type)).ToArray();
            }
            var r = needed.Join(have, n => n.type, h => h.Type, (n, h) => (needed: n, have: h));

            if(!r.All(_=> _.needed.amount < _.have.Value))
            {
                return View(new Models.MessageViewModel
                {
                    Message = $"You do not have enough resources"
                });
            }

            foreach (var item in r)
            {
                item.have.Value -= item.needed.amount;
            }

            mine.Level++;
            mine.UpgradeCompletesAt = DateTime.Now.AddHours(0.5 * mine.Level);
            this.dbContext.SaveChanges();

            return View(new Models.MessageViewModel
            {
                Message = $"Upgrade Successfull"
            });
        }
        */
    }
}