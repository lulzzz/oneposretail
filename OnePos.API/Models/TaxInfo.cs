using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace OnePos.API.Models
{
   
    public class TaxConfigurationAPIRequest
    {
        public bool alwaysruntax { get; set; }
        public bool isinclusivetax { get; set; }

        public DateTime? starttime { get; set; }
        public DateTime? endtime { get; set; }

        public bool runmonday { get; set; }
        public bool runtuesday { get; set; }
        public bool runwednesday { get; set; }
        public bool runthursday { get; set; }
        public bool runfriday { get; set; }
        public bool runsaturday { get; set; }
        public bool runsunday { get; set; }

        public decimal rate { get; set; }
        public bool isflatfee { get; set; }
        public decimal flatfee { get; set; }
        public Guid id { get; set; }
        public bool isdeleted { get; set; }
        public byte[] timestamp { get; set; }
        public string name { get; set; }
    }

    public class TaxConfigurationAPIResponse
    {
        public Guid taxconfigurationid { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }

    public class TaxConfigurationAPIListResponse
    {
        public IList<TaxConfigurationAPIRequest> taxconfigurationList { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }


    public class TaxGroupAPIRequest
    {
 
        public Guid id { get; set; }
        public bool isdeleted { get; set; }
        public byte[] timestamp { get; set; }
        public string name { get; set; }
        public List<TaxConfigurationAPIRequest> taxes { get; set; }
    }

    public class TaxGroupAPIResponse
    {
        public Guid  taxgroupid { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }

    public class TaxGroupAPIListResponse
    {
        public IList<TaxGroupAPIRequest> taxGroupList { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }


    public class SingleTaxGroupAPIListResponse
    {
        public TaxGroupAPIRequest taxGroup { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }



}