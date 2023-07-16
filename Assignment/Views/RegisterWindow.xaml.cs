using Microsoft.Data.SqlClient;
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
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            DataContext = new Studentviewmodel();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = new ForRegisterWindow();
            a.Show();
            this.Close();
        }
        private void btnMinimize_Click(Object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            name.Clear();
            lastname.Clear();
            address.Clear();
            city.Clear();
            district.Clear();
            email.Clear();
            nic.Clear();
            phone.Clear();
            username.Clear();
            password.Clear();
        }
    }
}