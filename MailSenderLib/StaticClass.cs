using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib
{
    /// <summary>
    /// Класс, содержащий статические переменные
    /// </summary>
    public static class StaticClass
    {
        /// <summary>
        /// Адресант
        /// </summary>
        public static readonly string from = "Enter email here";
        /// <summary>
        /// Адресат
        /// </summary>
        public static readonly string to = "Enter email here";
        /// <summary>
        /// Хост для отправки
        /// </summary>
        public static readonly string host = "Enter host here";
        /// <summary>
        /// Порт для отрпавки
        /// </summary>
        public static readonly int port = 25;
    }
}
