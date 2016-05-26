using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peephole.Areas.SQLIinjection
{
    public partial class SQL : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Set error text to empty
            this.errorLabel.Text = "";
            this.errorLabelSol.Text = "";
        }

        //Shows all employees
        protected void ButtonShowAllClick(object sender, EventArgs e)
        {
            var sqlString = "SELECT * FROM Users WHERE UserType = 1";
            var connString = WebConfigurationManager.ConnectionStrings["PeepholeConnection"].ConnectionString;
            //Connects to the database
            using (var conn = new SqlConnection(connString))
            {
                var command = new SqlCommand(sqlString, conn);
                command.Connection.Open();
                //Insert data to form
                userInfo.DataSource = command.ExecuteReader();
                userInfo.DataBind();
            }
        }

        // USED THIS STATEMENT TO INSERT SECRET TO LASTNAME : 1;update employee set email = password
        // '));Update Users set FirstName = Password;--
        //Serachable method
        protected void ButtonSubmitClick(object sender, EventArgs e)
        {
            var ID = input.Text;
            //If input is empty, don't crash application
            if (ID == "")
            {
                ButtonShowAllClick(sender, e);
            }
            else {
                try
                {
                    
                    var sqlString = "SELECT * FROM Users WHERE ((FirstName LIKE '%" + ID + "%') OR (LastName LIKE '%" + ID + "%')) AND UserType = 1";
       
                    var connString = WebConfigurationManager.ConnectionStrings["PeepholeConnection"].ConnectionString;
                    //Connection to database
                    using (var conn = new SqlConnection(connString))
                    {

                        var command = new SqlCommand(sqlString, conn);
                        command.Connection.Open();
                        //Binds data to form
                        userInfo.DataSource = command.ExecuteReader();
                        userInfo.DataBind();
                    }
                }
                catch (Exception ex)
                {   //If input is empty or unvalid, don't crash application
                    this.errorLabel.ForeColor = System.Drawing.Color.Red;
                    this.errorLabel.Text = ex.ToString();
                }
            }
        }


        /* ------------------------------------- START SOLUTION ------------------------------------- */

        protected void ButtonSubmitClickSolution(object sender, EventArgs e)
        {
            var ID = input.Text;
            if (ID == "")
            {
               
                this.errorLabelSol.ForeColor = System.Drawing.Color.Red;
                this.errorLabelSol.Text = "Invalid user ID is entered";

            }



            else {
                //If input is OK, shows info for that input
                System.Diagnostics.Debug.WriteLine(ID);
                var sqlString = "SELECT * FROM Users WHERE ((FirstName LIKE '%@ID%') OR (LastName LIKE '%@ID%')) AND UserType = 1";
                var connString = WebConfigurationManager.ConnectionStrings["PeepholeConnection"].ConnectionString;
                //Connection
                using (var conn = new SqlConnection(connString))
                {
                    var command = new SqlCommand(sqlString, conn);
                    command.Parameters.AddWithValue("@Id", ID);
                    command.Connection.Open();
                    //Binds data to form
                    userInfoSolution.DataSource = command.ExecuteReader();
                    userInfoSolution.DataBind();
                }
            }
        }

        /* ------------------------------------- END SOLUTION ------------------------------------- */

        protected void ButtonResetDatabase(object sender, EventArgs e)
        {
            var connString = WebConfigurationManager.ConnectionStrings["PeepholeConnection"].ConnectionString;


            using (var conn = new SqlConnection(connString))
            { //Run SP in database
                using (var command = new SqlCommand("ResetTableUsers", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
            //Reload page
            Response.Redirect("/Areas/Employee/Search");
        }
    }
}
