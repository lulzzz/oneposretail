using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;

namespace OnePos.Message
{
    public class GetStoresRequest : Request
    {
    }

    public class GetStoresResponse : Response
    {
        public IList<Store> Stores { get; set; }
    }
}
