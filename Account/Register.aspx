<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <h4>Account Registration Information and Contact</h4>
            <div class="form-group">
                <h5>User Name and Password Granting</h5>
                <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="fName" CssClass="col-md-2 control-label">First Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="fName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="fName" CssClass="text-danger" ErrorMessage="" />
                        </div>
                    </div>
                 <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="lName" CssClass="col-md-2 control-label">Last Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="lName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="lName" CssClass="text-danger" ErrorMessage="" />
                        </div>
                    </div>
                 <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="eMail" CssClass="col-md-2 control-label">E-Mail Address</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="eMail" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="eMail" CssClass="text-danger" ErrorMessage="" />
                        </div>
                    </div>
                <p></p>
            </div>
            <div class="form-group">
                <h5>Contact time</h5>
                <p>To receive your official username and password for access or administration, the maximum wait time is 3 to 5 academic working days.
                </p>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

