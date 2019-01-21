using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    [WebMethod]
    public static List<ListItem> GetCustomers()
    {
        string query = "SELECT CustomerId, Name FROM Customers";
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                List<ListItem> customers = new List<ListItem>();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(new ListItem
                        {
                            Value = sdr["CustomerId"].ToString(),
                            Text = sdr["Name"].ToString()
                        });
                    }
                }
                con.Close();
                return customers;
            }
        }
    }
}