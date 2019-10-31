﻿<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .carousel-inner {
            margin:auto; 
            width:100%; 
            height:40% !important;
        }

        .column {
            float: left;
            width: 33.3%;
            margin-bottom: 16px;
            padding: 0 20px;
        }

        .row2 {

        }
        .column2 {
            float: left;
            width: 33.3%;
            margin-bottom: 16px;
            padding: 0 20px;
        }

        .column3 {
            float: left;
            width: 33.3%;
            margin-bottom: 16px;
            padding: 0 20px;
        }
        .carousel-caption{
            text-align:left
            
        }
        .item h3{
            font-size:2em;  
        }        


        .item iframe {
            width:100%;
        }

        /* Display the columns below each other instead of side by side on small screens */
        @media screen and (max-width: 650px) {
            .column {
                width: 100%;
                display: block;
            }
        }

        /* Add some shadows to create a card effect */
        .card {
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
            word-wrap:normal;
        }

        /* Clear floats */
        .container::after, .row::after {
            content: "";
            clear: both;
            display: table;
        }

        /*adds a little grey for a title*/
        /*.title {
            color: grey;
            font:bold;
        }*/
        /*this formatting messed with the menu bar at the top. still needs work*/
        .container button 
        {
            /*display:inline-block;*/
            color: white;
            background-color: #000;
            cursor: pointer;
            width: 150px;
        }

    </style>

    <br />
    <div id="myCarousel" class="carousel slide" data-ride="carousel" style="width:80%; margin:auto">
    <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
          </ol>

    <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
            <div class="item active">
                <img src="Content/Images/team1.jpg" alt="">
                <div class="carousel-caption">
                    <h3>the Degu</h3>
                    <p>Chile in 2014</p>
                </div>
            </div>

        <div class="item">
            <img src="Content/Images/team2.jpg" alt="">
            <div class="carousel-caption">
                <h3>Dr Shradin</h3>
                <p>Researching African Striped Mice</p>
            </div>
        </div>

        <div class="item">
            <img src="Content/Images/team3.jpg" alt="">
            <div class="carousel-caption">
                <h3>Team Members</h3>
                <p>Discussing research material from resent trips</p>
            </div>
        </div>
    </div>

      <!-- Left and right controls -->
      <a class="left carousel-control" href="#myCarousel" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left"></span>
        <span class="sr-only">Previous</span>
      </a>
      <a class="right carousel-control" href="#myCarousel" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right"></span>
        <span class="sr-only">Next</span>
      </a>
    </div>
    <br />
    <h2>About the project</h2>

    <%--<h2 class="text-left"><%: Title %></h2>--%> 
    <p>
        Here we will put an overview of the project. You can mention the research you and your team have
        completed over the years. After that present the goals and furture plans that you have
        for the database.
    </p>
    <br>

    <h2>Meet the Team</h2>
    <div class="row">
        <div class="column">
            <div class="card">
              <img src="Content/Images/member1.jpg" alt="Jane" style="width:100%">
              <div class="container">
                <h2>Mock Up</h2>
                <p class="title">Title / Titles</p>
                <p>relevant information you would like to be shown.</p>
                <a href="mailto:carterhill007@gmail.com"><p>Email address</p></a>
                <p><button class="button">Other websites</button></p>
              </div>
            </div>
          </div>

          <div class="column">
            <div class="card">
              <img src="Content/Images/member1.jpg"alt="Mike" style="width:100%">
              <div class="container">
                <h2>Loren D. Hayes</h2>
                <p class="title">Associate Professor</p>
                <p>Department of</p> 
                <p>Biology, Geology, & Enviromental Science</p>
                <p>At the University of Tennessee at Chattanooga</p>
                <p>Loren-Hayes@utc.edu</p>
                <p><button class="button">Contact</button></p>
              </div>
            </div>
          </div>
          <div class="column">
            <div class="card">
              <img src="Content/Images/member1.jpg" alt="John" style="width:100%">
              <div class="container">
                <h2>Dr. Carsten Schradin</h2>
                <p class="title">Associate Professor</p>
                <p>Department of</p> 
                <p>Evolutionary Biology & Enviromental Studies</p>
                <p>University of Zurich</p>
                <p>Director of the Succulent Karoo Research Station</p>
                <p>carsten.schradin@iphc.cnrs.fr</p>
                <p><button class="button">Contact</button></p>
              </div>
            </div>
          </div>
        </div>  

    <h2>Contributors</h2>
    <p>
        Others who contributed their skills to the needs of the project. 
    </p>
    <br>

        <div class="row">
        <div class="column2">
            <div class="card">
              <img src="Content/Images/member1.jpg" alt="Jane" style="width:100%">
              <div class="container">
                <h2>Carter Hill</h2>
                <p class="title">Team Lead</p>
                <p>guided developement of social-organization-data.org</p>
                <a href="mailto:carterhill007@gmail.com"><p>Contact</p></a>
                <p><button class="button">More Information</button></p>
              </div>
            </div>
          </div>

          <div class="column2">
            <div class="card">
              <img src="Content/Images/member1.jpg"alt="Mike" style="width:100%">
              <div class="container">
                <h2>Loren D. Hayes</h2>
                <p class="title">Associate Professor</p>
                <p>Department of</p> 
                <p>Biology, Geology, & Enviromental Science</p>
                <p>At the University of Tennessee at Chattanooga</p>
                <p>Loren-Hayes@utc.edu</p>
                <p><button class="button">Contact</button></p>
              </div>
            </div>
          </div>
        </div>

    <h2>Developers</h2>
    <p>
        here we'll say something about ourselves 
    </p>
    <br>

    <div class="row">
        <div class="column">
            <div class="card">
              <img src="Content/Images/member1.jpg" alt="Jane" style="width:100%">
              <div class="container">
                <h2>Carter Hill</h2>
                <p class="title">Team Lead</p>
                <p>guided developement of social-organization-data.org</p>
                <a href="mailto:carterhill007@gmail.com"><p>Contact</p></a>
              </div>
            </div>
          </div>

          <div class="column">
            <div class="card">
              <img src="Content/Images/member1.jpg"alt="Mike" style="width:100%">
              <div class="container">
                <h2>Bowen Wexler</h2>
                <p class="title">Developement Lead</p>
                <p>some text</p> 
                <p>At the University of Tennessee at Chattanooga</p>
                <p>Contact information</p>
              </div>
            </div>
          </div>

          <div class="column">
            <div class="card">
              <img src="Content/Images/member1.jpg"alt="Mike" style="width:100%">
              <div class="container">
                <h2>Harold Hanson</h2>
                <p class="title">QA and Systems Analyst</p>
                <p>some text</p> 
                <p>At the University of Tennessee at Chattanooga</p>
                <p>Contact information</p>
              </div>
            </div>
          </div>
        </div>

          <div class="column">
            <div class="card">
              <img src="Content/Images/member1.jpg"alt="Mike" style="width:100%">
              <div class="container">
                <h2>Parshwa Patel</h2>
                <p class="title">Application Architect</p>
                <p>some text</p> 
                <p>At the University of Tennessee at Chattanooga</p>
                <p>Contact information</p>
              </div>
            </div>
          </div>
</asp:Content>
