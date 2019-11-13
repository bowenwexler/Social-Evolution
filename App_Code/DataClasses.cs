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

            public string Order { get; set; }

            public string Genus_Species { get; set; }

            public string Common_Name { get; set; }

            public string Subspecies { get; set; }

            public string Population { get; set; }

            public string Continent { get; set; }

            public string GPS_Coordinates { get; set; }

            public string Reference { get; set; }

            public Animal(DataRow row)
            {
                this.ID = Convert.ToInt32(row["Id"]);
                this.Genus_Species = row["genus_species"].ToString().Replace("'", @"''");
                this.Order = row["order"].ToString().Replace("'", @"''");
                this.Common_Name = row["common_name"].ToString().Replace("'", @"''");
                this.Subspecies = row["subspecies"].ToString().Replace("'", @"''");
                this.Population = row["population"].ToString().Replace("'", @"''");
                this.Continent = row["continent"].ToString().Replace("'", @"''");
                this.GPS_Coordinates = row["gps_coordinates"].ToString().Replace("'", @"''");
                this.Reference = row["reference"].ToString().Replace("'", @"''");
            }

            public Animal()
            {
                
            }
        }

        public class AnimalDemographics
        {
            public int ID { get; set; }

            public string Morphic { get; set; }

            public string Male_BM { get; set; }

            public string Female_BM { get; set; }
      
            public string MF_BM { get; set; }

            public string Avg_BM { get; set; }

            public string Pop_Density { get; set; }

            public AnimalDemographics(DataRow row)
            {
                this.ID = Convert.ToInt32(row["Id"]);
                this.Morphic = row["dimorphic_monomorphic"].ToString().Replace("'", @"''");
                this.Male_BM = row["male_bm"].ToString().Replace("'", @"''");
                this.Female_BM = row["female_bm"].ToString().Replace("'", @"''");
                this.MF_BM = row["mf_bm"].ToString().Replace("'", @"''");
                this.Avg_BM = row["avg_bm"].ToString().Replace("'", @"''");
                this.Pop_Density = row["population_density"].ToString().Replace("'", @"''");
            }

            public AnimalDemographics()
            {

            }
        }

        public class AnimalSocial
        {
            public int ID { get; set; }

            public String M { get; set; }

            public String F { get; set; }

            public String Solitary { get; set; }

            public String MF { get; set; }

            public String MF_Off { get; set; }

            public String MFF { get; set; }

            public String FMM { get; set; }

            public String FFMM { get; set; }

            public String FF { get; set; }

            public String MM { get; set; }

            public String Social_State { get; set; }

            public String Num_Studies { get; set; }

            public String Season { get; set; }

            public String Breeding { get; set; }

            public AnimalSocial(DataRow row)
            {
                
                this.ID = Convert.ToInt32(row["Id"]);
                this.M = row["m"].ToString().Replace("'", @"''");
                this.F = row["f"].ToString().Replace("'", @"''");
                this.Solitary = row["solitary_both"].ToString().Replace("'", @"''");
                this.MF = row["mf"].ToString().Replace("'", @"''");
                this.MF_Off = row["mf_off"].ToString().Replace("'", @"''");
                this.MFF = row["mff"].ToString().Replace("'", @"''");
                this.FMM = row["fmm"].ToString().Replace("'", @"''");
                this.FFMM = row["ffmm"].ToString().Replace("'", @"''");
                this.FF = row["ff"].ToString().Replace("'", @"''");
                this.MM = row["mm"].ToString().Replace("'", @"''");
                this.Social_State = row["social_state"].ToString().Replace("'", @"''");
                this.Num_Studies = row["num_studies"].ToString().Replace("'", @"''");
                this.Season = row["season"].ToString().Replace("'", @"''");
                this.Breeding = row["breeding"].ToString().Replace("'", @"''");
            }

            public AnimalSocial()
            {

            }
        }

        public class AnimalEnvironment
        {
            public int ID { get; set; }

            public string IUCN_Habitat { get; set; }

            public string Num_Habitats { get; set; }

            public string Lat_Range { get; set; }

            public string Mean_Precip { get; set; }

            public string Variance_Precip { get; set; }

            public string Predict_Precip { get; set; }

            public string Mean_Temp { get; set; }

            public string Variance_Temp { get; set; }

            public string Predict_Temp { get; set; }

            public string Mountain_Range { get; set; }

            public AnimalEnvironment(DataRow row)
            {
                this.ID = Convert.ToInt32(row["Id"]);
                this.IUCN_Habitat = row["iucn_habitat"].ToString().Replace("'", @"''");
                this.Num_Habitats = row["num_habitats"].ToString().Replace("'", @"''");
                this.Lat_Range = row["lat_range"].ToString().Replace("'", @"''");
                this.Mean_Precip = row["mean_precip"].ToString().Replace("'", @"''");
                this.Variance_Precip = row["variance_precip"].ToString().Replace("'", @"''");
                this.Predict_Precip = row["predict_precip"].ToString().Replace("'", @"''");
                this.Mean_Temp = row["mean_temp"].ToString().Replace("'", @"''");
                this.Variance_Temp = row["variance_temp"].ToString().Replace("'", @"''");
                this.Predict_Temp = row["predict_temp"].ToString().Replace("'", @"''");
                this.Mountain_Range = row["mountain_range"].ToString().Replace("'", @"''");
            }

            public AnimalEnvironment()
            {

            }
        }

        public class AnimalLife
        {
            public int ID { get; set; }

            public string Avg_Lifespan { get; set; }

            public string Parous { get; set; }

            public string First_Reproduction { get; set; }

            public string Offspring_Production { get; set; }

            public AnimalLife(DataRow row)
            {
                this.ID = Convert.ToInt32(row["Id"]);
                this.Avg_Lifespan = row["avg_lifespan"].ToString().Replace("'", @"''");
                this.Parous = row["parous"].ToString().Replace("'", @"''");
                this.First_Reproduction = row["first_reproduction_age"].ToString().Replace("'", @"''");
                this.Offspring_Production = row["offspring_production"].ToString().Replace("'", @"''");
            }

            public AnimalLife()
            {

            }
        }
    }
}