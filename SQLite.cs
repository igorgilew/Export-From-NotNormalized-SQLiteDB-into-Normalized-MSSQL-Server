using System;
using System.Data.SQLite;

namespace Vhodnoi
{
    class SQLite
    {
        string database;
        SQLiteCommand query;
        SQLiteConnection connection;
        SQLiteDataReader reader;
        
        public SQLite()
        {
            database = Environment.CurrentDirectory + "\\notNormalized.sqlite";
            connection = new SQLiteConnection(string.Format("Data Source={0}", database));
            connection.Open();
        }
        //чтение данных
        public SQLiteDataReader ReadData(string query)
        {

            this.query = new SQLiteCommand(query, connection);
            reader = this.query.ExecuteReader();
            return reader;

        }
        //запись данных
        public void WriteData(string query)
        {
            this.query = new SQLiteCommand(query, connection);
            this.query.ExecuteNonQuery();

            //Close();
        }
        //закрытие подключения
        public void Close()
        {
            connection.Close();
        }
    }
}