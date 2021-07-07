using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Data;
using Microsoft.Data.SqlClient;

namespace WpfFront
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //to save the user status
        string stat;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //a method to check the validity of given information
        private bool valid(string user, string pass)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(user);

            if (pass.Length < 8)
            {
                MessageBox.Show("Your password is less than 8 characters.");
                return false;
            }
            if (!match.Success)
            {
                MessageBox.Show("Email format is incorrect");
                return true;
            }
            else
            {
                return true;
            }
        }
        private void register_Click(object sender, RoutedEventArgs e)
        {
            register r = new register();
            this.Content = r;
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            //first checks if the password and username are in valid format
            string userName = username.Text;
            string pass = password.Password;

            valid(userName, pass);
            //checks if the user exists
            bool exists = user_Exists(userName, pass);
            //checks the type of user: Admin, employee or member
            if (exists)
            {
                if (userName.ToLower() == "admin" && pass == "AdminLib123")
                {
                    //go to admin page
                }
                if (stat.ToLower() == "member")
                {

                }
                else
                {
                    //go to employees' page
                }
            }

        }


        //to remove the placeholder text after clicking
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }


        //search for a username in database
        public bool user_Exists(string username, string pass)
        {
            bool exists = false;

            SqlConnection c = 
                new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP\wpf-project\WPF\XAML\WpfFront\WpfFront\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
            string command;
            command = "select * from member";
            SqlDataAdapter adapter = new SqlDataAdapter(command,c);
            DataTable data = new DataTable();
            adapter.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                if ((string)data.Rows[i][2] == username && (string)data.Rows[i][4] == pass)
                {
                    exists = true;
                    //saves the status of the user
                    stat = (string)data.Rows[i][6];
                }
            }
            SqlCommand cmd = new SqlCommand(command, c);
            cmd.BeginExecuteNonQuery();
            c.Close();

            //check the value of exist variable
            if (exists)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Wrong Email Or Password!");
                return false;
            }
        }
    }
}
