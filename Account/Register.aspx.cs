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


public partial class Account_Register : System.Web.UI.Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        var manager = new UserManager();
        var user = new ApplicationUser() {  UserName = UserName.Text };
        IdentityResult result = manager.Create(user, Password.Text);
        if (result.Succeeded)
        {
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
        else
        {
            ErrorMessage.Text = result.Errors.FirstOrDefault();
        }
    }

    protected void Register_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\Capstone-BRDR\App_Data\IVSO.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("sp_insert", con);
        cmd.CommandType = CommandType.StoredProcedure;

        //string encrypt = FormsAuthentication.HashPasswordForStoringInConfigFile(TextBox2.Text, "SHA1");

        cmd.Parameters.AddWithValue("fname", fName.Text);
        cmd.Parameters.AddWithValue("lname", lName.Text);
        cmd.Parameters.AddWithValue("email", eMail.Text);

        con.Open();
        int codereturn = (int)cmd.ExecuteScalar();
        if (codereturn == -1)
        {

            lblmsg.Text = "Username already exist!";
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    
}

/// <summary>
/// Sending_Mail class is purposed to instantiate a new mail host and send a formatted, plain text email message to the user-inputted
/// mailing address. All settings are formatted to specification needed.
/// </summary>
public partial class Sending_Mail : System.Web.UI.Page
{
    string sender = "utcbiomammalresearch@gmail.com";
    string mailPass = "bio4lyfe";
    string receive = "Loren-Hayes@utc.edu";

    /// <summary>
    /// Create_Message builds the message to be sent in the SendRegistration_Click method. It is designed separately from the sending action of class to create a more dynamic experience for the user. 
    /// </summary>
    /// <param name="user">User object to be inserted into the message in a specific format.</param>
    /// <param name="e"></param>
    protected void Create_Message(object user, EventArgs e)
    {
        string usrName = "";

        string usrPass = "password";

        MailMessage msg = new MailMessage(sender, receive);
        msg.Priority = MailPriority.High;
        msg.Subject = "SMRE Registration: " + 

    }
    
    /// <summary>
    /// SendingRegistration_Click takes the user input, compiles it into the hard-coded format, and send the message to the desired address.
    /// </summary>
    /// <param name="sender">Sender object used in the method.</param>
    /// <param name="e">Event Args 'e' are mandatory for maintaing listening events.</param>
    protected void SendRegistration_Click(object sender, EventArgs e)
    {
        SmtpClient nc = new SmtpClient("smtp.gmail.com",587); /// New client instantiated as an smtp client for GMail.
        nc.Host = ""; /// We set the host for the new client.
        nc.Port = 25;   /// Port for client set to 25, appropriate for an smtp client.
        nc.EnableSsl = true;    /// SSL is enabled for the client.
        nc.DeliveryMethod = SmtpDeliveryMethod.Network; ///Set the client delivery method to network delivery. 
        nc.UseDefaultCredentials = false;   /// Default user credentials are set to "false" for integrity and general security purposes.
        nc.Credentials = new NetworkCredential(mail, mailPass);     /// Set the credentials for the mail client.
        

    }
}