using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Http;

namespace DeviceReg.WebApi.Utility
{
    public class ControllerUtility
    {
        public static IHttpActionResult Guard(Func<IHttpActionResult> function)
        {
            var returncode = HttpStatusCode.BadRequest;
            try
            {
                return function();
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(returncode)
                {
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(response);
            }
        }

        public static void SendMail(string to, string subject, string body)
        {
            const string sender = "deviceregsender@gmail.com";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 25);
            
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(sender, "Ichbineinpasswort");
            MailMessage mail = new MailMessage();

            mail.Subject = subject;
            mail.From = new MailAddress(sender, "DeviceReg");
            mail.To.Add(new MailAddress(to));
            mail.Body = body;
            smtpClient.Send(mail);
        }
    }
}