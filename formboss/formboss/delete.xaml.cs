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
using System.Windows.Shapes;
using System.Collections;
using System.Data;
//using System.Data.SqlClient;
using System.IO;
using Microsoft.Data.SqlClient;


namespace formboss
{
    /// <summary>
    /// Interaction logic for delete.xaml
    /// </summary>
    public partial class delete : Window
    {
        public delete()
        {
            InitializeComponent();
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void deleteb_Click(object sender, RoutedEventArgs e)
        {
            //hame ketaha dar sql ra dar yek list zakhre kardam

            List<Book> a = new List<Book>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\FatemehUni\projectWPF\db\book.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command;            
            command = "select * from bookinfo";
            SqlDataAdapter adapter = new SqlDataAdapter(command,con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for(int i=0;i<data.Rows.Count;i++)
            {               
                Book z = new Book(data.Rows[i][0].ToString(),
                    data.Rows[i][1].ToString(), Convert.ToInt32(data.Rows[i][2]), Convert.ToBoolean(data.Rows[i][3]));
                a.Add(z);
            }
            SqlCommand com = new SqlCommand(command, con);
           // com.BeginExecuteNonQuery();
           // con.Close();
            ////////////
            bool k = false;
            for(int i=0;i<a.Count;i++)
            {
                if((namebook2.Text==a[i].name) && writer2.Text==a[i].writer)
                {
                    ///hazf ketab

                    k = true;
                    //SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\FatemehUni\projectWPF\db\book.mdf;Integrated Security=True;Connect Timeout=30");
                    //con1.Open();
                    string command1;
                    command1= "delete from bookinfo where name='" + a[i].name.Trim() + "'";

                    SqlCommand com1 = new SqlCommand(command1, con);
                    com1.BeginExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("hazf shod");
                    namebook2.Text = String.Empty;
                    writer2.Text = String.Empty;
                    
                    break;
                }
            }
            if(k==false)
            {
                MessageBox.Show("chenin ketabi vojood nadarad");
                namebook2.Text = String.Empty;
                writer2.Text = String.Empty;
            }
            
        }
        public class Book
        {
            public string name { get; set; }
            public string writer { get; set; }

            public bool loan { get; set; }

            public int number { get; set; }
            public int time { get; set; }


            public Book(string name, string writer, int number, bool loan)
            {
                this.name = name;
                this.writer = writer;
                this.number = number;
                this.loan = loan;
            }
        }
    }
}
