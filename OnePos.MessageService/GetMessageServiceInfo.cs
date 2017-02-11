using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePos.MessageService
{
    public class GetMessageServiceInfo
    {
        public IMessageServices GetMessageService(string MessageType)
        {
            switch (MessageType)
            {
                case "Email":
                    return new EmailHandler();
                case "SMS":
                    return new SMSHandler();

            }
            return new EmailHandler();
        }
    }
}
