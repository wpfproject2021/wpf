using System;
using System.Collections.Generic;

namespace emtehani10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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


        public Book(string name, string writer,int number)
        {
            this.name = name;
            this.writer = writer;
            this.number = number;
        }
    }

    class Member:Iinfo
    {
        List<Book> mybook = new List<Book>();

        int balance;

       public  bool respiteBook { get; set; }

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

    class Employee:Iinfo
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
