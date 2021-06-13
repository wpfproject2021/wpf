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

namespace WpfFront
{
    /// <summary>
    /// Interaction logic for register.xaml
    /// </summary>
    public partial class register : Page
    {
        public register()
        {
            InitializeComponent();
        }

        //to close the page window
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Window win = (Window)this.Parent;
            win.Close();
        }
        private void register_Click(object sender, RoutedEventArgs e)
        {

        }
        private void signUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            //this.Content = m;
        }
    }
}
