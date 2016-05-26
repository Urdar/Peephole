using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peephole.Areas.Login
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Checking if user is logged in or not.
            string id = Request.QueryString["id"] as string;
            if (Session["USER_ID"] != null)
            {
                // Adding text to the label using some static text + the user id which is the users email.
                lblId.Text = id + "! You are logged in as " + string.Format(Session["USER_ID"].ToString()) + ". Enjoy you stay!";
            }
            else
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }
        }
    }
}