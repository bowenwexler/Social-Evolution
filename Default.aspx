<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="overflow: auto">
        <h1 class="text-center" style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; font-size: x-large;">[Insert Logo Image Here]</h1>
        <hr style="visibility:visible"/>
        <br />
        <p class="text-right" style="text-align: justify; font-size: medium;">Welcome to [insert name here]! Here a community of biologists come to together to compile a one-of-a-kind database! This database catalogs several often overlooked statistics about mammal social habits extracted from hundreds of different studies.</p>
        <br />
        <div style=" margin-bottom:1em; overflow:auto">
            <div style="float:left; width: 50%; text-align: center">
                <a href="About.aspx">
                    <h3 style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">Database</h3>
                    <img style="width:90%"; src="Content/TestImages/kotnews.jpg"/>
                </a>
                <p style="width:90%; margin-top:20px; font-size: small;">Browse our constantly-updating database free of charge!</p>
            </div>
            <div style="float:right; width: 50%; text-align: center">
                <a href="About.aspx">
                    <h3 style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">Contribute</h3>
                    <img style="width:90%"; src="Content/TestImages/kotnews.jpg"/>
                </a>
                <p style="width:90%; margin-top:20px; font-size: small;">Here you can see the process that you must undergo to contribute to the database.</p>
            </div>
        </div>
        <div style="width: 100%">
            <div style="text-align: center">
                <a href="About.aspx">
                    <h3 style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">About</h3>
                    <img style="width:50%"; src="Content/TestImages/kotnews.jpg"/>
                </a>
                <p style="margin-top:20px; font-size: small;">We're a dedicated team of biologists from around the globe working in conjunction for a common goal. Our studies involve...</p>
            </div>
        </div>
    </div>
</asp:Content>