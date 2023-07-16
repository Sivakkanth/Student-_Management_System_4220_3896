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

namespace Assignment.Views
{
    /// <summary>
    /// Interaction logic for ForRegisterWindow.xaml
    /// </summary>
    public partial class ForRegisterWindow : Window
    {
        public ForRegisterWindow()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void staffre_Click(object sender, RoutedEventArgs e)
        {
            var staffreg = new ForRegisterStaffWindow();
            staffreg.Show();
            this.Close();
        }

        private void studentre_Click(object sender, RoutedEventArgs e)
        {
            var studentreg = new RegisterWindow();
            studentreg.Show();
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}
