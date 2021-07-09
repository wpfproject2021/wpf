using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for borrowbook.xaml
    /// </summary>
    public partial class borrowbook : Window
    {
        public string email;
        public borrowbook(string email)
        {
            InitializeComponent();
            this.email = email;
            
            //MessageBox.Show(email);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void borrow_Click(object sender, RoutedEventArgs e)
        {
           bool t1 =checkbook(namebook.Text, writer1.Text);
            bool t2 = checkborrow();
            if(t1==true && t2==true)
            {
                upbook(namebook.Text);
                addListbook(namebook.Text);
            }
           
        }

        public bool checkbook(string name, string writer)
        {
            List<Book1> a = new List<Book1>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command;
            command = "select * from book";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Book1 z = new Book1(data.Rows[i][0].ToString(),
                data.Rows[i][1].ToString(), Convert.ToInt32(data.Rows[i][2]), Convert.ToBoolean(data.Rows[i][3]));
                a.Add(z);
            }
            SqlCommand com = new SqlCommand(command, con);
            com.ExecuteNonQuery();
            con.Close();
            ////////////
            bool k = false;
            for (int i = 0; i < a.Count; i++)
            {
                if ((name== a[i].name.ToString()) && writer == a[i].writer.ToString() && a[i].borrow==false)
                {
                    

                    k = true;
                }
            }
            return k;
        }



        public bool checkborrow()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string command;
            command = "select * from bookList1";

            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            int x = 0;
            for(int i=0;i<data.Rows.Count;i++)
            {
                if(data.Rows[i][1]==email)
                {
                    x++;
                }
            }
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();
            if(x>5)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public void upbook(string name)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();
            string command1;
            bool f1 = false;
            bool f2 = true;
            command1 = "update book SET Borrowed='" + f2+ "' where Name='"+name+"'";
            
            SqlCommand com1 = new SqlCommand(command1, con1);

            com1.ExecuteNonQuery();
            con1.Close();
        }

        public int numlistbook()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string command;
            command = "select * from bookList1";

            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();
            return data.Rows.Count;
        }

        public void addListbook(string name)
        {
            SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con2.Open();
            string command2;
            int id = numlistbook() + 1;
            DateTime d = DateTime.Now;
            command2 = "insert into bookList1 values('" +id + "','"+ email+ "','"+name+"','"+d+"')";
            SqlCommand com2 = new SqlCommand(command2, con2);
            com2.ExecuteNonQuery();
            con2.Close();
        }

        public bool checktime()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string command;
            command = "select * from bookList1";

            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);

            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();
            return true;
        }
    }

    public class Book1
    {
        public string name { get; set; }
        public string writer { get; set; }

        public bool borrow { get; set; }

        public int number { get; set; }
        public int time { get; set; }


        public Book1(string name, string writer, int number, bool borrow)
        {
            this.name = name;
            this.writer = writer;
            this.number = number;
            this.borrow = borrow;
        }
    }
}
