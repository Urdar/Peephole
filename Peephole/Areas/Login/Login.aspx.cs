using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace Peephole.Areas.Login
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {

            }
        }


        // MD5 Encryption
        public string encryption(String password)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(password);
            bs = x.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }


        // The register button. Redirecting to the register page.
        public void Message_click(object sender, EventArgs e)
        {
            Response.Redirect("/Areas/Login/Register.aspx");
        }

        // Login button click. 
        public void login_click(object sender, EventArgs e)
        {
            String email = TextBox1.Text.ToString();
            String password = TextBox2.Text;
            string con = ConfigurationManager.ConnectionStrings["PeepholeConnection"].ToString();
            SqlConnection connection = new SqlConnection(con);
            connection.Open();

            string passwords = encryption(password);

            // Query to select user information to the respective user trying to log in.
            String query = "SELECT Id, Email, Password FROM Users WHERE (Email = '" + email + "') AND (Password = '" + passwords + "');";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader sqldr = cmd.ExecuteReader();

            //Get Users ID (primary key)
            int recordsfound = 0;
            int userID = 0;
            while (sqldr.Read())
            {
                recordsfound++;
                userID = sqldr.GetInt32(0);

            }
            
            // Checking if user is found or not.
            if (recordsfound == 1)
            {
                //One unique account found
                Session["USER_PID"] = userID; // JV

                Session["USER_ID"] = TextBox1.Text; // PO

                // Redirecting to the welcome page.
                Response.Redirect("https://localhost:44301/areas/Login/Welcome?id=Hello");
            }
            else {
                Label1.Text = "Email or password is incorrect not found";

            }



            connection.Close();
        }
    }
}