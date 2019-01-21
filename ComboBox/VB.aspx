<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VB.aspx.vb" Inherits="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:DropDownList ID="ddlCustomers" runat="server">
    </asp:DropDownList>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: "POST",
                url: "VB.aspx/GetCustomers",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var ddlCustomers = $("[id*=ddlCustomers]");
                    ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
                    $.each(r.d, function () {
                        ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                    });
                }
            });
        });
    </script>
    </form>
</body>
</html>
