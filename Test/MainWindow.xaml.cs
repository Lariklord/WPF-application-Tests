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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        UserContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new UserContext();
            db.Users.Load();
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            Registration form = new Registration();
            this.Hide();
            form.Show();
        }

        private bool Check(string login,string password)
        {
            if(LbLogin.Text=="adm" && LbPassword.Password=="adm")
            {
                return true;
            }
            if(LbLogin.Text.Equals("") || LbPassword.Password.Equals(""))
            {
                MessageBox.Show("Не все поля заполнены");
                return false;
            }
            if (db.Users.Where(x => x.Login == login && x.Password == password).Count() == 1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
                LbLogin.Text = "";
                LbPassword.Password = "";
                return false;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Check(LbLogin.Text,LbPassword.Password))
            {
                Hide();
                if (LbLogin.Text == "adm" && LbPassword.Password == "adm")
                {
                    AdminTest adminTest = new AdminTest();
                    adminTest.Show();
                }
                else
                {
                    Main tmp = new Main(LbLogin.Text);
                    tmp.Show();
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
