Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.Text
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Script.Serialization
Imports System.ServiceModel.Activation
Imports System.ServiceModel.Web
Imports System.Web.Script.Services

<ServiceContract()> _
<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)> _
Public Class Service
    <OperationContract()> _
    <WebInvoke(Method:="POST", ResponseFormat:=WebMessageFormat.Json)> _
    Public Function GetCustomers(ByVal prefix As String) As String
        Dim customers As New List(Of Object)()
        Using conn As New SqlConnection()
            conn.ConnectionString = ConfigurationManager.ConnectionStrings("constr").ConnectionString
            Using cmd As New SqlCommand()
                cmd.CommandText = "select ContactName, CustomerId from Customers where " & _
                    "ContactName like @prefix + '%'"
                cmd.Parameters.AddWithValue("@prefix", prefix)
                cmd.Connection = conn
                conn.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        customers.Add(New With { _
                         Key .Id = sdr("CustomerId"), _
                         Key .Name = sdr("ContactName") _
                        })
                    End While
                End Using
                conn.Close()
            End Using
            Return (New JavaScriptSerializer().Serialize(customers))
        End Using
    End Function
End Class
