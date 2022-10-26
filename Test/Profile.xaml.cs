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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        private User user;
        UserContext db;
        public Profile(string login)
        {
            InitializeComponent();
            db = new UserContext();
            db.Users.Load();
            user = db.Users.First(x => x.Login == login);
            Set();
        }
        public void Set()
        {
            LbName.Content += " " + user.Name;
            LbSurname.Content += " " + user.Surname;
            LbLogin.Content += " " + user.Login;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main tmp = new Main(user.Login);
            Hide();
            tmp.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChangePassword tmp = new ChangePassword(user.Login);
            tmp.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
