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
    /// Логика взаимодействия для Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        private User user;
        UserContext db;
        public Start(string login)
        {
            InitializeComponent();
            db = new UserContext();
            db.Users.Load();
            user = db.Users.First(x => x.Login == login);
        }

       

     
        private void Go(int id)
        {
            Passage tmp = new Passage(user.Login,id);
            tmp.Show();
            Hide();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Go(1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Go(2);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Go(3);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Main tmp = new Main(user.Login);
            tmp.Show();
            Hide();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Go(4);
        }
    }
}
