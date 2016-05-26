using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peephole.Areas.Redirect.Controllers
{
    public class RedirectController : Controller
    {
        // GET: Redirect/Redirect
        public ActionResult Index()
        {
            ViewBag._Title = "Redirect";
            return this.RazorView();
        }


        public ActionResult Trusted()
        {
            ViewBag._Title = "Trusted site";
            return this.RazorView();
        }

        public ActionResult Redirect()
        {
            ViewBag._Title = "Trusted site";
            return this.RazorView();
        }

        public ActionResult unTrusted()
        {
            ViewBag._Title = "Untrusted site";
            return this.RazorView();
        }
    }
}