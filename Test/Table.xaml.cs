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
    /// Логика взаимодействия для Table.xaml
    /// </summary>
    public partial class Table : Window
    {
        UserContext db;
        ResultContext db1;
        string login;
        List<Result> list;
       
      
        public void Put()
        {
            Label[,] labels = new Label[,] {
                { lb10, lb11, lb12, lb13 },
                { lb20, lb21, lb22, lb23 },
                { lb30, lb31, lb32, lb33 },
                { lb40, lb41, lb42, lb43 },
                { lb50, lb51, lb52, lb53 },
                { lb60, lb61, lb62, lb63 },
                { lb70, lb71, lb72, lb73 },
                { lb80, lb81, lb82, lb83 },
                { lb90, lb91, lb92, lb93 },
                { lb100, lb101, lb102, lb103 }};

            for(int i=0;i<10;i++)
            {
                labels[i, 0].Content = (i + 1).ToString();
                labels[i, 1].Content = list[i].Login;
                labels[i, 2].Content = list[i].Valid;
                labels[i, 3].Content = list[i].Time;
            }
        }
        public Table(string login)
        {
            InitializeComponent();
            this.login = login;

            db = new UserContext();   
            db.Users.Load();

            db1 = new ResultContext();
            db1.Results.Load();

            Top10();

            Put();


        }
        public void Top10()
        {
            list = new List<Result>();
            var tmp = db1.Results.OrderByDescending(x => x.Valid.Length).ThenBy(x => x.Time).ToList();
            list.AddRange(tmp.Where(x => x.Valid == "10"));
            list.AddRange(tmp.Where(x => x.Valid != "10").OrderByDescending(x => x.Valid).ThenBy(x => x.Time));

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main tmp = new Main(login);
            this.Hide();
            tmp.Show();
        }
    }
}
