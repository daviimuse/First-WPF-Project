using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MySql.Data.MySqlClient;

namespace First_WPF_Project
{
    class connection
    {
        private MySqlConnection conn;
        private string server;
        private string usrn;
        private string psw;
        private string db;

        public connection(){
            Initialize();
        }

        private void Initialize(){
            server = "localhost";
            usrn = "root";
            psw = "password";
            db = "wpf_logindb";
            string connectionString;
            connectionString = "Data Source=" + server + ";Database =" + db + ";User Id=" + usrn + ";Password=" + psw + ";SSL Mode=0";
            conn = new MySqlConnection(connectionString);
        }

        public bool OpenConnection(){
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        MessageBox.Show("Couldn't connect to server!");
                        break;
                    case 1:
                        MessageBox.Show("Invalid username or password, please try again!");
                        break;
                }
                return false;
            }
        }

        public void closeConnection(){
            this.conn.Close();
        }

        public MySqlConnection get_connection(){
            return this.conn;
        }
    }
}
