using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;

namespace OnePos.Message
{
    public class GetProductsRequest : Request
    {
        public Guid ProductID { get; set; }
    }

    public class GetproductsResponse : Response
    {
        public IList<Product> Products { get; set; }
    }
}
