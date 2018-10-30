using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib
{
    public interface IDataAccessService
    {
        ObservableCollection<Recipient> GetRecipients();
        int CreateRecipient(Recipient recipient);
    }    
}
