using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class DataMethods
{
    public static int GetAnimalCount()
    {
        return 3;
    }

    public IEnumerable<T> ExcuteObject<T>(string storedProcedureorCommandText, bool isStoredProcedure = true)
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

    public DataTable Select(string storedProcedureorCommandText, bool isStoredProcedure = true)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection connection = new SqlConnection("DefaultConnection"))
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

    //public static List<DataClasses.Animal> GetAnimals(int jtStartIndex, int jtPageSize, string jtSorting)
    //{
    //    List <DataClasses.Animal> list = new List<DataClasses.Animal>();

    //}
}