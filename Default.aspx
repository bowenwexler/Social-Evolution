<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="overflow: auto">
        <h1 class="text-center" style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; font-size: x-large; height:200px;"> <img src="Content/Images/TempLogo.jpg" height="200" width="500"></h1>
        <hr style="visibility:visible"/>
        <br />
        <p class="text-right" style="text-align: justify; font-size: medium;">Welcome to Mammalian Social Evolution. Our aim is to study and understand Interspecific variation in social organizations (IVSO) amongst different kinds of speciies.
         Our database consists of various measures that affect the social behaviour of various species of mammals. Mammalian Social Evolution is developed by an enthusiastic team of biologists
         and CS students. It is a freely available database to the biological community and our aim is to gather as much data and information on various factors that affect the social behaviour of mammals in order to better understand evolution in these species.   
        </p>
        <br />
        <div style=" margin-bottom:1em; overflow:auto">
            <div style="float:left; width: 50%; text-align: center;" >
                <a href="DatabasePublic.aspx">
                <h3 style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">Database</h3>
                <img class="sticky" style="width:90%; height:200px" ; src="Content/Images/Database.jpg"/>
	            </a>
                <p style="width:80%; margin-top:20px; font-size: small; text-align: justify;margin-left:40px">Our database specifies key factors to obtain valuable information regarding interspecies mating and living conditions. These include Time of year, age, location, sexual dimorphism, population, precipitation, temprature, mating habits and several other factors.
                Our database aims to give coherent and up to date information to those searching for causality in social changes amongst mammals.
                </p>
            </div> 
            
            <div style="float:right; width: 50%; text-align: center;"  >
                <a href="Contact.aspx">
                <h3 style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">Contribute</h3>
                <img class="sticky" style="width:90%; height:200px"; src="Content/Images/Picture 077 (1).jpg"/>
		        </a>
                <p style="width:90%; margin-top:20px; font-size: small; text-align: justify;margin-left:30px">Here you can see the process that you must undergo to contribute to the database.Contribute valuable data to our database to help us in our quest to better understand social behaviour of mammals and how their evolution is affected by climate change. Sign up here and one of team members will reach out to you very soon. Or login here.</p>
            </div>
        </div>
            <div  style="width: 100%; text-align:center;">
                <a href="About.aspx">
                <h3 style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">About</h3>
                <img class="sticky" style="width:auto; height:200px"; src="Content/Images/DSC00170 (1).jpg"/>
			    </a>
			    <p style="width: auto; margin-top:20px;margin-left:20%;margin-right: 20%; font-size: small;text-align:justify"  >We are a dedicated team of biologists whose area of study mainly includes interspecific variation in mammals. Our goal is to collect as much data as possible about different factors that affect social behaviour of mammals. Our end goal is to predict how certain species will be 
                able to adapt and evolove to climate change. Our research leads include Dr Loren Hayes, Professor at the University of Tennessee at Chattanooga and Dr Carsten Schradin, Director of Research at the Center National de la Recherche scientifique CNRS. Find out more about our team and study here.
                </p>
            </div>
    </div>
</asp:Content>