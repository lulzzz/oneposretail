using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace OnePos.API.Models
{


    public class ProductAPIRequest
    {
        public Guid id { get; set; }
        public byte[] image { get; set; }
        public string color { get; set; }
        public bool isactive { get; set; }
        public bool isdeleted { get; set; }
        public string name { get; set; }
        public int pricemethod { get; set; }
        public bool promptforprice { get; set; }

        public bool isgiftcard { get; set; }
        public double priceperunitofweight { get; set; }

        public bool useweightpricing { get; set; }
        public double unitofweightsize { get; set; }

        public bool countsassalesrevenue { get; set; }

        public double price { get; set; }

        public bool removeatzerocount { get; set; }

        public bool isagerestrict { get; set; }

        public bool isdisplayonbilling { get; set; }

        public string metaproductdata { get; set; }

        public long downtick { get; set; }
        public int maxfloorqty { get; set; }

        public int menuposition { get; set; }

        public string sku { get; set; }
        public string plu { get; set; }

        public string upc { get; set; }

        public string longname { get; set; }

        public int caloriecount { get; set; }

        public Guid storeid { get; set; }

        //public Guid recipeid { get; set; }

        public Guid revenuetypeid { get; set; }

        // public Guid orderedrecipeid { get; set; }

        public Guid surchargegroupid { get; set; }

        public Guid productgroupprinterid { get; set; }

        public Guid taxgroupid { get; set; }

        public Guid inclusivetiprateid { get; set; }
    }

    public class ProductAPIResponse
    {
        public string productid { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }

    public class ProductAPIListResponse
    {
        public IList<ProductAPIRequest> productsList { get; set; }
        public string statusMessage { get; set; }
        public HttpStatusCode statusCode { get; set; }
    }

    public class SingleEntityorA11APIRequest
    {
        public string ID { get; set; }
    }

}

