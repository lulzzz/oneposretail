using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel; 
using System.ServiceModel.Web;
using System.Net.Http;
using System.Threading.Tasks;
using OnePos.API.Models;
namespace OnePos.API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IManageProduct" in both code and config file together.
    [ServiceContract]
    public interface IManageProduct
    {
        [OperationContract]
        string DoWork();
    }
}
