using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DatabasePublic : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public class Animal
    {
        public int Animal_Id { get; set; }

        public int Genus_Species { get; set; }

        public string Common_Name { get; set; }

        public string Subspecies { get; set; }

        public string Population { get; set; }

        public string Continent { get; set; }
    }
}