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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IManageTaxes" in both code and config file together.
    [ServiceContract]
    public interface IManageTaxes
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "CreateTaxConfiguration/{ResponseFormat}", Method = "POST")]
        TaxConfigurationAPIResponse CreateTaxConfiguration(string ResponseFormat, TaxConfigurationAPIRequest taxconfigurationinfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateTaxConfiguration/{ResponseFormat}", Method = "POST")]
        TaxConfigurationAPIResponse UpdateTaxConfiguration(string ResponseFormat, TaxConfigurationAPIRequest taxconfigurationinfo);


        [OperationContract]
        [WebGet(UriTemplate = "GetTaxConfigurations/{ResponseFormat}")]
        TaxConfigurationAPIListResponse GetTaxConfigurations(string ResponseFormat);

        [OperationContract]
        [WebGet(UriTemplate = "GetTaxGroups/{ResponseFormat}")]
        TaxGroupAPIListResponse GetTaxGroups(string ResponseFormat);

        [OperationContract]
        [WebInvoke(UriTemplate = "CreateTaxGroup/{ResponseFormat}", Method = "POST")]
        TaxGroupAPIResponse CreateTaxGroup(string ResponseFormat, TaxGroupAPIRequest taxgroupinfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateTaxGroup/{ResponseFormat}", Method = "POST")]
        TaxGroupAPIResponse UpdateTaxGroup(string ResponseFormat, TaxGroupAPIRequest taxgroupinfo);


        [OperationContract]
        [WebInvoke(UriTemplate = "GetSingleTaxGroup/{ResponseFormat}", Method = "POST")]
        SingleTaxGroupAPIListResponse GetSingleTaxGroup(string ResponseFormat, Guid ID);

    }
}
