using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;

namespace Vhodnoi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        public MainWindow()
        {
            InitializeComponent();
            Test();
        }
        private void BuildDgDocument()
        {
            var dgElems = new List<Document>();
            var sConn = new SqlServerConnector();
            var sCommand = sConn.SelectAllDoc();
            using (var reader = sCommand.ExecuteReader())
            {
                while(reader.Read())
                {
                    dgElems.Add(new Document(
                        (int)reader["id"], (string)reader["numDoc"], (DateTime)reader["dateOfEvent"], (string)reader["nameSud"],
                        (string)reader["sostavSud"], (string)reader["secretar"]
                        ));
                }
            }
            sConn.CloseConnection();
            if (dgElems.Count > 0)
            {
                dgDoc.ItemsSource = dgElems;
                dgDoc.ColumnWidth = DataGridLength.Auto;
            }
        }
        private void BuildDgIstci()
        {
            var dgElems = new List<Istci>();
            var sConn = new SqlServerConnector();
            var sCommand = sConn.SelectAllIst();
            using (var reader = sCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    dgElems.Add(new Istci(
                        (int)reader[0], (string)reader[1], (int)reader[2]
                        ));
                }
            }
            sConn.CloseConnection();
            if (dgElems.Count > 0)
            {
                dgIstci.ItemsSource = dgElems;
                dgIstci.ColumnWidth = DataGridLength.Auto;
            }
        }
        private void BuildDgPredstIst()
        {
            var dgElems = new List<PredstIst>();
            var sConn = new SqlServerConnector();
            var sCommand = sConn.SelectAllPredstIst();
            using (var reader = sCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    dgElems.Add(new PredstIst(
                        (int)reader[0], (string)reader[1], (string)reader[2], (int)reader[3]
                        ));
                }
            }
            sConn.CloseConnection();
            if (dgElems.Count > 0)
            {
                dgIstPr.ItemsSource = dgElems;
                dgIstPr.ColumnWidth = DataGridLength.Auto;
            }
        }
        private void BuildDgOtv()
        {
            var dgElems = new List<Otv>();
            var sConn = new SqlServerConnector();
            var sCommand = sConn.SelectAllOtv();
            using (var reader = sCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    dgElems.Add(new Otv(
                        (int)reader[0], (string)reader[1], (int)reader[2]
                        ));
                }
            }
            sConn.CloseConnection();
            if (dgElems.Count > 0)
            {
                dgOtv.ItemsSource = dgElems;
                dgOtv.ColumnWidth = DataGridLength.Auto;
            }
        }
        private void BuildDgTreb()
        {
            var dgElems = new List<Treb>();
            var sConn = new SqlServerConnector();
            var sCommand = sConn.SelectAllTreb();
            using (var reader = sCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    dgElems.Add(new Treb(
                        (int)reader[0], (string)reader[1],  (int)reader[2]
                        ));
                }
            }
            sConn.CloseConnection();
            if (dgElems.Count > 0)
            {
                dgTreb.ItemsSource = dgElems;
                dgTreb.ColumnWidth = DataGridLength.Auto;
            }
        }
        private void BuildDgOtvPredst()
        {
            var dgElems = new List<PredstOtv>();
            var sConn = new SqlServerConnector();
            var sCommand = sConn.SelectAllPredstOtv();
            using (var reader = sCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    dgElems.Add(new PredstOtv(
                        (int)reader[0], (string)reader[1], (string)reader[2], (int)reader[3]
                        ));
                }
            }
            sConn.CloseConnection();
            if (dgElems.Count > 0)
            {
                dgOtvPr.ItemsSource = dgElems;
                dgOtvPr.ColumnWidth = DataGridLength.Auto;
            }
        }
        public void ClearTables()
        {
            var sConn = new SqlServerConnector();
            var sCommand = sConn.ClearTables();
            sCommand.ExecuteNonQuery();            
            sConn.CloseConnection();
        }
        //заполнение таблицы "документ"
        private void FillDocument()
        {
            SQLite connection = new SQLite();
            SQLiteDataReader reader;         
            int idDoc;
            
            reader = connection.ReadData("Select distinct id_doc, date, nameSud, sostavSud, secretar from mainTable");
            while(reader.Read())
            {
                var sConn = new SqlServerConnector();
                var sCommand = sConn.AddDocument(reader.GetString(0), reader.GetDateTime(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                //после выполнения получаем айдишник
                idDoc = (int)sCommand.ExecuteScalar();                               
                sConn.CloseConnection();
                FillIstec(idDoc, reader.GetString(0));
                FillOtv(idDoc, reader.GetString(0));
                FillTrebovania(idDoc, reader.GetString(0));
            }
            reader.Close();
            connection.Close();
        }
        private void FillIstec(int idDoc, string docNum)
        {
            SQLite connection = new SQLite();
            SQLiteDataReader reader;
            int idIst;

            reader = connection.ReadData(string.Format("Select distinct istecName from mainTable where id_doc='{0}'", docNum));
            while(reader.Read())
            {
                var sConn = new SqlServerConnector();
                var sCommand = sConn.AddIstec(reader.GetString(0), idDoc);
                idIst = (int)sCommand.ExecuteScalar();              
                sConn.CloseConnection();
                FillPredstIstca(idIst, docNum, reader.GetString(0));
            }
            reader.Close();
            connection.Close();
        }
        private void FillPredstIstca(int idIst, string docNum, string istName)
        {
            SQLite connection = new SQLite();
            SQLiteDataReader reader;            

            reader = connection.ReadData(string.Format("Select distinct predstIstcaName, documentPredst from mainTable where id_doc='{0}' and istecName='{1}'", docNum, istName));
            while (reader.Read())
            {
                var sConn = new SqlServerConnector();
                var sCommand = sConn.AddPredstIst(reader.GetString(0), reader.GetString(1), idIst);
                sCommand.ExecuteNonQuery();
                
                sConn.CloseConnection();
            }
            reader.Close();
            connection.Close();
        }
        private void FillOtv(int idDoc, string docNum)
        {
            SQLite connection = new SQLite();
            SQLiteDataReader reader;
            int idOtv;

            reader = connection.ReadData(string.Format("Select distinct otvetchName from mainTable where id_doc='{0}'", docNum));
            while (reader.Read())
            {
                var sConn = new SqlServerConnector();
                var sCommand = sConn.AddOtv(reader.GetString(0), idDoc);
                idOtv = (int)sCommand.ExecuteScalar();
                sConn.CloseConnection();                
                FillPredstOtv(idOtv, docNum, reader.GetString(0));
            }
            reader.Close();
            connection.Close();
        }
        private void FillPredstOtv(int idOtv, string docNum, string otvName)
        {
            SQLite connection = new SQLite();
            SQLiteDataReader reader;

            reader = connection.ReadData(string.Format("Select distinct predstOtvetchName, documentPredstOtv from mainTable where id_doc='{0}' and otvetchName='{1}'", docNum, otvName));
            while (reader.Read())
            {
                var sConn = new SqlServerConnector();
                var sCommand = sConn.AddPredstOtv(reader.GetString(0), reader.GetString(1), idOtv);
                sCommand.ExecuteNonQuery();
                sConn.CloseConnection();
                
            }
            reader.Close();
            connection.Close();
        }
        private void FillTrebovania(int idDoc, string docNum)
        {
            SQLite connection = new SQLite();
            SQLiteDataReader reader;

            reader = connection.ReadData(string.Format("Select trebovanie from mainTable where id_doc='{0}'", docNum));
            while(reader.Read())
            {
                var sConn = new SqlServerConnector();
                var sCommand = sConn.AddTreb(reader.GetString(0), idDoc);
                sCommand.ExecuteNonQuery();      
                sConn.CloseConnection();                
            }
            reader.Close();
            connection.Close();
        }
        private void Test()
        {
            SQLite connection = new SQLite();
            SQLiteDataReader reader;
            var tabElems = new List<TableNotNormalized>();
            reader = connection.ReadData("Select * from mainTable");                      
            
            while (reader.Read())
            {
                tabElems.Add(new TableNotNormalized(
                    reader.GetInt32(0), reader.GetString(1), (reader.GetDateTime(2)), reader.GetString(3), reader.GetString(4), reader.GetString(5),
                    reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10),
                    reader.GetString(11), reader.GetString(12)
                    ));                                         
            }            
            reader.Close();
            connection.Close();
            if(tabElems.Count>0)
            {                             
                dataGrid.ItemsSource = tabElems;
                dataGrid.ColumnWidth = DataGridLength.Auto;
            }           
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Test();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            svNormilizedDB.Visibility = Visibility.Visible;
            ClearTables();
            FillDocument();
            BuildDgDocument();
            BuildDgIstci();
            BuildDgPredstIst();
            BuildDgOtv();
            BuildDgOtvPredst();
            BuildDgTreb();
        }
    }
}
