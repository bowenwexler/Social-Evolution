using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace DataClasses
{
    public class DataClasses
    {
        public class Animal
        {
            public int ID { get; set; }

            public string Genus_Species { get; set; }

            public string Common_Name { get; set; }

            public string Subspecies { get; set; }

            public string Population { get; set; }

            public string Continent { get; set; }

            public Animal(DataRow row)
            {
                this.ID = Convert.ToInt32(row["Id"]);
                this.Genus_Species = row["genus_species"].ToString();
                this.Common_Name = row["common_name"].ToString();
                this.Subspecies = row["subspecies"].ToString();
                this.Population = row["population"].ToString();
                this.Continent = row["continent"].ToString();
            }

            public Animal()
            {
                
            }
        }
    }
}