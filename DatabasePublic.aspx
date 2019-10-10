<%@ Page Title="Public Database" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DatabasePublic.aspx.cs" CodeBehind="~/DatabasePublic.aspx.cs" Inherits="DatabasePublic" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Include jquery-ui script file. -->
    <script src="Scripts/jquery-ui-1.12.1.js" type="text/javascript"></script>

    <link href="Content/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />

    <!-- Include one of jTable styles. -->
    <link href="packages/jTable.2.4.0/content/Scripts/jtable/themes/lightcolor/blue/jtable.css" rel="stylesheet" type="text/css" />

    <!-- A helper library for JSON serialization -->
    <script type="text/javascript" src="/Scripts/jtable/external/json2.js"></script>
 
    <!-- Core jTable script file -->
    <script src="packages/jTable.2.4.0/content/Scripts/jtable/jquery.jtable.js" type="text/javascript"></script>

    <!-- ASP.NET Web Forms extension for jTable -->
    <script type="text/javascript" src="packages/jTable.2.4.0/content/Scripts/jtable/extensions/jquery.jtable.aspnetpagemethods.js"></script>

    <h2 class="text-center">Public Database</h2>
<%--    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Animal]"></asp:SqlDataSource>--%>
    <div id="AnimalTestContainer">
        
    </div>
    <script type="text/javascript">
 
        $(document).ready(function () {
 
            //Prepare jtable plugin
            $('#AnimalTestContainer').jtable({
                title: 'Testing JTable',
                actions: {
                    listAction: '/DatabasePublic.aspx/AnimalList',
                    createAction: '/PagingAndSorting.aspx/CreateStudent',
                    updateAction: '/PagingAndSorting.aspx/UpdateStudent',
                    deleteAction: '/PagingAndSorting.aspx/DeleteStudent'
                },
                fields: {
                    Animal_Id: {
                        key: true,
                        create: false,
                        edit: false,
                        width: '5%'
                    },
                    Genus_Species: {
                        title: 'Genus_Species',
                        width: '15%'
                    },
                    Common_Name: {
                        title: 'Common_Name',
                        width: '15%'
                    },
                    Subspecies: {
                        title: 'Subspecies',
                        width: '15%'
                    },
                    Population: {
                        title: 'Population',
                        width: '40%',
                    },
                    Continent: {
                        title: 'Continent',
                        width: '10%'
                    }
                }
            });
 
            //Load animal list from server
            $('#AnimalTestContainer').jtable('load');
        });
    </script>
</asp:Content>