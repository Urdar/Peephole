using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peephole.Areas._MVCTemplate.Controllers
{
    public class MVCTemplateController : Controller
    {
        // GET: MVCTemplate/MVCTemplate
        public ActionResult Index()
        {
            ViewBag._Title = "MVC Template";
            //The line below is the one that's changed from the original Area
            return this.RazorView();
        }

        /* This is the method that reset the database, if you want to use it. Delete if unnecessary. 
    protected void ButtonResetDatabase(object sender, EventArgs e)
        {
            var connString = WebConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
            

            using (var conn = new SqlConnection(connString))
            {
                using (var command = new SqlCommand("StoredProcedureName", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        */

    }
}