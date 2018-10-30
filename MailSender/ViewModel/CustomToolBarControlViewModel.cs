using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSenderLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MailSender.ViewModel
{
    public class CustomToolBarControlViewModel : UserControl
    {
        public static DependencyProperty TextProperty;
        public static DependencyProperty ItemsSourceProperty;
        /*
        public event EventHandler OnAddButtonPressed;
        public event EventHandler OnDeleteButtonPressed;
        public event EventHandler OnEditButtonPressed;
        */

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public CustomToolBarControlViewModel()
        {
            AddCommand = new RelayCommand(() => MessageBox.Show("Add"), true);
            DeleteCommand = new RelayCommand(() => MessageBox.Show("Delete"), true);
            EditCommand = new RelayCommand(() => MessageBox.Show("Edit"), true);
        }

        static CustomToolBarControlViewModel()
        {
            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextBlock));
            ItemsSourceProperty = DependencyProperty.Register(
                "ItemsSource",
                typeof(ObservableCollection<Sender>), typeof(ComboBox));
        }
    }
}
