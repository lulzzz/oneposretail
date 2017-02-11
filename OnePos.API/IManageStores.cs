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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IManageStores" in both code and config file together.
    [ServiceContract]
    public interface IManageStores
    { 

        [OperationContract]
        [WebInvoke(UriTemplate = "CreateStore/{ResponseFormat}", Method = "POST")]
        StoreAPIResponse CreateStore(string ResponseFormat, StoreAPIRequest storeInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateStore/{ResponseFormat}", Method = "POST")]
        StoreAPIResponse UpdateStore(string ResponseFormat, StoreAPIRequest storeInfo);


        [OperationContract]
        [WebGet(UriTemplate = "GetStores/{ResponseFormat}")]
        StoreListResponse GetStores(string ResponseFormat);

        [OperationContract]
        [WebGet(UriTemplate = "GetStoreTypes/{ResponseFormat}")]
        StoreTypeResponse GetStoreTypes(string ResponseFormat);


    }
}
