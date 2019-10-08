using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DatabasePublic : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    

    [WebMethod(EnableSession = true)]
    public static object AnimalList(int jtStartIndex, int jtPageSize, string jtSorting)
    {
        try
        {
            //Get data from database
            int animalCount = DataMethods.GetAnimalCount();
            List<DataClasses.Animal> animals = DataMethods.GetAnimals(jtStartIndex, jtPageSize, jtSorting);

            //Return result to jTable
            return new { Result = "OK", Records = animals, TotalRecordCount = animalCount };
        }
        catch (Exception ex)
        {
            return new { Result = "ERROR", Message = ex.Message };
        }
    }

    

    

}