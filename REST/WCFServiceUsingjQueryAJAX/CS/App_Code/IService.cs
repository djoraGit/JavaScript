using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

[ServiceContract]
public interface IService
{
	[OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    string GetCustomers(string prefix);
}
