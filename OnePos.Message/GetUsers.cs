using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnePos.Framework.ServiceModel;
using OnePos.Message.Model;

namespace OnePos.Message
{
    public class GetUsersRequest : Request
    {
       public Guid UserID { get; set; } 
    }

    public class GetUsersResponse : Response
    {
        public IList<User> Users { get; set; }
    }
}
