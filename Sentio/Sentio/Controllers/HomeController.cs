using Microsoft.AspNet.Identity.EntityFramework;
using Sentio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sentio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationUserManager userManager;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationUserManager userManager, ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            this.dbContext.Roles.Add(new IdentityRole() { Name = "Admin" });
             this.dbContext.SaveChanges();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}