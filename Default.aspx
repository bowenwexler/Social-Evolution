<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="text-align: center">
        <h1 class="text-center" style="font-family: 'Bahnschrift SemiBold'; font-size: x-large;">[Insert Logo Image Here]</h1>
        <hr style="visibility:visible"/>
        <br />
        <p class="text-right" style="text-align: justify; font-size: medium;">Welcome to [insert name here]! Here a community of biologists come to together to compile a one-of-a-kind database! This database catalogs several often overlooked statistics about mammal social habits extracted from hundreds of different studies. Feel free to join the team by going to our &quot;Contribute&quot; page.</p>
        <br />
        <!-- Carousel container -->
        <div id="home-carousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#home-carousel" data-slide-to="0" class="active"></li>
                <li data-target="#home-carousel" data-slide-to="1"></li>
                <li data-target="#home-carousel" data-slide-to="2"></li>
            </ol>
            <!-- Content -->
            <div class="carousel-inner" role="listbox">
                <!-- Slide 1 -->
                <div class="item active">
                    <img src="Content/HomeImages/kotKnife.jpg" alt="Kot Blini with Knife 1">
                </div>
                <!-- Slide 2 -->
                <div class="item">
                    <img src="Content/HomeImages/kot2.jpg" alt="Kot Blini with Knife 2">
                </div>
                <!-- Slide 3 -->
                <div class="item">
                    <img src="Content/HomeImages/kot3.jpg" alt="Kot Blini with Knife 3">
                </div>
            </div>
            <!-- Previous/Next controls -->
            <a class="left carousel-control" href="#home-carousel" role="button" data-slide="prev">
            <span class="icon-prev" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#home-carousel" role="button" data-slide="next">
            <span class="icon-next" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
            </a>
        </div>
    </div>
</asp:Content>