using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;

namespace OnePos.Message
{
    public class GetStoreDetailsRequest : Request
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UniqueKey { get; set; }

    }

    public class GetStoreDetailsResponse : Response
    {
        public Store StoreDetails { get; set; }
    }
}
