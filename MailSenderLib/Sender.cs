using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib
{
    /// <summary>
    /// Я думаю, комментарии излишни)
    /// </summary>
    public class Sender
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public Sender(string name, string email, string pass)
        {
            (Name, Email, Password) = (name, email, pass);
        }
    }
}
