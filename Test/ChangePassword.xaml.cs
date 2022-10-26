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
    /// Логика взаимодействия для ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        UserContext db;
        string login;
        User user;
        public ChangePassword(string login)
        {
            this.login = login;
            InitializeComponent();
            db = new UserContext();
            db.Users.Load();
            user = db.Users.First(x => x.Login == login);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Check())
            {
                var tmp = db.Users.Where(x => x.Password == LbPassword.Password).FirstOrDefault();
                tmp.Password = LbPassword1.Password;
                db.SaveChanges();
                MessageBox.Show("Пароль успешно изменен");
                Hide();
            }
        }
        private bool Check()
        {
            if(!LbPassword.Password.Equals(user.Password))
            {
                MessageBox.Show("Неверный пароль");
                return false;
            }
            if(LbPassword.Password.Equals("") || LbPassword1.Password.Equals("") || LbPassword2.Password.Equals(""))
            {
                MessageBox.Show("Не все поля заполнены");
                return false;
            }
            if (LbPassword.Password.Equals(LbPassword1.Password))
            {
                MessageBox.Show("Новый пароль совпадает со старым");
                return false;
            }
            if(!LbPassword1.Password.Equals(LbPassword2.Password))
            {
                MessageBox.Show("Несовпадение паролей");
                return false;
            }
            return true;
        }
    }
}
