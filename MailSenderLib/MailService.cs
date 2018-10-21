using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib
{
    ///<summary>Рассылка почты</summary>
    public class MailService
    {
        /// <summary>
        /// Метод, отправляющий письмо. Возвращает True, если письмо отправлено. False, если нет.
        /// </summary>
        /// <param name="user">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <param name="sub">Тема письма</param>
        /// <param name="body">Тело письма</param>
        /// <returns></returns>
        public bool SendMessage(string user, SecureString password, string sub, string body)
        {
            try
            {
                using (var email = new MailMessage(StaticClass.from, StaticClass.to) { Subject = sub, Body = body })
                {
                    using (var client = new SmtpClient(StaticClass.host, StaticClass.port) { EnableSsl = true,
                    Credentials = new NetworkCredential(user, password) })
                    {
                        client.Send(email);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
