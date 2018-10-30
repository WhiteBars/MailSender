using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib
{
    public class DataAccessServiceFormDB : IDataAccessService
    {
        private RecipientsDataContext _DBContext;

        public DataAccessServiceFormDB()
        {
            _DBContext = new RecipientsDataContext();
        }

        public int CreateRecipient(Recipient recipient)
        {
            _DBContext.Recipient.InsertOnSubmit(recipient);
            _DBContext.SubmitChanges();
            return recipient.Id;
        }

        public ObservableCollection<Recipient> GetRecipients() => new ObservableCollection<Recipient>(_DBContext.Recipient.ToArray());
    }
}
