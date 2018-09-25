using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Vhodnoi
{
    class SqlServerConnector
    {
        SqlConnection conn;
        public SqlServerConnector()
        {
            var sConnStr = new SqlConnectionStringBuilder()
            {
                DataSource = @"STARK-ПК\SQLEXPRESS",
                InitialCatalog = "NormalizedDB",
                IntegratedSecurity = true
            }.ConnectionString;

            conn = new SqlConnection(sConnStr);
        }
        public SqlCommand AddDocument(string numDoc, DateTime date, string nameSud, string sostavSud, string secretar)
        {
            conn.Open();
            var sCommand = new SqlCommand()
            {
                Connection = conn,
                CommandText = string.Format(
                    "INSERT INTO Document (numDoc, dateOfEvent, nameSud, sostavSud, secretar) OUTPUT inserted.id values('{0}', '{1}', '{2}', '{3}', '{4}') ",
                    numDoc, date, nameSud, sostavSud, secretar)
            };
            return sCommand;
        }
        public SqlCommand AddIstec(string name, int idDoc)
        {
            conn.Open();
            var sCommand = new SqlCommand()
            {
                Connection = conn,
                CommandText = string.Format(
                    "INSERT INTO Istci (name, idDoc) OUTPUT inserted.id values('{0}', '{1}')", name, idDoc)
            };
            return sCommand;
        }
        public SqlCommand AddPredstIst(string name, string document, int idIst)
        {
            conn.Open();
            var sCommand = new SqlCommand()
            {
                Connection = conn,
                CommandText = string.Format(
                    "INSERT INTO PredstIstca (name, document, idIst) values('{0}', '{1}', '{2}')", name, document, idIst)
            };
            return sCommand;
        }
        public SqlCommand AddOtv(string name, int idDoc)
        {
            conn.Open();
            var sCommand = new SqlCommand()
            {
                Connection = conn,
                CommandText = string.Format(
                    "INSERT INTO Otvetchiki (name, idDoc) OUTPUT inserted.id values('{0}', '{1}')", name, idDoc)
            };
            return sCommand;
        }
        public SqlCommand AddPredstOtv(string name, string document, int idOtv)
        {
            conn.Open();
            var sCommand = new SqlCommand()
            {
                Connection = conn,
                CommandText = string.Format(
                    "INSERT INTO PredstOtv (name, document, idOtv) values('{0}', '{1}', '{2}')", name, document, idOtv)
            };
            return sCommand;
        }
        public SqlCommand AddTreb(string text, int idDoc)
        {
            conn.Open();
            var sCommand = new SqlCommand()
            {
                Connection = conn,
                CommandText = string.Format(
                    "INSERT INTO Trebovania (txt, idDoc) values('{0}', '{1}')", text, idDoc)
            };
            return sCommand;
        }
        public SqlCommand SelectAllDoc()
        {
            conn.Open();
            var sCommand = new SqlCommand()
            {
                Connection = conn,
                CommandText = "Select * from Document"
            };
            return sCommand;
        }
        public SqlCommand SelectAllIst()
        {
            conn.Open();
            var sCommand = new SqlCommand()
            {
                Connection = conn,
                CommandText = "Select * from Istci"
            };
            return sCommand;
        }
        public SqlCommand SelectAllPredstIst()
        {
            conn.Open();
            var sCommand = new SqlCommand()
            {
                Connection = conn,
                CommandText = "Select * from PredstIstca"
            };
            return sCommand;
        }
        public SqlCommand SelectAllOtv()
        {
            conn.Open();
            var sCommand = new SqlCommand()
            {
                Connection = conn,
                CommandText = "Select * from Otvetchiki"
            };
            return sCommand;
        }
        public SqlCommand SelectAllPredstOtv()
        {
            conn.Open();
            var sCommand = new SqlCommand()
            {
                Connection = conn,
                CommandText = "Select * from PredstOtv"
            };
            return sCommand;
        }
        public SqlCommand SelectAllTreb()
        {
            conn.Open();
            var sCommand = new SqlCommand()
            {
                Connection = conn,
                CommandText = "Select * from Trebovania"
            };
            return sCommand;
        }
        public SqlCommand ClearTables()
        {
            conn.Open();
            var sCommand = new SqlCommand()
            {
                Connection = conn,
                CommandText = "Delete from Document"
            };
            return sCommand;
        }
        public void CloseConnection()
        {
            conn.Close();
        }
    }
}
