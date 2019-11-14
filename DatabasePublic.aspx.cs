using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClasses;
using DataMethods;
using static DataClasses.DataClasses;
using static DataMethods.DataMethods;

public partial class DatabasePublic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //This method selects columns to go into the Species and Population table and returns it as a json object
    [WebMethod(EnableSession = true)]
    public static object AnimalList(int jtStartIndex, int jtPageSize, string jtSorting)
    {
        string select = "";

        //We also need to find the total number of rows, since we have pagination set up
        string totalcmd = "SELECT COUNT(*) FROM master";
        int animalCount = 0;
        try
        {
            //Our SQL query
            select = "SELECT Id, genus_species, [order], common_name, subspecies, population, continent, gps_coordinates, reference FROM master ORDER BY " + jtSorting + " offset " + jtStartIndex + " rows fetch next " + jtPageSize + " rows only";
            
            //Method to get total rows
            animalCount = Total(totalcmd);

            //List of Animal objects to be populated soon
            List<Animal> animals = new List<Animal>();

            //Populate each Animal object in our list with data from the database
            animals = ExcuteObject<Animal>(select).ToList();

            //Our return passes our row total and list as a json object back to javascript code that the JTable library uses to populate the table
            return new { Result = "OK", Records = animals, TotalRecordCount = animalCount };
        }
        //This bit will give us an error message, say if the SQL query was breaking somewhere
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    //This method adds a record to the database
    [WebMethod(EnableSession = true)]
    public static object CreateAnimal(Animal record)
    {
        try
        {
            //We break up our insert query into columns that being modified and values to pass into said columns
            string insert, values, columns;

            //startComma is used to track if a comma should be placed or not to properly construct our query string
            Boolean startComma = false;
            values = "";
            columns = "";

            //This big old block of code is a very clunky way of checking to which values were passed on creation of the record and stringing them all together
            if (record.Genus_Species != "") { values += "'" + record.Genus_Species + "'"; columns += "genus_species "; startComma = true; }

            if (record.Common_Name != "" && startComma) { values += ", '" + record.Common_Name + "'"; columns += ", common_name"; }
            else if (record.Common_Name != "" && startComma == false) { values += "'" + record.Common_Name + "'"; columns += "common_name"; startComma = true; }

            if (record.Order != "" && startComma) { values += ", '" + record.Order + "'"; columns += ", [order]"; }
            else if (record.Order != "" && startComma == false) { values += "'" + record.Order + "'"; columns += "[order]"; startComma = true; }

            if (record.Subspecies != "" && startComma) { values += ", '" + record.Subspecies + "'"; columns += ", subspecies"; }
            else if (record.Subspecies != "" && startComma == false) { values += "'" + record.Subspecies + "'"; columns += "subspecies"; startComma = true; }

            if (record.Population != "" && startComma) { values += ", '" + record.Population + "'"; columns += ", population"; }
            else if (record.Population != "" && startComma == false) { values += "'" + record.Population + "'"; columns += "population"; startComma = true; }

            if (record.Continent != "" && startComma) { values += ", '" + record.Continent + "' "; columns += ", continent"; }
            else if (record.Continent != "" && startComma == false) { values += "'" + record.Continent + "'"; columns += "continent"; startComma = true; }

            if (record.GPS_Coordinates != "" && startComma) { values += ", '" + record.GPS_Coordinates + "' "; columns += ", gps_coordinates"; }
            else if (record.GPS_Coordinates != "" && startComma == false) { values += "'" + record.GPS_Coordinates + "'"; columns += "gps_coordinates"; startComma = true; }

            if (record.Reference != "" && startComma) { values += ", '" + record.Reference + "' "; columns += ", reference"; }
            else if (record.Reference != "" && startComma == false) { values += "'" + record.Reference + "'"; columns += "reference"; }

            insert = "Insert into master(" + columns + ") values(" + values + ")";

            //We then pass this SQL command into another method that executes it
            InsertEdit(insert);

            //This next part contructs the data that is passed back to JTable to update the view side of things
            DataTable animalTable = new DataTable();

            animalTable.Columns.Add("Id");
            animalTable.Columns.Add("genus_species");
            animalTable.Columns.Add("order");
            animalTable.Columns.Add("common_name");
            animalTable.Columns.Add("subspecies");
            animalTable.Columns.Add("population");
            animalTable.Columns.Add("continent");
            animalTable.Columns.Add("gps_coordinates");
            animalTable.Columns.Add("reference");

            DataRow animalRow = animalTable.NewRow();

            animalRow["Id"] = record.ID;
            animalRow["genus_species"] = record.Genus_Species;
            animalRow["order"] = record.Genus_Species;
            animalRow["common_name"] = record.Order;
            animalRow["subspecies"] = record.Subspecies;
            animalRow["population"] = record.Population;
            animalRow["continent"] = record.Continent;
            animalRow["gps_coordinates"] = record.GPS_Coordinates;
            animalRow["reference"] = record.Reference;

            Animal addedAnimal = new Animal(animalRow);
            return new { Result = "OK", Record = addedAnimal };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    //This method edits records in the database
    [WebMethod(EnableSession = true)]
    public static object EditAnimal(Animal record)
    {
        try
        {
            //Here we build our SQL command text. If a value is empty, we must make it NULL in the database.
            string values = "";
            if (record.Genus_Species != "") { values += "genus_species = '" + record.Genus_Species + "', "; }
            else { values += "genus_species = NULL, "; }
            if (record.Common_Name != "") { values += "common_name = '" + record.Common_Name + "', "; }
            else { values += "common_name = NULL, "; }
            if (record.Order != "") { values += "[order] = '" + record.Order + "', "; }
            else { values += "[order] = NULL, "; }
            if (record.Subspecies != "") { values += "subspecies = '" + record.Subspecies + "', "; }
            else { values += "subspecies = NULL, "; }
            if (record.Population != "") { values += "population = '" + record.Population + "', "; }
            else { values += "population = NULL, "; }
            if (record.Continent != "") { values += "continent = '" + record.Continent + "', "; }
            else { values += "continent = NULL, "; }
            if (record.GPS_Coordinates != "") { values += "gps_coordinates = '" + record.GPS_Coordinates + "', "; }
            else { values += "gps_coordinates = NULL, "; }
            if (record.Reference != "") { values += "reference = '" + record.Reference + "' "; }
            else { values += "reference = NULL "; }
            string edit;
            edit = "Update master Set " + values + " WHERE Id = " + record.ID;
            InsertEdit(edit);

            return new { Result = "OK" };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    //This method deletes record in the database
    [WebMethod(EnableSession = true)]
    public static object DeleteAnimal(int ID)
    {
        try
        {
            //SQL command text will always be the same
            string cmd = "DELETE FROM master WHERE Id = " + ID;
            Delete(cmd, ID);
            return new { Result = "OK" };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    //After this, these methods are more or less repeated but with different names for different tables and columns

    [WebMethod(EnableSession = true)]
    public static object AnimalSocialList(int jtStartIndex, int jtPageSize, string jtSorting)
    {
        string select = "";
        string totalcmd = "SELECT COUNT(*) FROM master";
        int animalCount = 0;
        try
        {
            //string select = "SELECT * FROM Animal";
            select = "SELECT Id, m, f, solitary_both, mf, mf_off, mff, fmm, ffmm, ff, mm, social_state, num_studies, season, breeding FROM master ORDER BY " + jtSorting + " offset " + jtStartIndex + " rows fetch next " + jtPageSize + " rows only";
            animalCount = Total(totalcmd);
            List<AnimalSocial> animals = new List<AnimalSocial>();
            animals = ExcuteObject<AnimalSocial>(select).ToList();
            return new { Result = "OK", Records = animals, TotalRecordCount = animalCount };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    [WebMethod(EnableSession = true)]
    public static object EditAnimalSocial(AnimalSocial record)
    {
        try
        {
            string values = "";
            if (record.M != "") { values += "m = '" + record.M + "', "; }
            else { values += "m = NULL, "; }
            if (record.F != "") { values += "f = '" + record.F + "', "; }
            else { values += "f = NULL, "; }
            if (record.Solitary != "") { values += "solitary_both = '" + record.Solitary + "', "; }
            else { values += "solitary_both = NULL, "; }
            if (record.MF != "") { values += "mf = '" + record.MF + "', "; }
            else { values += "mf = NULL, "; }
            if (record.MF_Off != "") { values += "mf_off = '" + record.MF_Off + "', "; }
            else { values += "mf_off = NULL, "; }
            if (record.MFF != "") { values += "mff = '" + record.MFF + "', "; }
            else { values += "mff = NULL, "; }
            if (record.FMM != "") { values += "fmm = '" + record.FMM + "', "; }
            else { values += "fmm = NULL, "; }
            if (record.FFMM != "") { values += "ffmm = '" + record.FFMM + "', "; }
            else { values += "ffmm = NULL, "; }
            if (record.FF != "") { values += "ff = '" + record.FF + "', "; }
            else { values += "ff = NULL, "; }
            if (record.MM != "") { values += "mm = '" + record.MM + "', "; }
            else { values += "mm = NULL, "; }
            if (record.Social_State != "") { values += "social_state = '" + record.Social_State + "', "; }
            else { values += "social_state = NULL, "; }
            if (record.Num_Studies != "") { values += "num_studies = '" + record.Num_Studies + "', "; }
            else { values += "num_studies = NULL, "; }
            if (record.Season != "") { values += "season = '" + record.Season + "', "; }
            else { values += "season = NULL, "; }
            if (record.Breeding != "") { values += "breeding = '" + record.Breeding + "'"; }
            else { values += "breeding = NULL "; }
            string edit;
            edit = "Update master Set " + values + " WHERE Id = " + record.ID;
            InsertEdit(edit);

            return new { Result = "OK" };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    [WebMethod(EnableSession = true)]
    public static object DeleteAnimalSocial(int ID)
    {
        try
        {
            string cmd = "DELETE FROM master WHERE Id = " + ID;
            Delete(cmd, ID);
            return new { Result = "OK" };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    [WebMethod(EnableSession = true)]
    public static object AnimalListDemographics(int jtStartIndex, int jtPageSize, string jtSorting)
    {
        string select = "";
        string totalcmd = "SELECT COUNT(*) FROM master";
        int animalCount = 0;
        try
        {
            //string select = "SELECT * FROM Animal";
            select = "SELECT Id, dimorphic_monomorphic, male_bm, female_bm, mf_bm, avg_bm, population_density FROM master ORDER BY " + jtSorting + " offset " + jtStartIndex + " rows fetch next " + jtPageSize + " rows only";
            animalCount = Total(totalcmd);
            List<AnimalDemographics> animals = new List<AnimalDemographics>();
            animals = ExcuteObject<AnimalDemographics>(select).ToList();
            return new { Result = "OK", Records = animals, TotalRecordCount = animalCount };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    [WebMethod(EnableSession = true)]
    public static object EditAnimalDemographics(AnimalDemographics record)
    {
        try
        {
            string values = "";
            if (record.Morphic != "") { values += "dimorphic_monomorphic = '" + record.Morphic + "', "; }
            else { values += "dimorphic_monomorphic = NULL, "; }
            if (record.Male_BM != "") { values += "male_bm = '" + record.Male_BM + "', "; }
            else { values += "male_bm = NULL, "; }
            if (record.Female_BM != "") { values += "female_bm = '" + record.Female_BM + "', "; }
            else { values += "female_bm = NULL, "; }
            if (record.MF_BM != "") { values += "mf_bm = '" + record.MF_BM + "', "; }
            else { values += "mf_bm = NULL, "; }
            if (record.Avg_BM != "") { values += "avg_bm = '" + record.Avg_BM + "', "; }
            else { values += "avg_bm = NULL, "; }
            if (record.Pop_Density != "") { values += "population_density = '" + record.Pop_Density + "' "; }
            else { values += "population_density = NULL "; }
            string edit;
            edit = "Update master Set " + values + " WHERE Id = " + record.ID;
            InsertEdit(edit);

            return new { Result = "OK" };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    [WebMethod(EnableSession = true)]
    public static object DeleteAnimalDemographics(int ID)
    {
        try
        {
            string cmd = "DELETE FROM master WHERE Id = " + ID;
            Delete(cmd, ID);
            return new { Result = "OK" };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    [WebMethod(EnableSession = true)]
    public static object AnimalListEnvironment(int jtStartIndex, int jtPageSize, string jtSorting)
    {
        string select = "";
        string totalcmd = "SELECT COUNT(*) FROM master";
        int animalCount = 0;
        try
        {
            //string select = "SELECT * FROM Animal";
            select = "SELECT Id, iucn_habitat, num_habitats, lat_range, mean_precip, variance_precip, predict_precip, mean_temp, variance_temp, predict_temp, mountain_range FROM master ORDER BY " + jtSorting + " offset " + jtStartIndex + " rows fetch next " + jtPageSize + " rows only";
            animalCount = Total(totalcmd);
            List<AnimalEnvironment> animals = new List<AnimalEnvironment>();
            animals = ExcuteObject<AnimalEnvironment>(select).ToList();
            return new { Result = "OK", Records = animals, TotalRecordCount = animalCount };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    [WebMethod(EnableSession = true)]
    public static object EditAnimalEnvironment(AnimalEnvironment record)
    {
        try
        {
            string values = "";
            if (record.IUCN_Habitat != "") { values += "iucn_habitat = '" + record.IUCN_Habitat + "', "; }
            else { values += "icun_habitat = NULL, "; }
            if (record.Num_Habitats != "") { values += "num_habitats = '" + record.Num_Habitats + "', "; }
            else { values += "num_habitats = NULL, "; }
            if (record.Lat_Range != "") { values += "lat_range = '" + record.Lat_Range + "', "; }
            else { values += "lat_range = NULL, "; }
            if (record.Mean_Precip != "") { values += "mean_precip = '" + record.Mean_Precip + "', "; }
            else { values += "mean_precip = NULL, "; }
            if (record.Variance_Precip != "") { values += "variance_precip = '" + record.Variance_Precip + "', "; }
            else { values += "variance_precip = NULL, "; }
            if (record.Predict_Precip != "") { values += "predict_precip = '" + record.Predict_Precip + "', "; }
            else { values += "predict_precip = NULL, "; }
            if (record.Mean_Temp != "") { values += "mean_temp = '" + record.Mean_Temp + "', "; }
            else { values += "mean_temp = NULL, "; }
            if (record.Variance_Temp != "") { values += "variance_temp = '" + record.Variance_Temp + "', "; }
            else { values += "variance_temp = NULL, "; }
            if (record.Predict_Temp != "") { values += "predict_temp = '" + record.Predict_Temp + "', "; }
            else { values += "predict_temp = NULL, "; }
            if (record.Mountain_Range != "") { values += "mountain_range = '" + record.Mountain_Range + "' "; }
            else { values += "mountain_range = NULL "; }
            string edit;
            edit = "Update master Set " + values + " WHERE Id = " + record.ID;
            InsertEdit(edit);

            return new { Result = "OK" };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    [WebMethod(EnableSession = true)]
    public static object DeleteAnimalEnvironment(int ID)
    {
        try
        {
            string cmd = "DELETE FROM master WHERE Id = " + ID;
            Delete(cmd, ID);
            return new { Result = "OK" };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    [WebMethod(EnableSession = true)]
    public static object AnimalListLife(int jtStartIndex, int jtPageSize, string jtSorting)
    {
        string select = "";
        string totalcmd = "SELECT COUNT(*) FROM master";
        int animalCount = 0;
        try
        {
            //string select = "SELECT * FROM Animal";
            select = "SELECT Id, avg_lifespan, parous, first_reproduction_age, offspring_production FROM master ORDER BY " + jtSorting + " offset " + jtStartIndex + " rows fetch next " + jtPageSize + " rows only";
            animalCount = Total(totalcmd);
            List<AnimalLife> animals = new List<AnimalLife>();
            animals = ExcuteObject<AnimalLife>(select).ToList();
            return new { Result = "OK", Records = animals, TotalRecordCount = animalCount };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    [WebMethod(EnableSession = true)]
    public static object EditAnimalLife(AnimalLife record)
    {
        try
        {
            string values = "";
            if (record.Avg_Lifespan != "") { values += "avg_lifespan = '" + record.Avg_Lifespan + "', "; }
            else { values += "avg_lifespan = NULL, "; }
            if (record.Parous != "") { values += "parous = '" + record.Parous + "', "; }
            else { values += "parous = NULL, "; }
            if (record.First_Reproduction != "") { values += "first_reproduction_age = '" + record.First_Reproduction + "', "; }
            else { values += "first_reproduction_age = NULL, "; }
            if (record.Offspring_Production != "") { values += "offspring_production = '" + record.Offspring_Production + "' "; }
            else { values += "offspring_production = NULL "; }
            string edit;
            edit = "Update master Set " + values + " WHERE Id = " + record.ID;
            InsertEdit(edit);

            return new { Result = "OK" };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    [WebMethod(EnableSession = true)]
    public static object DeleteAnimalLife(int ID)
    {
        try
        {
            string cmd = "DELETE FROM master WHERE Id = " + ID;
            Delete(cmd, ID);
            return new { Result = "OK" };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    //This is an intermediate method that essentially converts a data table object to our list format
    public static IEnumerable<T> ExcuteObject<T>(string commandText)
    {
        List<T> items = new List<T>();
        //populates a data table using data from the data base
        var dataTable = Select(commandText);
        //For each row in the data table, convert this row to a Class of our choice and add said class to our list
        foreach (var row in dataTable.Rows)
        {
            T item = (T)Activator.CreateInstance(typeof(T), row);
            items.Add(item);
        }
        return items;
    }

    //Creates a data table using SqlDataAdapter
    public static DataTable Select(string commandText)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
                connection.Close();
                command.Dispose();
                return dataTable;
            }
        }
    }

    //Returns the total number of rows in the data base
    public static int Total(string commandText)
    {
        string command = commandText;
        int count = 0;

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        {
            using (SqlCommand cmdCount = new SqlCommand(command, connection))
            {
                connection.Open();
                count = (int)cmdCount.ExecuteScalar();
            }
        }
        return count;
    }

    //Executes sql commands for inserting and editind rows
    public static void InsertEdit(string commandText)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        {
            connection.Open();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = commandText;
            command = new SqlCommand(sql, connection);
            adapter.InsertCommand = new SqlCommand(sql, connection);
            adapter.InsertCommand.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
        }
    }

    //Executes sql commands for deleting rows
    public static void Delete(string commandText, int Id)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        {
            connection.Open();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = commandText;
            command = new SqlCommand(sql, connection);
            adapter.DeleteCommand = new SqlCommand(sql, connection);
            adapter.DeleteCommand.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
        }
    }
}