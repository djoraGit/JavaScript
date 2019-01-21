
Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Data.SqlClient
Partial Class VB
    Inherits System.Web.UI.Page

    <WebMethod()> _
    Public Shared Function GetCustomers() As List(Of ListItem)
        Dim query As String = "SELECT CustomerId, Name FROM Customers"
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)
                Dim customers As New List(Of ListItem)()
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        customers.Add(New ListItem() With { _
                          .Value = sdr("CustomerId").ToString(), _
                          .Text = sdr("Name").ToString() _
                        })
                    End While
                End Using
                con.Close()
                Return customers
            End Using
        End Using
    End Function
End Class
