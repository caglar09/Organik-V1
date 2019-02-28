using System.Net;
using System.Net.Mail;

namespace OrganikV1.Business.Concrete
{
    public class MailManager
    {

        public bool SendMail(string fromMail, string toMail, string Subject, string toMailName, string link)
        {
            try
            {
                MailMessage message = new MailMessage(fromMail, toMail)
                {
                    From = new MailAddress(fromMail, Subject),
                    To = { new MailAddress(toMail, toMailName) },
                    Body = "Merhaba sayın  " + toMailName + "" +
                          "" +
                          "" +
                          "" +
                          " hesabınızı aşağıdaki linke tıklayarak onaylayabilirsiniz.. " +
                          link + "Onaylamak İçin Linke tıklayınız.." +
                          "" +
                          "",
                    Subject = "Bu Mail Organik Urun Dünyası adına Gönderilmiştir.."
                };

                using (SmtpClient client = new SmtpClient())
                {
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Port = 587;
                    client.UseDefaultCredentials = false;
                    NetworkCredential nc = new NetworkCredential("infoorganik.09@gmail.com", "caglar1952");
                    client.Credentials = nc;
                    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    client.Send(message);
                }
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }

        }
    }
}
