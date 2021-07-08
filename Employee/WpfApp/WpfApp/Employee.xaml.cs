using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using WpfApp.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Page
    {
        string employeeEmail;
        string employeePass;
        public Employee(string email, string pass)
        {
            InitializeComponent();
            this.employeeEmail = email;
            this.employeePass = pass;
        }

        private void Show_Balance(object sender, RoutedEventArgs e)
        {
            //searches for the employee in the database
            //EmployeeInfo info = Search_Employee(employeeEmail, employeePass);
            //float balance = info._account;
            //MessageBox.Show($"Account Balance is: {balance}");
            DataContext = new BalanceViewModel();
        }

        private void Edit_Info(object sender, RoutedEventArgs e)
        {
            DataContext = new EditViewModel();
        }

        private void Book_List(object sender, RoutedEventArgs e)
        {
            DataContext = new BookListViewModel();
        }

        private void Available(object sender, RoutedEventArgs e)
        {
            DataContext = new AvailableViewModel();
        }

        private void Borrowed(object sender, RoutedEventArgs e)
        {
            DataContext = new BorrowedViewModel();
        }

        private void Member_List(object sender, RoutedEventArgs e)
        {
            DataContext = new MemberListViewModel();
        }


        private void Delayed_Return(object sender, RoutedEventArgs e)
        {
            DataContext = new DelayedReturnsViewModel();
        }

        private void Delayed_Pay(object sender, RoutedEventArgs e)
        {
            DataContext = new DelayedPayViewModel();
        }

        private void Member_status(object sender, RoutedEventArgs e)
        {
            DataContext = new MemberStatViewModel();
        }

        public EmployeeInfo Search_Employee(string email, string pass)
        {
            SqlConnection c = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP\wpf-project\WPF\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
            string command;
            command = "select * from EmployeeInfo";
            SqlDataAdapter adapter = new SqlDataAdapter(command, c);
            DataTable data = new DataTable();
            adapter.Fill(data);
            EmployeeInfo e;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if ((string)data.Rows[i][0] == email && (string)data.Rows[i][3] == pass)
                {
                    string employeeEmail = (string)data.Rows[i][0];
                    string firstName = (string)data.Rows[i][1];
                    string lastName = (string)data.Rows[i][2];
                    string employeePass = (string)data.Rows[i][3];
                    string phone = (string)data.Rows[i][4];
                    float balance = (float)data.Rows[i][5];
                    ImageSource photo = (ImageSource)data.Rows[i][5];
                    e = new EmployeeInfo(employeeEmail, firstName, lastName,
                        employeePass, phone, balance, photo);

                    SqlCommand cmd = new SqlCommand(command, c);
                    cmd.BeginExecuteNonQuery();
                    c.Close();
                    return e;
                }
            }

            c.Close();
            //if the employee was not found
            MessageBox.Show("User not found!");
            return null;
        }

        //exit page button
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            
        }
    }
    public class EmployeeInfo
    {
        public string _email;
        public string _firstName;
        public string _lastName;
        public string _password;
        public string _phone;
        public float _account;
        public ImageSource _img;
        public EmployeeInfo(string email, string firstName, string lastName, string pass,
                                string phone, float acc, ImageSource img = null)
        {
            this._email = email;
            this._firstName = firstName;
            this._lastName = lastName;
            this._password = pass;
            this._phone = phone;
            this._account = acc;
            this._img = img;

            SqlConnection con = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AP\wpf-project\WPF\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command;
            command = "insert into member values('" + _email.Trim() + "', '" + _firstName + "', '" + _lastName + "', " +
                "'" + _password.Trim() + "', '" + _phone.Trim() + "', '" + _account + "', '" + _img + "')";
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();
        }

    }
}
