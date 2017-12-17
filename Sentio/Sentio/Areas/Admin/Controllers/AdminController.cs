using Sentio.Areas.Admin.Models;
using Sentio.Areas.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sentio.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationUserManager userManager;
        private readonly IAdminServices adminService;

        public AdminController(ApplicationUserManager userManager)
        {
            this.userManager = userManager;
        }
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ArticleViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                this.adminService.AddArticle(viewModel.Author, viewModel.Title, viewModel.Content);

                return this.RedirectToAction("Index");
            }

            return this.View(viewModel);
        }
    }
}