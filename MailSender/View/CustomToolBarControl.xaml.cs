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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.View
{
    public partial class CustomToolBarControl : UserControl
    {
        public static DependencyProperty TextProperty;
        public static DependencyProperty ItemsSourceProperty;

        public event EventHandler OnAddButtonPressed;
        public event EventHandler OnDeleteButtonPressed;
        public event EventHandler OnEditButtonPressed;

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public ObservableCollection<Sender> ItemsSource
        {
            get => GetValue(ItemsSourceProperty) as ObservableCollection<Sender>;
            set => SetValue(ItemsSourceProperty, value);
        }

        static CustomToolBarControl()
        {
            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CustomToolBarControl));
            ItemsSourceProperty = DependencyProperty.Register(
                "ItemsSource",
                typeof(ObservableCollection<Sender>), typeof(CustomToolBarControl));
        }

        public CustomToolBarControl()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            OnAddButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            OnDeleteButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            OnEditButtonPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
