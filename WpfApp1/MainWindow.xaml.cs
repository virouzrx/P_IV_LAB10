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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UserList.ItemsSource = users;
        }

        private ObservableCollection<User> users = new ObservableCollection<User>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var count = 1;
            if (users.Any())
            {
                count = users.Max(x => x.Id + 1);
            }

            users.Add(new User(count, $"login{count}", $"password{count}", 0));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (users.Any())
            {
                var user = users[0];
                user.Points += 100;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (users.Any())
            {
                users.RemoveAt(0);
            }
        }
    }
}
