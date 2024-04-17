using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
//using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Drawing;

namespace pls_work
{
    /// <summary>
    /// Interaction logic for imgWindow.xaml
    /// </summary>
    public partial class imgWindow : Window
    {
        public string id;
        SQLiteConnection con;
        string CmdString = string.Empty;
        
        public imgWindow(String ID) : base()
        {
            InitializeComponent();
            id = ID;
            db_connection();
            showImg();
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

        byte[] executequery(string cmd)
        {
            SQLiteCommand command = new SQLiteCommand(CmdString, con);
            return command.ExecuteScalar() as byte[];
        }

        private void showImg ()
        {
            byte[] binaryData;
            try
            {
                CmdString = "SELECT Image FROM secondaryinfo WHERE id=" + '"' + id + '"';
                if(executequery(CmdString)==null)
                {
                    imgBlock.Text = "Whoops we couldn't find any pictures for that paper. Try checking out the actual paper.";
                }
                else
                {
                    binaryData = executequery(CmdString);
                    img1.Source = executeimg(binaryData);
                    
                    CmdString = "SELECT Image2 FROM secondaryinfo WHERE id=" + '"' + id + '"' ;
                    binaryData = executequery(CmdString);
                    img2.Source = executeimg(binaryData);

                    CmdString = "SELECT Image3 FROM secondaryinfo WHERE id=" + '"' + id + '"';
                    binaryData = executequery(CmdString);
                    img3.Source = executeimg(binaryData);
                }

            }
            catch
            {
                
            }
        }

        private BitmapImage executeimg(byte[] binaryData)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.EndInit();
            return bi;
        }

    }
}