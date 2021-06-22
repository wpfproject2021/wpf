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
    /// Interaction logic for addB.xaml
    /// </summary>
    public partial class addB : Window
    {
        public addB()
        {
            InitializeComponent();
            

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void namebook_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void ADDb_Click(object sender, RoutedEventArgs e)
        {
            if (namebook.Text == string.Empty || writer1.Text == String.Empty)
            {
                MessageBox.Show("field ha ra vared kon");
            }
            else
            {
                string name = namebook.Text;
                string writer = writer1.Text;
                int num = 1;
                bool loan = false;
                Book book = new Book(name, writer, num, loan);
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\FatemehUni\projectWPF\db\book.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                command = "insert into bookinfo values('" + name.Trim() + "','" + writer.Trim() + "','" + num + "','" + loan + "')";
                SqlCommand com = new SqlCommand(command, con);
                com.BeginExecuteNonQuery();
                con.Close();
                MessageBox.Show("ketab ezafe shod");
                namebook.Text = String.Empty;
                writer1.Text = String.Empty;
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
