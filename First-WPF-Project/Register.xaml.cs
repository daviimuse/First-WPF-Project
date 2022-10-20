using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace First_WPF_Project
{
    public partial class Register : Window
    {
        private string name,surname,usrn, psw, sql;
        private connection conn = new connection();
        private MySqlCommand cmd;

        public Register()
        {
            InitializeComponent();
        }

        private void RegisterF(object sender, RoutedEventArgs e)
        {
            name = rName.Text;
            surname = rSurname.Text;
            usrn = rUsrn.Text;
            psw = rPsw.Password;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname)|| string.IsNullOrEmpty(usrn) || string.IsNullOrEmpty(psw))
            {
                MessageBox.Show("Empty value! ");
            }
            else
            {
                sql = "INSERT INTO `wpf_logindb`.`userslogininfo` (`name`, `surname`, `usrn`, `psw`) VALUES('"+ name +"', '"+surname+"', '"+usrn+"', '"+psw+"');";
                if (conn.OpenConnection() == true)
                {
                    try
                    {
                        cmd = new MySqlCommand(sql, conn.get_connection());
                        object a = cmd.ExecuteScalar();
                        if (a != null)
                        {
                            MessageBox.Show("Invalid operation, please try again!");
                        }
                        else
                        {
                            MessageBox.Show("User Registered!");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                }
            }
            rName.Text = "";
            rSurname.Text= "";
            rUsrn.Text = "";
            rPsw.Password = "";
            conn.closeConnection();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void showLog(object sender, RoutedEventArgs e)
        {
            MainWindow logForm = new MainWindow();
            logForm.Show();
            this.Close();
        }

    }
}
