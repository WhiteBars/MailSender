using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib
{
    /// <summary>База данных</summary>
    public class DataBase
    {
        /// <summary>
        /// Экземпляр класса RecipientsDataContext, созданного автоматически на основе БД
        /// </summary>
        private readonly RecipientsDataContext recipients = new RecipientsDataContext();
        /// <summary>
        /// Поле, хранящее рецепиентов. Берет данный из БД
        /// </summary>
        public IQueryable<Recipient> Recipients => recipients.Recipient;
    }
}
