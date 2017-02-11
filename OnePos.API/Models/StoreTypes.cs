using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace OnePos.API.Models
{
    public class StoreTypes
    {
        public int stroretypeid { get; set; }
        public string storetypename { get; set; }
        public string storetypedescription { get; set; }
    }

    public class StoreTypeResponse
    {
        public List<StoreTypes> storetypes { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }
}