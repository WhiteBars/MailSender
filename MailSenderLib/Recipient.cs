using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MailSenderLib
{
    public partial class Recipient : IDataErrorInfo
    {
        private readonly Regex _EmailRegex = new Regex(@"/^([a-z0-9_\.-]+)@([a-z0-9_\.-]+)\.([a-z\.]{2,6})$/");
        private readonly Regex _NameRegex = new Regex(@"^[_a-zA-Z0-9а-яА-Я ]+$");

        public string this[string columnName]
        {
            get
            {
                string err = string.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (Name is null) Name = "";
                        if (!_NameRegex.IsMatch(Name))
                        {
                            err = "Имя не может содержать цифры";
                        }
                        break;
                    case "Email":
                        if (Email is null) Email = "";
                        if (!_EmailRegex.IsMatch(Email))
                        {
                            err = "Неверный формат email";
                        }
                        break;
                }
                return err;
            }
        }

        public string Error => throw new NotImplementedException();
    }
}
