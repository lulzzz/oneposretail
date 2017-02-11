using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;

namespace OnePos.Message
{
    public class CreateDatabaseConnectionRequest : Request
    {
        public int ConnectionId { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        public long StoreId { get; set; }
        public bool IsMainDB { get; set; }
    }

    public class CreateDatabaseConnectionResponse : Response
    {
        public long ConnectionId { get; set; }
    }
}
