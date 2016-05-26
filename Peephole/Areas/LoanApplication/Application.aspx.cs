using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;



namespace Peephole.Areas.LoanApplication
{
    public partial class Upload : System.Web.UI.Page
    {
        // Initializing variables
        string strCon = ConfigurationManager.ConnectionStrings["PeepholeConnection"].ConnectionString;
        SqlDataAdapter SqlAda;
        DataSet ds;

        // Happens at page load 
        protected void Page_Load(object sender, EventArgs e)
        {
            // Checking that the user is logged in or not.
            if (Session["USER_PID"] == null)
            {
                // If user is not logged in, redirect to Login.
                Response.Redirect("/Areas/Login/Login.aspx");
            }

            if (!IsPostBack)
            {
                //Display complete uploaded file details in gridview
                LoadData();
            }
        }

        // Loading data from database 
        private void LoadData()
        {
            try {
                using (SqlConnection Sqlcon = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        Sqlcon.Open();
                        cmd.Connection = Sqlcon;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_FileUpload";
                        cmd.Parameters.Add(new SqlParameter("@pvchAction", SqlDbType.VarChar, 50));
                        cmd.Parameters["@pvchAction"].Value = "select";
                        cmd.Parameters.Add("@pIntErrDescOut", SqlDbType.Int).Direction = ParameterDirection.Output;
                        SqlAda = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        SqlAda.Fill(ds);
                        GridViewUploadedFile.DataSource = ds;
                        GridViewUploadedFile.DataBind();
                    }
                }
            }
            catch(System.ArgumentException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
            }
            }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Get path from web.config file to upload
            string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
            bool blSucces = false;
            string filename = string.Empty;
            //To check whether file is selected or not to uplaod
            if (LoanApplicationToServer.HasFile)
            {
                try
                {
                    
                    //TIP: Try restricting file formats that are allowed.
                    string FileExt = System.IO.Path.GetExtension(LoanApplicationToServer.PostedFile.FileName);
                    
                   
                        // Get size of uploaded file, here we could have restricted file size.
                        int FileSize = LoanApplicationToServer.PostedFile.ContentLength;
                       
                            //Get file name of selected file
                            filename = Path.GetFileName(LoanApplicationToServer.FileName);
                            //Save selected file into specified location
                            LoanApplicationToServer.SaveAs(Server.MapPath(FilePath) + filename);
                            lblMsg.Text = "We have received your application!";
                            blSucces = true;
                       

                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Error occurred while uploading a file: " + ex.Message;
                }
            }
            else
            {
                lblMsg.Text = "Please select a file to upload.";
            }
            //Store file details into database
            if (blSucces)
            {
                Updatefileinfo(filename, FilePath + filename);
            }
        }
        private void Updatefileinfo(string strfilename, string strPath)
        {
            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        Sqlcon.Open();
                        cmd.Connection = Sqlcon;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_FileUpload";
                        cmd.Parameters.Add(new SqlParameter("@pvchAction", SqlDbType.VarChar, 50));
                        cmd.Parameters.Add(new SqlParameter("@pvchFileName", SqlDbType.VarChar, 100));
                        cmd.Parameters.Add(new SqlParameter("@pvchFilepath", SqlDbType.VarChar, 100));
                        cmd.Parameters.Add(new SqlParameter("@pvchCreatedBy", SqlDbType.VarChar, 100));
                        cmd.Parameters.Add("@pIntErrDescOut", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters["@pvchAction"].Value = "insert";
                        cmd.Parameters["@pvchFileName"].Value = strfilename;
                        cmd.Parameters["@pvchFilepath"].Value = strPath;
                        cmd.Parameters["@pvchCreatedBy"].Value = "Admin";
                        cmd.ExecuteNonQuery();
                        int retVal = (int)cmd.Parameters["@pIntErrDescOut"].Value;
                    }
                }
                //Display complete uploaded file details in gridview
                LoadData();
            }
            catch (System.ArgumentException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
            }
        }

        protected void GridViewUploadedFile_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewUploadedFile.PageIndex = e.NewPageIndex;
            LoadData();
        }

    }
}