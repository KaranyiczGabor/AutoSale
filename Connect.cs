using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSale
{
    public class Connect
    {
        public MySqlConnection Connection;
        private string Host;
        private string Database;
        private string Username;
        private string Password;
        private string ConnectionString;

        public Connect()
        {
            Host = "127.0.0.1";
            Database = "Autook";
            Username = "root";
            Password = "";

            ConnectionString = "SERVER=" + Host + ";DATABASE=" + Database + ";UID=" + Username + ";PASSWORD=" + Password + ";SslMode=None";

            Connection = new MySqlConnection(ConnectionString);

        }
    }
}
