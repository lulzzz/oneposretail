using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace OnePos.MessageService
{
    public interface IMessageServices
    {
        bool SendMessage(string title, string body, string receipents);
    }
}
