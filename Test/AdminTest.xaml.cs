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
    /// Логика взаимодействия для AdminTest.xaml
    /// </summary>
    public partial class AdminTest : Window
    {
        TectContext db;
        UserContext db1;
        public AdminTest()
        {
            InitializeComponent();
            db = new TectContext();
            db.Tects.Load();
            testGrid.ItemsSource = db.Tects.Local.ToBindingList();

            db1 = new UserContext();
            db1.Users.Load();
            userGrid.ItemsSource = db1.Users.Local.ToBindingList();

        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            db.Dispose();
            db1.Dispose();
            MainWindow tmp = new MainWindow();
            Hide();
            tmp.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            db1.SaveChanges();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (userGrid.IsEnabled == false)
            {
                if (testGrid.Items.Count > 0)
                {
                    for (int i = 0; i < testGrid.SelectedItems.Count; i++)
                    {
                        Tect test = testGrid.SelectedItems[i] as Tect;
                        if (test != null)
                        {
                            db.Tects.Remove(test);
                        }
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                if (userGrid.Items.Count > 0)
                {
                    for (int i = 0; i < userGrid.SelectedItems.Count; i++)
                    {
                        User user = userGrid.SelectedItems[i] as User;
                        if (user != null)
                        {
                            db1.Users.Remove(user);
                        }
                    }
                    db1.SaveChanges();
                }
            }
        }



        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            testGrid.IsEnabled = true;
            testGrid.Visibility = Visibility.Visible;

            userGrid.IsEnabled = false;
            userGrid.Visibility = Visibility.Hidden;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            userGrid.IsEnabled = true;
            userGrid.Visibility = Visibility.Visible;

            testGrid.IsEnabled = false;
            testGrid.Visibility = Visibility.Hidden;
        }
    }
}
