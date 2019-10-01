<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center"><%: Title %>.</h2>
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
                    <img src="Content/TestImages/kotKnife.jpg" alt="Kot Blini with Knife 1">
                </div>
                <!-- Slide 2 -->
                <div class="item">
                    <img src="Content/TestImages/kot2.jpg" alt="Kot Blini with Knife 2">
                </div>
                <!-- Slide 3 -->
                <div class="item">
                    <img src="Content/TestImages/kot3.jpg" alt="Kot Blini with Knife 3">
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
</asp:Content>
