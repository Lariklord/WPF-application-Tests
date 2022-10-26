using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для Passage.xaml
    /// </summary>
    public partial class Passage : Window
    {
        DispatcherTimer timer;
        private User user;
        UserContext db;
        int min = 0;
        int sec = 0;
        TectContext db1;
        List<Tect> list;
        bool IsCheck = false;
        Tect tect;
        int tr = 0;
        int quest = 0;

        private void Time()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private void GetQuest(int id)
        {
            db1 = new TectContext();
            db1.Tects.Load();
            if (id == 4)
            {
                list = db1.Tects.ToList();
            }
            else
            {
                list = db1.Tects.Where(x => x.Kind == id).ToList();
            }

        }
        private void GetUser(string login)
        {
            db = new UserContext();
            db.Users.Load();
            user = db.Users.First(x => x.Login == login);
        }
        public Passage(string login,int id)
        {
            InitializeComponent();
            GetUser(login);
            Time();
            GetQuest(id);
            Update();
           
        }
        private Tect GetRand()
        {
            Random rand = new Random();
            return list[rand.Next(0, list.Count)];
        }
        private void RandPos()
        {
            List<string> tmp = new List<string> { tect.Answer1,tect.Answer2,tect.Answer3,tect.Answer4 };
            List<Button> btns = new List<Button> { bt1, bt2, bt3, bt4 };
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                int num = rand.Next(0, tmp.Count);
                btns[i].Content = tmp[num];
                tmp.RemoveAt(num);
            }
            
        }
        private void UpdateButtons()
        {

            lb1.Text = tect.Question;
            RandPos();
            bt1.Background = new SolidColorBrush(Colors.White);
            bt2.Background = new SolidColorBrush(Colors.White);
            bt3.Background = new SolidColorBrush(Colors.White);
            bt4.Background = new SolidColorBrush(Colors.White);
            skip.IsEnabled = true;
            if(tect.Img!="")
            {
                img.Source = new BitmapImage(new Uri("img/"+tect.Img, UriKind.Relative));
                img.Visibility =Visibility.Visible;
            }
            else
            {
                img.Visibility = Visibility.Hidden;
            }

        }
        private void Update()
        {
            if (quest == 10)
            {
                Finish tmp = new Finish(user.Login,Title,tr);
                timer.Stop();
                tmp.Show();
                Close();
                
            }
            tect = GetRand();
            list.Remove(tect);
            UpdateButtons();
        }
        private void check(Button bt,Tect tect)
        {
            if (bt.Content.ToString() == tect.Valid)
            {
                bt.Background = new SolidColorBrush(Colors.Green);
                tr++;
            }
            else
            {
                bt.Background = new SolidColorBrush(Colors.Red);
            }
            IsCheck = true;
            btNext.IsEnabled = true;
            skip.IsEnabled = false;

        }
        void timer_Tick(object sender,EventArgs e)
        {
            if(min==5 && sec>0)
            {
                return;
            }
            if(min==5)
            {
                MessageBox.Show("Время вышло :(");
                Main tmp = new Main(user.Login);
                timer.Stop();
                Hide();
                tmp.Show();
                
            }
            if(sec==59)
            {
                sec = 0;
                min++;
            }
            else
            {
                sec++;
            }
            if(sec<10)
            {
                Title = "0" + min + ":" + "0" + sec;
            }
            else
            {
                Title = "0" + min + ":" + sec;
            }
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            if (IsCheck)
                return;
            else
                check(bt1, tect);
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            if (IsCheck)
                return;
            else
                check(bt2, tect);
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            if (IsCheck)
                return;
            else
                check(bt3, tect);
        }

        private void bt4_Click(object sender, RoutedEventArgs e)
        {
            if (IsCheck)
                return;
            else
                check(bt4, tect);
        }

        private void btNext_Click(object sender, RoutedEventArgs e)
        {
            quest++;
            Update();
            btNext.IsEnabled = false;
            IsCheck = false;
            this.UpdateLayout();
            
        }

        private void skip_Click(object sender, RoutedEventArgs e)
        {
            quest++;
            Update();
            this.UpdateLayout();
        }
    }
}
