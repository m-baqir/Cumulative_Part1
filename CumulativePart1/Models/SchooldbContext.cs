using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CumulativePart1.Models
{
    public class SchooldbContext
    {
        //private database properties to connect to it
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "schooldb"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //more credentials to connect to database
        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password
                    + "; convert zero datetime = True";
            }
        }
        
        //method used to get the database
        public MySqlConnection AccessDatabase()
        {
            //create a new mysqlconnection class to create an object
            return new MySqlConnection(ConnectionString);
        }
    }
}