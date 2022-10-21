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
using MySql.Data.MySqlClient;


namespace First_WPF_Project
{
    public partial class MainWindow : Window
    {
        private string usrn, psw, sql;
        private connection conn = new connection();
        private MySqlCommand cmd;

        public MainWindow(){
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e){
            usrn = lUsrn.Text;
            psw = lPsw.Password;

            if(string.IsNullOrEmpty(usrn) || string.IsNullOrEmpty(psw)){
                MessageBox.Show("Username/password is empty! ");
            }else{
                sql = "SELECT * FROM wpf_logindb.userslogininfo WHERE usrn = '" + usrn + "' AND psw ='" + psw + "'";
                if(conn.OpenConnection() == true){
                    try{
                        cmd = new MySqlCommand(sql, conn.get_connection());
                        object a = cmd.ExecuteScalar();
                        if(a == null){
                            MessageBox.Show("Invalid username/password, please try again!");
                        }else{
                            Home home = new Home();
                            home.Show();
                            this.Close();
                        }
                    }catch(MySqlException ex){
                        MessageBox.Show("" + ex);
                    }
                }
            }
            lUsrn.Text = "";
            lPsw.Password = "";
            conn.closeConnection();
        }

        private void Close(object sender, RoutedEventArgs e){
            this.Close();
        }

        private void showReg(object sender, RoutedEventArgs e){
            Register regForm = new Register();
            regForm.Show();
            this.Close();
        }
    }
}
