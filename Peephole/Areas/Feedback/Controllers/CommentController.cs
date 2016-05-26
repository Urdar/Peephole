using System.Web.Mvc;

namespace Peephole.Areas.Feedback.Controllers
{
    public class CommentController : Controller
    {
        public ActionResult Comments()
       { 

            return this.RazorView();

        }
    }
}

