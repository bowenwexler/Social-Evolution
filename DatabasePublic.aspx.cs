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
            string testSelect = "SELECT * FROM Animal";
            List<Animal> animals = new List<Animal>();
            animals = ExcuteObject<Animal>(testSelect, false).ToList();
            return new { Result = "OK", Records = animals };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    //public IEnumerable<T> ExcuteObject<T>(string command)
    //{
    //    List<T> items = new List<T>();
    //    var dataTable = Select(command); //this will use the DataTable Select function
    //    foreach (var row in dataTable.Rows)
    //    {
    //        T item = (T)Activator.CreateInstance(typeof(T), row);
    //        items.Add(item);
    //    }
    //    return items;
    //}

    public static IEnumerable<T> ExcuteObject<T>(string storedProcedureorCommandText, bool isStoredProcedure = true)
    {
        List<T> items = new List<T>();
        var dataTable = Select(storedProcedureorCommandText, isStoredProcedure); //this will use the DataTable Select function
        foreach (var row in dataTable.Rows)
        {
            T item = (T)Activator.CreateInstance(typeof(T), row);
            items.Add(item);
        }
        return items;
    }

    public static DataTable Select(string storedProcedureorCommandText, bool isStoredProcedure = true)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection connection = new SqlConnection("ConnectionString"))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                if (!isStoredProcedure)
                {
                    command.CommandType = CommandType.Text;
                }
                command.CommandText = storedProcedureorCommandText;
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }

    //public DataTable Select(string command)
    //{
    //    //Assign connection string to sqldatasource
    //    SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    //    //Assign the selectcommand to sqldatasource
    //    SqlDataSource1.SelectCommand = command;

    //    DataView dataView = SqlDataSource1.Select(DataSourceSelectArguments.Empty) as DataView;
    //    DataTable dataTable = new DataTable();
    //    dataTable = dataView.ToTable();

    //    return dataTable;
    //}

}