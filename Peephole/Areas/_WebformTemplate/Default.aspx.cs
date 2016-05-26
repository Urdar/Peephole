using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peephole.Views.Shared
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
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
