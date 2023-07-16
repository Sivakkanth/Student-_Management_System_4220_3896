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
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            DataContext = new Loginviewmodel();
            DataContext=new Studentviewmodel();
            DataContext = new Adminviewmodel();
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(Object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var forregisterWindow = new FOrRegisterLoginWindow();
            forregisterWindow.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new RespositoryBase())
            {
                var users = dbContext.Users.ToList();
                var students = dbContext.Students.ToList();
                var admins = dbContext.Admins.ToList();

                bool userFound = false;
                bool studentFound = false;
                bool adminFound = false;

                foreach (var user in users)
                {
                    if (user.Username == txtUser.Text && user.Password == txtPassword.Password)
                    {
                        var uDW = new MainWindow();
                        uDW.Show();

                        this.Close();
                        userFound = true;
                        break;
                    }
                }

                if (!userFound)
                {
                    foreach (var student in students)
                    {
                        if (student.Username == txtUser.Text && student.Password == txtPassword.Password)
                        {
                            var sWV = new StudentWindow();
                            sWV.Show();

                            this.Close();
                            studentFound = true;
                            return;
                        }
                    }
                }

                if(!studentFound)
                {
                    foreach(var admin in admins)
                    {
                        if(admin.Username == txtUser.Text && admin.Password == txtPassword.Password)
                        {
                            var aWV = new AdminWindow();
                            aWV.Show();
                            this.Close();
                            adminFound = true;
                            return;
                        }
                    }
                }
                
                if (!userFound && !studentFound && !adminFound)
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var forget = new ForgetWindow();
            forget.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var reset = new ForResetWindow();
            reset.Show();
            this.Close();
        }
    }
}