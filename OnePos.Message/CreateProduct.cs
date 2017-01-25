using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;

namespace OnePos.Message
{
    public class CreateProductRequest :Request
    {
        public Product Product { get; set; }
    }

    public class CreateProductResponse : Response
    {
        public Guid ProductId { get; set; }
    }
}
