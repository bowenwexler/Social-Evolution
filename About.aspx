<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script runat="server">
        //script not implemented yet
        //protected void hayes(object sender, EventArgs e)
        //{
        //    Context.Response.Redirect("/");
        //}
    </script>
    <style>
        /*formatting for the images inside the carousel*/
        .carousel-inner {
            margin:auto; 
            width:100%; 
            height:40% !important;
        }
        /*columns are listed in rows of 3*/
        .column {
            float: left;
            width: 33.3%;
            margin-bottom: 16px;
            padding: 0 20px;
        }
        /*column of developers*/
        .columnD {
            float: left;
            width: 25%;
            margin-bottom: 16px;
            padding: 0 20px;
        }
        /*the text in the left side of the carousel can be modified here*/
        .carousel-caption{
            text-align:left
            
        }
        /*increasing the font size in the carousel*/
        .item h3{
            font-size:2em;  
        }        

        /*changes the width of the pictures inside the carousel*/
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
            word-wrap:normal !important;
        }

        /* Clear floats */
        .container::after, .row::after {
            content: "";
            clear: both;
            display: table;
        }

        /*adds a little grey for a title*/
        .title {
            color: grey;
            font:bold;
        }
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
                <img src="Content/Images/degu.jpg" alt="">
                <div class="carousel-caption">
                    <h3>the Degu</h3>
                    <p>Chile in 2014</p>
                </div>
            </div>

        <div class="item">
            <img src="Content/Images/chipmunk.jpg" alt="">
            <div class="carousel-caption">
                <h3>Chipmunk</h3>
                <p>Scavaging for food</p>
            </div>
        </div>

        <div class="item">
            <img src="Content/Images/zebra.jpg" alt="">
            <div class="carousel-caption">
                <h3>Zebra</h3>
                <p>grazing around the desert</p>
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
        We are a dedicated team of biologists whose area of study mainly includes intra- and inter-specific variation in mammals.
        Our goal is to collect the most accurate data as possible about different factors that affect mammalian social organization.
        The lead contributors to this team include Prof. Loren Hayes (University of Tennessee at Chattanooga) and Prof. 
        Carsten Schradin (Director of Research at the Center National de la Recherche scientifique CNRS). Find out more about our team and study here.
    </p>
    <br>

    <h2>Meet the Team</h2>
    <div class="row">
          <div class="column">
            <div class="card">
              <img src="Content/Images/loren.jpg"alt="loren" style="width:100%">
              <div class="container">
                <h2>Loren D. Hayes</h2>
                <p class="title">Associate Professor</p>
                <p>Department of</p> 
                <p>Biology, Geology, & Enviromental Science</p>
                <p>At the University of Tennessee at Chattanooga</p>
                <a href="mailto:Loren-Hayes@utc.edu"><p>Contact</p></a>

                <p><button class="button">Further Information</button></p>
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
                <a href="mailto:carsten.schradin@iphc.cnrs.fr"<p>Contact</p></a>
                <%-- button link not implemented in script yet --%>
                <p><button class="button">Further Information </button></p>
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
        <div class="column">
            <div class="card">
              <img src="Content/Images/tanis.jpg" alt="Jane" style="width:100%">
              <div class="container">
                <h2>Craig Tanis</h2>
                <p class="title">Assistant Professor</p>
                  <p>of Computer Sciecne and Engineering</p>
                  <p>at the University of Tennessee at Chattanooga</p>
                  <p>Developing AI to detect and import</p>
                  <p>data into the repository</p>
              </div>
            </div>
          </div>

          <div class="column">
            <div class="card">
              <img src="Content/Images/hare.jpg"alt="Mike" style="width:100%">
              <div class="container">
                <h2>Russ Hare</h2>
                <p class="title">Lecturer</p>
                <p>of Computer Science and Engineering</p> 
                <p>at the University of Tennessee at Chattanooga</p>
                <p>Initated Developement of Project with</p>
                  <p>UTC staff and Student body</p>
              </div>
            </div>
          </div>
        </div>

    <h2>Developers</h2>
    <p>
        Students at UTC who provided their time and effort into making this project a reality
    </p>
    <br>

<div class="developers">
    <div class="row">
        <div class="columnD">
            <div class="card">
              <div class="container">
                <h2>Carter Hill</h2>
                <p class="title">Team Lead</p>
                <p>guided developement of</p>
                <p>social-organization-data.org</p>
              </div>
            </div>
          </div>

          <div class="columnD">
            <div class="card">
              <div class="container">
                <h2>Bowen Wexler</h2>
                <p class="title">Developement Lead</p>
                <p>Designed database and website</p> 
                <p>for social-organization-data.org</p>
              </div>
            </div>
          </div>

          <div class="columnD">
            <div class="card">
              <div class="container">
                <h2>Harold Hanson</h2>
                <p class="title">QA and Systems Analyst</p>
                <p>Ensured the quality</p>
                <p>and security of this dataset</p>
              </div>
            </div>
          </div>
        <div class="columnD">
            <div class="card">
              <div class="container">
                <h2>Parshwa Patel</h2>
                <p class="title">Application Architect</p>
                <p>Designed visuals for</p> 
                <p>the website and database repository</p>
                <p>that aided with developement</p>
              </div>
            </div>
        </div>
        </div>
        
</div>
</asp:Content>
