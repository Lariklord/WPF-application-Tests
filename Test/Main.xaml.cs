using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private string login;
        UserContext db;
        public Main(string login)
        {
            this.login = login;
            InitializeComponent();
            db = new UserContext();
            db.Users.Load();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Profile tmp = new Profile(login);
            Hide();
            tmp.Show();
        }
        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Start tmp = new Start(login);
            Hide();
            tmp.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Table table = new Table(login);
            this.Hide();
            table.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Spravka tmp = new Spravka(login);
            Hide();
            tmp.Show();

        }
    }
}
