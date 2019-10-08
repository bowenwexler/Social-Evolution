<%@ Page Title="Public Database" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DatabasePublic.aspx.cs" Inherits="DatabasePublic" %>

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
    <div id="AnimalTestContainer"></div>
    <script type="text/javascript">
 
        $(document).ready(function () {
 
            //Prepare jtable plugin
            $('#AnimalTestContainer').jtable({
                title: 'Testing JTable',
                paging: true, //Enables paging
                pageSize: 10, //Actually this is not needed since default value is 10.
                sorting: true, //Enables sorting
                defaultSorting: 'Name ASC', //Optional. Default sorting on first load.
                actions: {
                    listAction: '/DatabasePublic.aspx/StudentList',
                    createAction: '/DatabasePublic.aspx/CreateStudent',
                    updateAction: '/DatabasePublic.aspx/UpdateStudent',
                    deleteAction: '/DatabasePublic.aspx/DeleteStudent'
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
 
            //Load student list from server
            //$('#AnimalTestContainer').jtable('load');
        });
    </script>
</asp:Content>