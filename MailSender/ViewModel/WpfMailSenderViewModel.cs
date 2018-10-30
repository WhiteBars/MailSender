using GalaSoft.MvvmLight;
using MailSenderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace MailSender.ViewModel
{
    public class WpfMailSenderViewModel : ViewModelBase
    {
        private readonly IDataAccessService _DataAccessService;

        private string _Title = "Заголовок окна";
        private Recipient _CurrentRecipient = new Recipient();

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        public ObservableCollection<Recipient> Recipients { get; private set; }

        public Recipient CurrentRecipient
        {
            get => _CurrentRecipient;
            set => Set(ref _CurrentRecipient, value);
        }

        public ICommand UpdateDataCommand { get; }
        public ICommand GoToEditViewCommand { get; }
        public ICommand UpdateRecipientCommand { get; }
        public ICommand CreateNewRecipietnCommand { get; }

        public ICommand TestCommand { get; }

        public WpfMailSenderViewModel(IDataAccessService dataAccessService)
        {
            _DataAccessService = dataAccessService;
            Recipients = _DataAccessService.GetRecipients();

            TestCommand = new RelayCommand(() => MessageBox.Show("Оно шевелится!"));

            UpdateDataCommand = new RelayCommand(UpdateData, CanUpdateData);
            GoToEditViewCommand = new RelayCommand(ToEditView, true);
            UpdateRecipientCommand = new RelayCommand<Recipient>(OnUpdateRecipientExecuted, UpdateRecipientCanExecute);
            CreateNewRecipietnCommand = new RelayCommand(OnCreateNewRecipientExecuted);
        }

        private bool CanUpdateData => true;

        private bool UpdateRecipientCanExecute(Recipient recipient) => recipient != null;

        private void ToEditView()
        {
            var dialog = new RecipientEditWindow();
            dialog.ShowDialog();
        }

        private void UpdateData()
        {
            Recipients = _DataAccessService.GetRecipients();
            RaisePropertyChanged(nameof(Recipients));
        }

        private void OnUpdateRecipientExecuted(Recipient recipient)
        {
            if (_DataAccessService.CreateRecipient(recipient) > 0)
                Recipients.Add(recipient);
        }

        private void OnCreateNewRecipientExecuted()
        {
            CurrentRecipient = new Recipient();
        }
    }
}
