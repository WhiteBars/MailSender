using MailSenderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MailService mailService;

        public MainWindow()
        {
            InitializeComponent();
            SendButton.Click += SendButton_Click;
        }

        void ShowResDialog(string res)
        {
            var dialog = new SendComplieteDialog(res) { Owner = this };
            dialog.ShowDialog();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            mailService = new MailService();
            if(mailService.SendMessage(userTextBox.Text, passwordBox.SecurePassword, subjectTextBox.Text, bodyTextBox.Text))
            {
                ShowResDialog("Почта отправлена");
            }
            else
            {
                ShowResDialog("Ошибка при отправлении почты!");
            }
        }
    }
}
