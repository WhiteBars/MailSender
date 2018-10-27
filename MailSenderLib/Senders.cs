using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib
{
    /// <summary>
    /// См комментарий к Sender
    /// </summary>
    public class Senders
    {
        public static readonly ObservableCollection<Sender> Items =
            new ObservableCollection<Sender>(new[]
            {
                new Sender("Ivanov", "ivanov@server.org", "Password1"),
                new Sender("Petrov", "petrov@server.org", "Password2"),
                new Sender("Sidorov", "sidorov@server.org", "Password3"),
            });

        public static readonly Dictionary<string, int> Servers =
            new Dictionary<string, int>()
            {
                { "smtp.yandex.ru", 465 },
                { "smtp.mail.ru", 465 },
                { "smtp.google.com", 465 }
            };
    }
}
