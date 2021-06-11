using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Data.SqlClient;


namespace emtehani10
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "physic1";
            string writer = "me";
            int num = 2;
            bool loan = false;
            Book book = new Book(name, writer, num,loan);
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\FatemehUni\projectWPF\db\book.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command;
            command = "insret into bookinfo values('"+ name +"','"+ writer +"','"+ num +"','"+ loan +"')";
            // command = "select * from bookinfo";
            //SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            //DataTable data = new DataTable();
            //adapter.Fill(data);
            // for(int i=0;i<data.Rows.Count;i++)
            //{
            //    Console.WriteLine(data.Rows[i][2]);
            //}
            string x = "math";
            //command = "delete from bookinfo where name='"+x+"'";
            //command = "update bookinfo SET name='" + "geo" + "',writer='" + "ali" + "',loan='"+false+"' where name='"+"geo" +"'";
            SqlCommand com = new SqlCommand(command,con);
            com.BeginExecuteNonQuery();
            con.Close();
        }
    }

    interface Iinfo
    {
        void ChangeInfo();
        void ShowBook();

        void ShowBalance();
    }

    public class Book
    {
        public string name { get; set; }
        public string writer { get; set; }

        public bool loan { get; set; }

        public int number { get; set; }
        public int time { get; set; }


        public Book(string name, string writer, int number,bool loan)
        {
            this.name = name;
            this.writer = writer;
            this.number = number;
            this.loan = loan;
        }
    }

    class Member : Iinfo
    {
        List<Book> mybook = new List<Book>();

        int balance;

        public bool respiteBook { get; set; }

        public bool respiteCost { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public string phonenum { get; set; }

        public string password { get; set; }

        public Member(string name, string email, string phonenum, string password)
        {
            this.name = name;
            this.email = email;
            this.phonenum = phonenum;
            this.password = password;
            respiteBook = false;
            respiteCost = false;
        }

        public void ShowBook()
        {

        }

        public void AddBook(Book a)
        {

        }

        public void ReturnBook(Book a)
        {

        }

        public void FineBook()
        {

        }

        public void ShowBalance()
        {

        }

        public void IncrementBalance()
        {

        }

        public void ChangeInfo()
        {

        }
    }

    class Employee : Iinfo
    {
        public int balance { get; set; }

        public string name { get; set; }
        public string email { get; set; }

        public string phonenum { get; set; }

        public string password { get; set; }

        public void ShowBook()
        {

        }

        public void ChangeInfo()
        {

        }

        public void ShowBookLoan()
        {

        }

        public void ShowBooknNow()
        {

        }

        public void ShowMember()
        {

        }

        public void ShowMemberrespitebook()
        {

        }

        public void ShoMemberrespiteCost()
        {

        }

        public void SearchMember(Member a)
        {

        }

        public void ShowBalance()
        {

        }


    }

    class Boss
    {
        List<Employee> employees = new List<Employee>();
        List<Book> book = new List<Book>();

        int balance;

        public Boss(int balance)
        {
            this.balance = balance;
        }

        public void AddEmployee(Employee a)
        {

        }

        public void DelEmployee(Employee a)
        {

        }

        public void SettleMember(Employee a)
        {

        }

        public void AddBook(Book a)
        {

        }

        public void Showbalance()
        {

        }

        public void IncrementBalance()
        {

        }
    }
}
