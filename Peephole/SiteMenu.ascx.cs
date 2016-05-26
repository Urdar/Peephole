using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Helpers;
using FormsBootstrapMenuExample;
using Microsoft.AspNet.Identity;
using System.Web.Mvc.Html;

namespace Peephole
{
    public partial class SiteMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetMenuData();
            }
        }

        private void GetMenuData()
        {
            DataTable table = new DataTable();
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["PeepholeConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(strCon);
            string sql = "select id, ShowInMenu, Priority, LinkText, ParentId, URL from MainMenu WHERE ShowInMenu = 1 ORDER BY Priority ASC";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            DataView view = new DataView(table);
            view.RowFilter = "ParentId is NULL";
            foreach (DataRowView row in view)
            {
                MenuItem menuItem = new MenuItem(row["LinkText"].ToString(),
                row["id"].ToString());
                menuItem.NavigateUrl = row["URL"].ToString();
                BootstrapMenu1.Items.Add(menuItem);
                AddChildItems(table, menuItem);
            }
        }

        private void AddChildItems(DataTable table, MenuItem menuItem)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentId=" + menuItem.Value;
            foreach (DataRowView childView in viewItem)
            {
                MenuItem childItem = new MenuItem(childView["LinkText"].ToString(),
                childView["id"].ToString());
                childItem.NavigateUrl = childView["URL"].ToString();
                menuItem.ChildItems.Add(childItem);
                AddChildItems(table, childItem);
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}