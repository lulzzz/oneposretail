using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
namespace OnePos.API.Models
{
    public class StoreAPIRequest
    {
        public long id { get; set; }
        public string storename { get; set; }
        public string storeownername { get; set; }
        public string storeuniquekey { get; set; }
        public string storeaddress { get; set; }
        public string phonenumber { get; set; }
        public string licenseexpiry { get; set; } 
        public string emailid { get; set; }
        public string isactive { get; set; }
        public int storetypeid { get; set; }  
        public string storetypename { get; set; }
        public string StoreStatus { get; set; }
    }

    public class StoreAPIResponse
    {
        public long storeid { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }

    public class StoreListResponse
    {
        public IList<StoreAPIRequest> storesList { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }


}