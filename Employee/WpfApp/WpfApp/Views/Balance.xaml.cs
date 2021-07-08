using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for Balance.xaml
    /// </summary>
    public partial class Balance : UserControl
    {
        string email;
        string password;
        public string acc;
        public Balance() {
            InitializeComponent();
        }
        public Balance(string email, string pass)
        {
            this.email = email;
            this.password = pass;
            acc = Employee_Balance();
            DataContext = acc;
            InitializeComponent();
        }

        public string Employee_Balance()
        {
            EmployeeInfo info = Search_Employee(email, password);
            float balance = info._account;
            string s = $"Account Balance is: {balance}";
            return s;
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
    }
}
