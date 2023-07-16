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
using Assignment.Viewmodel;

namespace Assignment.Views
{
    /// <summary>
    /// Interaction logic for AdminWindow1.xaml
    /// </summary>
    public partial class AdminWindow1 : Window
    {
        public AdminWindow1()
        {
            DataContext = new Studentviewmodel();
            InitializeComponent();
        }
        private void btnMinimize_Click(Object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = new AdminWindow();
            a.Show();
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var c = new AStudentRegisterWindow();
            c.Show();
            this.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var d = new AdminWindow();
            d.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var f = new UpdateStudentWindow();
            f.Show();
            this.Close();
        }
    }
}
