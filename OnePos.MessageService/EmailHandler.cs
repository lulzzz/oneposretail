using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OnePos.MessageService
{
    public class EmailHandler : IMessageServices
    {
        public bool SendMessage(string title, string body, string receipents)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com"); 
            mail.From = new MailAddress("ufoodies@gmail.com");
            mail.To.Add(receipents);
            mail.Subject = title;
            mail.Body = body; 
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("ufoodies@gmail.com", "123456@2");
            SmtpServer.EnableSsl = true;  
            try
            {
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}
