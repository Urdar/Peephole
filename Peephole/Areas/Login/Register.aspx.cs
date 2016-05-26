using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peephole.Areas.Login
{
    public partial class CheckEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Method to encrypt the password in MD5
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

        // Method to check if user exists.
        protected void Buttonchekexistance_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text.ToString();
            String password = TextBox2.Text;
            String name = TextBoxName.Text.ToString();
            String lastname = TextBoxLastName.Text.ToString();
            //Get the encrypt the password by using the class  
            string pass = encryption(password);
            Label1.Text = pass;
            //Check whether the UseName and password are Empty  
            if (email.Length > 0 && password.Length > 0 && name.Length > 0 && lastname.Length > 0)
            {
                //creating the connection string              
                string connection = ConfigurationManager.ConnectionStrings["PeepholeConnection"].ToString();
                SqlConnection con = new SqlConnection(connection);
                String passwords = encryption(password);
                con.Open();
                // Check whether the Username is Found in the Existing DB  
                String search = "SELECT * FROM Users WHERE (Email = '" + email + "');";
                SqlCommand cmds = new SqlCommand(search, con);
                SqlDataReader sqldrs = cmds.ExecuteReader();
                if (sqldrs.Read())
                {
                    String passed = (string)sqldrs["Password"];
                    Label1.Text = "Email Already Taken";
                }
                else
                {
                    try
                    {
                        // if the Username not found create the new user accound  
                        string sql = "INSERT INTO Users (UserType, Email, Password, Firstname, Lastname) VALUES (2,'" + email + "','" + passwords + "','" + name + "','" + lastname + "');";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        String Message = "saved Successfully";
                        Label1.Text = Message.ToString();
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        Response.Redirect("/Areas/Login/Welcome?id=username");
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = ex.ToString();
                    }
                    con.Close();
                }
            }

            else
            {
                String Message = "Fields can not be empty";
                Label1.Text = Message.ToString();
            }
        }
    }
}