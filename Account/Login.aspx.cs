using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using BRDR_Capstone;
using System.Web.Security;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : System.Web.UI.Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

    protected void LogIn(object sender, AuthenticateEventArgs e)
    {

        bool auth = false;

        auth = authUser(UserName.Text, Password.Text);
        e.Authenticated = auth;

        FormsAuthentication.RedirectFromLoginPage(UserName.Text, true);
           
    }

    protected bool authUser(String username,String password)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\Capstone-BRDR\App_Data\IVSO.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("sp_select", con);
        cmd.CommandType = CommandType.StoredProcedure;

        string encrypt = FormsAuthentication.HashPasswordForStoringInConfigFile(UserName.Text, "SHA1");

        cmd.Parameters.AddWithValue("@username", UserName.Text);
        cmd.Parameters.AddWithValue("@password", encrypt);

        con.Open();

        int codereturn = (int)cmd.ExecuteScalar();

        return codereturn == 1;

        
    }
}