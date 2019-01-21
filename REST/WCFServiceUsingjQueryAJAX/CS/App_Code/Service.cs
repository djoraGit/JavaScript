using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.ServiceModel.Activation;

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class Service : IService
{
	public string GetCustomers(string prefix)
	{
        List<object> customers = new List<object>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select ContactName, CustomerId from Customers where " +
                "ContactName like @prefix + '%'";
                cmd.Parameters.AddWithValue("@prefix", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(new
                        {
                            Id = sdr["CustomerId"],
                            Name = sdr["ContactName"]
                        });
                    }
                }
                conn.Close();
            }
            return (new JavaScriptSerializer().Serialize(customers));
        }
    }
}
