using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Spravka.xaml
    /// </summary>
    public partial class Spravka : Window
    {
        string login;
        public Spravka(string login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Hide();
            Main tmp = new Main(login);
            tmp.Show();
        }
    }
}
