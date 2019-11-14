<%@ Page Title="Contribute" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contribute.aspx.cs" Inherits="Contribute" %>

<script runat="server">


    protected void AddAnimalRecord_Click(object sender, EventArgs e)
    {
        string insert, values, columns;
        Boolean startComma = false;
        values = "";
        columns = "";
        if (Genus_Species.Text != "") { values += "'" + Genus_Species.Text + "'"; columns += "genus_species "; startComma = true; }

        if (Common_Name.Text != "" && startComma) { values += ", '" + Common_Name.Text + "'"; columns += ", common_name"; }
        else if (Common_Name.Text != "" && startComma == false) { values += "'" + Common_Name.Text + "'"; columns += "common_name"; }

        if (Subspecies.Text != "" && startComma) { values += ", '" + Subspecies.Text + "'"; columns += ", subspecies"; }
        else if (Subspecies.Text != "" && startComma == false) { values += "'" + Subspecies.Text + "'"; columns += "subspecies"; }

        if (Population.Text != "" && startComma) { values += ", '" + Population.Text + "'"; columns += ", population"; }
        else if (Population.Text != "" && startComma == false) { values += "'" + Population.Text + "'"; columns += "population"; }

        if (Continent.Text != "" && startComma) { values += ", '" + Continent.Text + "' "; columns += ", continent"; }
        else if (Continent.Text != "" && startComma == false) { values += "'" + Continent.Text + "'"; columns += "continent"; }

        insert = "Insert into master(" + columns + ") values(" + values + ")";

        using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection (ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        {
            connection.Open();
            System.Data.SqlClient.SqlCommand command;
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
            String sql = insert;
            command = new System.Data.SqlClient.SqlCommand(sql, connection);
            adapter.InsertCommand = new System.Data.SqlClient.SqlCommand(sql, connection);
            adapter.InsertCommand.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
        }

    }
</script>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

     <h2><%: Title %>.</h2>
        <div>
            <h4>Add Record</h4>
        </div>
       <div>  
            <table class="auto-style1">  
                <tr>  
                    <td>Genius & Species   </td>  
                    <td>  
                        <asp:TextBox ID="Genus_Species" runat="server"></asp:TextBox> 
                    </td>  
  
               </tr>  
                <tr>  
                    <td>Common Name</td>  
                     <td> <asp:TextBox ID="Common_Name" runat="server"></asp:TextBox></td>  
                </tr>  
                <tr>  
                    <td>Subspecies</td>  
                    <td>  
                        <asp:TextBox ID="Subspecies" runat="server"></asp:TextBox>  
                    </td>  
                </tr>   
                <tr>  
                    <td>Population</td>  
                    <td>  
                        <asp:TextBox ID="Population" runat="server"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td>Continent</td>  
                    <td>  
                        <asp:TextBox ID="Continent" runat="server"></asp:TextBox>  
                    </td>  
                </tr> 
                <tr>  
                    <td>  
                        <asp:Button  ID="Submit" OnClick="AddAnimalRecord_Click" runat="server" Text="Submit" />  
                    </td>  
                </tr>  
            </table>  
        </div>  

</asp:Content>
   
