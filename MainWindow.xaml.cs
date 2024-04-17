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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;


namespace pls_work
{
    
    public partial class MainWindow : Window
    {

        string searchtext;
        string searchquery;
        string query;
        string ID;
        SQLiteConnection con;
        string CmdString = string.Empty;
        FilWindow fil = new FilWindow();
        HelpWindow help = new HelpWindow();
        

        public MainWindow()
        {
            InitializeComponent();
            imgButton.Visibility = Visibility.Hidden;
            browButton.Visibility = Visibility.Hidden;
            VideoButton.Visibility = Visibility.Hidden;
            db_connection();
            FillDataGrid();
        }

        private void db_connection()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            string ConString = "Data Source=|DataDirectory|\\dbtest.db";
            con = new SQLiteConnection(ConString);
            con.Open();
        }

        private void FillDataGrid()

        {
            string CmdString = string.Empty;
            CmdString = "SELECT Id, Topic, Authors, [Last Author], Publisher, Year FROM primaryinfo";
            SQLiteCommand cmd = new SQLiteCommand(CmdString, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable("testdatatable1");
            sda.Fill(dt);
            datagrid1.ItemsSource = dt.DefaultView;
        }

        private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        {

            searchtext = search_box.Text;
            query = "SELECT Id";
            query = fil.constructQuery(query, searchtext);

            query += " FROM primaryinfo WHERE";
            query += " Id LIKE '%" + searchtext + "%'" + fil.searchcriteria(searchquery, searchtext); 

            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable("testdatatable2");
            sda.Fill(dt);
            datagrid1.ItemsSource = dt.DefaultView;

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView _drv;
            try
            {
                _drv = datagrid1.SelectedItems[0] as DataRowView;
                if (_drv != null && _drv["Id"] != null && !String.IsNullOrEmpty(Convert.ToString(_drv["Id"])))
                {
                    ID = Convert.ToString(_drv["Id"]);
                    //MessageBox.Show(id);
                    Fill_description(ID);
                }
                else { ID = null; }
            }
            catch { ID = null; }
            finally { _drv = null; }
        }

        string executequery(string cmd)
        {
            SQLiteCommand command = new SQLiteCommand(CmdString, con);
            return (string)command.ExecuteScalar();

        }

        private void Fill_description(string id)
        {
            imgButton.Visibility = Visibility.Visible;
            browButton.Visibility = Visibility.Visible;
            VideoButton.Visibility = Visibility.Hidden;
            

            CmdString = "SELECT Topic FROM primaryinfo WHERE Id ="+'"'+ id +'"';
            TitleBlock.Text = executequery(CmdString);

            CmdString = "SELECT Year || ' - ' || Authors from primaryinfo WHERE Id =" + '"' + id + '"';
            AuthorBlock.Text = executequery(CmdString);

            CmdString = "SELECT Desc from secondaryinfo WHERE Id=" + '"' + id + '"';
            DescriptionBlock.Text = executequery(CmdString);

            //Fill_link(id);
            //MessageBox.Show("before " + ID);
            enableVidButon(id);
            //MessageBox.Show("after " + ID);
        }

        private void Fill_link(string id)
        {

            CmdString = "SELECT Link FROM secondaryinfo where Id=" + '"' + id + '"';
            string url = executequery(CmdString);

            LinkBlock.Inlines.Clear();
            //LinkBlock.Inlines.Add("Some text ");
            Hyperlink hyperLink = new Hyperlink()
            {
                NavigateUri = new Uri(url)
            };
            hyperLink.Inlines.Add("Click here");
            hyperLink.RequestNavigate += Hyperlink_RequestNavigate;
            LinkBlock.Inlines.Add(hyperLink);
            LinkBlock.Inlines.Add(" to go to the paper");

        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", e.Uri.ToString());
        }

        private void imgButtonClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(ID);
            imgWindow picture = new imgWindow(ID);
            picture.Owner = this;
            picture.Show();
        }

        private void FilButtonClick(object sender, RoutedEventArgs e)
        {
            fil.Owner = this;
            fil.Show();
        }
        
        private void HelpButtonClick(object sender, RoutedEventArgs e)
        {
            help.Owner = this;
            help.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        public void updategrid(string query2)
        {
            SQLiteCommand cmd = new SQLiteCommand(query2, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable("testdatatable3");
            sda.Fill(dt);
            datagrid1.ItemsSource = dt.DefaultView;
        }

        private void Browser_Click(object sender, RoutedEventArgs e)
        {
            CmdString = "SELECT Link FROM secondaryinfo where Id=" + '"' + ID + '"';
            string url = executequery(CmdString);
            System.Diagnostics.Process.Start("explorer", url);
        }

        private void enableVidButon(string id)
        {
            CmdString = "SELECT VideoLink FROM secondaryinfo where Id=" + '"' + id + '"';

            //string url = "";
            //var url;
            //MessageBox.Show("enable vid button before " + ID);

            SQLiteCommand command = new SQLiteCommand(CmdString, con);
            var url = command.ExecuteScalar();

            //object url = executequery(CmdString); //Convert.ToString(executequery(CmdString));
            //MessageBox.Show("enable vid button after query execute " + ID);
            
            if(url != DBNull.Value)
            {
                VideoButton.Visibility = Visibility.Visible;
            }

            

            /*
            if (url != "")
            {
                VideoButton.Visibility = Visibility.Visible;
            }
            */

            //MessageBox.Show("enable vid button end " + ID);
        }

        private void Video_Click(object sender, RoutedEventArgs e)
        {
            CmdString = "SELECT VideoLink FROM secondaryinfo where Id=" + '"' + ID + '"';

            string url = executequery(CmdString);
            //MessageBox.Show(url1);
            System.Diagnostics.Process.Start("explorer", url);
        }

    }
}