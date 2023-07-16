using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;
using System;
using System.Collections.Generic;
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
using Assignment.Viewmodel;
using Assignment.Respositories;

namespace Assignment.Views
{
    /// <summary>
    /// Interaction logic for FOrRegisterLoginWindow.xaml
    /// </summary>
    public partial class FOrRegisterLoginWindow : Window
    {
        public FOrRegisterLoginWindow()
        {
            DataContext = new Loginviewmodel();
            DataContext = new Adminviewmodel();
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
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new RespositoryBase())
            {
                var users = dbContext.Users.ToList();
                var admins = dbContext.Admins.ToList();

                bool userFound = false;
                bool adminFound = false;

                foreach (var user in users)
                {
                    if (user.Username == txtUser.Text && user.Password == txtPassword.Password)
                    {
                        var uDW = new ForStaffRegisterWindow();
                        uDW.Show();
                        this.Close();
                        userFound = true;
                        break;
                    }
                }

                if (!userFound)
                {
                    foreach (var admin in admins)
                    {
                        if (admin.Username == txtUser.Text && admin.Password == txtPassword.Password)
                        {
                            var aWV = new ForRegisterWindow();
                            aWV.Show();
                            this.Close();
                            adminFound = true;
                            return;
                        }
                    }
                }

                if (!userFound && !adminFound)
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void textUsername_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUser.Focus();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUser.Text) && txtUser.Text.Length > 0)
            {
                textUsername.Visibility = Visibility.Collapsed;
            }
            else
            {
                textUsername.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

    }
}
