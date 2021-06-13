using System;
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

namespace WpfFront
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
        }
    }
}
