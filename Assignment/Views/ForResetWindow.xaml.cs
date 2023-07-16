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
    /// Interaction logic for ForResetWindow.xaml
    /// </summary>
    public partial class ForResetWindow : Window
    {
        public ForResetWindow()
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
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var login = new LoginWindow();
            login.Show();
            this.Close();
        }
        private void staffre_Click(object sender, RoutedEventArgs e)
        {
            var a = new ResetWindow();
            a.Show();
            this.Close();
        }
        private void studentre_Click(object sender, RoutedEventArgs e)
        {
            var b = new ResetStudentWindow();
            b.Show();
            this.Close();
        }
    }
}