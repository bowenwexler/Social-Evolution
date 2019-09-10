<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="BRDR_DB" %>
<asp:GridView ID="GridView1" runat="server"></asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="jumbotron">
        <h1>Totally Not HormoneBase</h1>
        <p class="lead">This is a test of ASP.NET</p>
        <p><a href="https://github.com/bowenwexler/Capstone-BRDR" class="btn btn-primary btn-lg">Check it out! &raquo;</a></p>
    </div>

</asp:Content>