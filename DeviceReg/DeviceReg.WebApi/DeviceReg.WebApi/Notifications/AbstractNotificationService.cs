using DeviceReg.Repositories;
using DeviceReg.WebApi.Notifications.Internal;
using DeviceReg.WebApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace DeviceReg.WebApi.Notifications
{
    public class AbstractNotificationService
    {
        private Regex placeholdersRegex = new Regex("{{(.+?)}}");

        public AbstractNotificationService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public UnitOfWork UnitOfWork { get; private set; }

        #region Send notification
        protected void SendNotificationAsync(NotificationMessage notificationMessage)
        {
            var lang = LanguageHelper.GetLangCode(notificationMessage.Receiver.Profile.Language);
            var subjectTemplate = UnitOfWork.TextResources.GetByName(notificationMessage.NotificationSubjectTemplateKey, lang);
            var textTemplate = UnitOfWork.TextResources.GetByName(notificationMessage.NotificationTextTemplateKey, lang);

            if (subjectTemplate == null)
            {
                throw new Exception("Notification subjectTemplate not found");
            }

            if (textTemplate == null)
            {
                throw new Exception("Notification textTemplate not found");
            }

            if (notificationMessage.Receiver == null)
            {
                throw new Exception("Notification receiver can't be null");
            }

            var subject = GetOutput(subjectTemplate.Text, notificationMessage.Parameters);
            var text = GetOutput(textTemplate.Text, notificationMessage.Parameters);

            var mail = CreateEmail(notificationMessage.Receiver.Email, subject, text);

            SendSmtpAsync(mail);
        }

        private string GetOutput(string templateText, Dictionary<string, string> parameters)
        {
            if (string.IsNullOrWhiteSpace(templateText))
            {
                return String.Empty;
            }

            string result = templateText;
            while (placeholdersRegex.IsMatch(result))
            {
                foreach (var item in parameters)
                {
                    result = result.Replace("{{" + item.Key + "}}", item.Value);
                }
            }

            return result;
        }

        #endregion

        #region Email

        protected MailMessage CreateEmail(string receiver, string subject, string message)
        {
            MailMessage mail = new MailMessage();

            if (receiver == null)
                return mail;

            try
            {

                mail = new MailMessage("EmailFrom@gmail.com", receiver, subject, message);

                mail.BodyEncoding = Encoding.UTF8;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.From = new MailAddress("EmailFrom@gmail.com", "from displayname");
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException || ex is ArgumentException || ex is FormatException)
                {

                }
            }

            return mail;
        }

        protected void SendSmtpAsync(MailMessage message)
        {
            if (message.To == null || message.To.Count == 0 || message.From == null || message.Subject == null || message.Body == null)
            {
                return;
            }


            Task.Run(() =>
            {
                SmtpClient smtpClient = new SmtpClient();
                try
                {
                    smtpClient.Send(message);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    message.Dispose();
                    smtpClient.Dispose();
                }
            });
        }


        #endregion
    }
}