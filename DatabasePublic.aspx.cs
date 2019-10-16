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

    [WebMethod(EnableSession = true)]
    public static object AnimalList()
    {
        try
        {
            string select = "SELECT * FROM Animal";
            List<Animal> animals = new List<Animal>();
            animals = ExcuteObject<Animal>(select).ToList();
            return new { Result = "OK", Records = animals };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    [WebMethod(EnableSession = true)]
    public static object CreateAnimal(Animal record)
    {
        try
        {
            string insert, values, columns;
            values = "";
            columns = "";
            if (record.Genus_Species != "") { values += "'" + record.Genus_Species + "' "; columns += "genus_species "; }
            if (record.Common_Name != "") { values += ",'" + record.Common_Name + "' "; columns += ",common_name "; }
            if (record.Subspecies != "") { values += ",'" + record.Subspecies + "' "; columns += ",subspecies "; }
            if (record.Population != "") { values += "," + record.Population; columns += ",population "; }
            if (record.Continent != "") { values += ",'" + record.Continent + "' "; columns += ",continent "; }
            insert = "Insert into Animal(" + columns + ") values(" + values + ")";
            Insert(insert);
            DataTable animalTable = new DataTable();

            animalTable.Columns.Add("Id");
            animalTable.Columns.Add("genus_species");
            animalTable.Columns.Add("common_name");
            animalTable.Columns.Add("subspecies");
            animalTable.Columns.Add("population");
            animalTable.Columns.Add("continent");

            DataRow animalRow = animalTable.NewRow();

            animalRow["Id"] = record.Animal_Id;
            animalRow["genus_species"] = record.Genus_Species;
            animalRow["common_name"] = record.Common_Name;
            animalRow["subspecies"] = record.Subspecies;
            animalRow["population"] = record.Population;
            animalRow["continent"] = record.Continent;

            Animal addedAnimal = new Animal(animalRow);
            return new { Result = "OK", Record = addedAnimal };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    public static IEnumerable<T> ExcuteObject<T>(string commandText)
    {
        List<T> items = new List<T>();
        var dataTable = Select(commandText); //this will use the DataTable Select function
        foreach (var row in dataTable.Rows)
        {
            T item = (T)Activator.CreateInstance(typeof(T), row);
            items.Add(item);
        }
        return items;
    }

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

    public static void Insert(string commandText)
    {
        DataTable dataTable = new DataTable();
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

}
