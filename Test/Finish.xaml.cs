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
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для Finish.xaml
    /// </summary>
    public partial class Finish : System.Windows.Window
    {
        private User user;
        UserContext db;
        ResultContext db2;
        private void GetUser(string login)
        {
            db = new UserContext();
            db.Users.Load();
            user = db.Users.First(x => x.Login == login);
        }
        public Finish(string login,string time1,int tr)
        {
            InitializeComponent();
            GetUser(login);
            time.Content += time1;
            valid.Content += tr.ToString() + " из 10";
            db2 = new ResultContext();
            db2.Results.Add(new Result(user.Login, time1, tr.ToString()));
            db2.SaveChanges();

        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
                App.Current.Shutdown(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main tmp = new Main(user.Login);
            Hide();
            tmp.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var application = new Microsoft.Office.Interop.Word.Application();
            Document document = application.Documents.Add();
            Microsoft.Office.Interop.Word.Paragraph tableParagrap =document.Paragraphs.Add();
            tableParagrap.Range.Text = "Отчет";
            Range tableRange = tableParagrap.Range;
            Microsoft.Office.Interop.Word.Table priceTable =
            document.Tables.Add(tableRange, 2,3);
            priceTable.Borders.InsideLineStyle = priceTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            Microsoft.Office.Interop.Word.Range cellRange;
            cellRange = priceTable.Cell(1, 1).Range;
            cellRange.Text = "Логин";
            cellRange = priceTable.Cell(1, 2).Range;
            cellRange.Text = "Правильные ответы";
            cellRange = priceTable.Cell(1, 3).Range;
            cellRange.Text = "Время";
            cellRange = priceTable.Cell(2, 1).Range;
            cellRange.Text = user.Login;
            cellRange = priceTable.Cell(3, 2).Range;
            cellRange.Text = valid.Content.ToString(); 
            cellRange = priceTable.Cell(3, 3).Range;
            cellRange.Text = time.Content.ToString();
            try
            {
                document.Save();
                document.Close();
            }
            catch (Exception)
            {

            }
            
        }
    }
}
