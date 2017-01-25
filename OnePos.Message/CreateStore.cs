using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;

namespace OnePos.Message
{
    public class CreateStoreRequest : Request
    {
        public Store Store { get; set; }
    }

    public class CreateStoreResponse : Response
    {
        public long StoreId { get; set; }
    }
}
