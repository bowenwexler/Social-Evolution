<%@ Page Title="Public Database" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DatabasePublic.aspx.cs" CodeBehind="~/DatabasePublic.aspx.cs" Inherits="DatabasePublic" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />

    <!-- Include one of jTable styles. -->
    <link href="Scripts/jtable/themes/metro/blue/jtable.css" rel="stylesheet" type="text/css" />

    <!-- Include jquery-ui script file. -->
    <script src="Scripts/jquery-ui-1.12.1.js" type="text/javascript"></script>

    <!-- A helper library for JSON serialization -->
    <script src="Scripts/jtable/external/json2.js"></script>
 
    <!-- Core jTable script file -->
    <script src="Scripts/jtable/jquery.jtable.js"></script>

    <!-- ASP.NET Web Forms extension for jTable -->
    <script src="Scripts/jtable/extensions/jquery.jtable.aspnetpagemethods.js"></script>

    <h2 class="text-center">Public Database</h2>
    <div id="AnimalTestContainer"></div>
    <script type="text/javascript">
 
        $(document).ready(function () {
 
            //Prepare jtable plugin
            $('#AnimalTestContainer').jtable({
                title: 'Testing JTable',
                actions: {
                    listAction: 'DatabasePublic.aspx/AnimalList',
                    createAction: 'DatabasePublic.aspx/CreateAnimal',
                    updateAction: 'DatabasePublic.aspx/EditAnimal',
                    deleteAction: 'DatabasePublic.aspx/DeleteAnimal'
                },
                fields: {
                    Animal_Id: {
                        key: true,
                        list: false
                    },
                    Genus_Species: {
                        title: 'Genus_Species',
                        width: '25%'
                    },
                    Common_Name: {
                        title: 'Common_Name',
                        width: '25%'
                    },
                    Subspecies: {
                        title: 'Subspecies',
                        width: '20%'
                    },
                    Population: {
                        title: 'Population',
                        width: '10%',
                    },
                    Continent: {
                        title: 'Continent',
                        width: '20%'
                    }
                }
            });
 
            //Load animal list from server
            $('#AnimalTestContainer').jtable('load');
        });
    </script>
</asp:Content>