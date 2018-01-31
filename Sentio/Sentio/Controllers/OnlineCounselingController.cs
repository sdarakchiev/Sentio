using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sentio.Controllers
{
    public class OnlineCounselingController : Controller
    {
        // GET: OnlineCounseling
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}