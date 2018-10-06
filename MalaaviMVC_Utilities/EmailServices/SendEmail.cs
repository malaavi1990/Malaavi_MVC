using System.Net.Mail;

namespace MalaaviMVC_Utilities.EmailServices
{
    public class SendEmail
    {
        public static void Send(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("malaavi1990@gmail.com", "فروشگاه اینترنتی آی شاپ");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("malaavi1990@gmail.com", "Ma1502552");
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);

        }
    }
}