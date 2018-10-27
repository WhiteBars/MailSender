using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// Свойство, хранящее логин пользователя
        /// </summary>
        private string Login { get; set; }
        /// <summary>
        /// Свойство, хранящее пароль пользователя
        /// </summary>
        private string Password { get; set; }
        /// <summary>
        /// Поле, хранящее сервер, через который будет осуществляться отправка писем
        /// </summary>
        private string serverAddress = "smtp.yandex.ru";
        /// <summary>
        /// Поле, которое хранит порт для отправки писем
        /// </summary>
        private int port = 25;
        /// <summary>
        /// Поле, хранящее тело письма
        /// </summary>
        private string body;
        /// <summary>
        /// Свойство, которое задает значение полю body и так же возвращает его по требованию
        /// </summary>
        private string Body
        {
            get => body;
            set
            {
                //Если получено пустое тело письма, то ошибка
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Поле \"Тело письма\" не может быть пустым!");
                body = value;
            }
        }
        /// <summary>
        /// Свойство, которое хранит заголовок письма
        /// </summary>
        private string Subject { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="body">Тело письма</param>
        /// <param name="subject">Заголовок письма</param>
        public MailService(string login, string password, string body, string subject)
        {
            (Login, Password) = (login, password);
            (Body, Subject) = (body, subject);
        }
        /// <summary>
        /// Переопределенный констуктор, дополнительно принимающий адрес сервера и порт
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="body">Тело письма</param>
        /// <param name="subject">Заголовок письма</param>
        /// <param name="addr">Адрес сервера</param>
        /// <param name="port">Порт сервера</param>
        public MailService(string login, string password, string body, string subject, string addr, int port) : 
           this(login, password, body, subject)
        {
            (serverAddress, this.port) = (addr, port);
        }
        /// <summary>
        /// Метод, осуществляющий отправку писем
        /// </summary>
        /// <param name="to">Кому</param>
        /// <param name="from">От кого</param>
        public void SendMail(string to, string from)
        {
            try
            {
                using (var message = new MailMessage(from, to)
                {
                    Subject = Subject,
                    Body = Body,
                    IsBodyHtml = false
                })
                {
                    using (var client = new SmtpClient(serverAddress, port)
                    {
                        EnableSsl = true,
                        Credentials = new NetworkCredential(Login, Password)
                    })
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception error)
            {
                //Если была ошибка, то записать в лог и выбросить ошибку
                Trace.WriteLine(error.ToString());
                throw new InvalidOperationException("Ошибка отправки почты", error);
            }
        }
    }
}
