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

namespace LAB_10
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserList.ItemsSource = _users;
            new FIleWatcher().Show();
        }
        private ObservableCollection<User> _users = new ObservableCollection<User>();
        private void AddButton(object sender, RoutedEventArgs e)
        {
            var counter = 1;
            if (_users.Any())
            {
                counter = _users.Max(x => x?.Id + 1 ?? 1);
            }
            _users.Add(new User(
                counter,
                $"login{counter}",
                $"password{counter}",
                0));
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            if (_users.Any())
            {
                var user = _users[0];
                user.Points += 100;
            }
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (_users.Any())
            {
                _users.RemoveAt(0);
            }
        }
    }
}
