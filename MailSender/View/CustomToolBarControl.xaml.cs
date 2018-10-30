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
    /// <summary>
    /// Логика взаимодействия для CustomTabControl.xaml
    /// </summary>
    public partial class CustomTabControl : UserControl
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

        static CustomTabControl()
        {
            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CustomTabControl));
            ItemsSourceProperty = DependencyProperty.Register(
                "ItemsSource",
                typeof(ObservableCollection<Sender>), typeof(CustomTabControl));
        }

        public CustomTabControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnAddButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OnDeleteButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OnEditButtonPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
