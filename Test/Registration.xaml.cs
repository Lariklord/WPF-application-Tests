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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        UserContext db;
        public Registration()
        {
            InitializeComponent();
            db = new UserContext();
            db.Users.Load();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Escape)
            {
                MainWindow mainWindow = new MainWindow();
                Hide();
                mainWindow.Show();
            }
        }

       

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }
        private bool CheckData(string name,string surname,string login,string password)
        {
            if(name.Equals("") || surname.Equals("") || login.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Не все поля заполнены");
                return false;
            }
            if(db.Users.Where(x => x.Login == login).Count() != 0)
            {
                MessageBox.Show("Логин " + login + " уже занят");
                LbLogin.Text = "";
                return false;
            }
            return true;
                

        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            if(CheckData(LbName.Text,LbSurname.Text,LbLogin.Text,LbPassword.Password))
            {
                db.Users.Add(new User(LbName.Text, LbSurname.Text, LbLogin.Text, LbPassword.Password));
                db.SaveChanges();
                MessageBox.Show("Аккаунт успешно создан");
                Hide();
                MainWindow tmp = new MainWindow();
                tmp.Show();       
            }
        }
    }
}
