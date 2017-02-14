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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IManageProducts" in both code and config file together.
    [ServiceContract]
    public interface IManageProducts
    {
        //[OperationContract]
        //void DoWork();

        [OperationContract]
        [WebInvoke(UriTemplate = "CreateProduct/{ResponseFormat}", Method = "POST")]
        ProductAPIResponse CreateProduct(string ResponseFormat, ProductAPIRequest storeInfo);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "UpdateProduct/{ResponseFormat}", Method = "POST")]
        //ProductAPIResponse UpdateStore(string ResponseFormat, ProductAPIRequest storeInfo);


        [OperationContract]
        [WebInvoke(UriTemplate = "GetProducts/{ResponseFormat}",Method = "POST")]
        ProductAPIListResponse GetProducts(string ResponseFormat, SingleEntityorA11APIRequest productInfo);

        //[OperationContract]
        //[WebGet(UriTemplate = "GetStoreTypes/{ResponseFormat}")]
        //StoreTypeResponse GetStoreTypes(string ResponseFormat);
    }
}
