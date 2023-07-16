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
using Assignment.Respositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Views
{
    /// <summary>
    /// Interaction logic for ForgotStaffWindow.xaml
    /// </summary>
    public partial class ForgetWindow : Window
    {
        public ForgetWindow()
        {
            DataContext=new Loginviewmodel();
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

        private void studentf_Click(object sender, RoutedEventArgs e)
        {
            using(var dbContext = new RespositoryBase())
            {
                var users = dbContext.Users.ToList();
                var students = dbContext.Students.ToList();
                var admins = dbContext.Admins.ToList();

                bool userFound = false;
                bool studentFound = false;
                bool adminFound = false;

                foreach (var user in users)
                {
                    if (user.Username == txtUser.Text)
                    {
                        txtPassword.Text = user.Password;
                        userFound = true;
                        break;
                    }
                }

                if (!userFound)
                {
                    foreach (var student in students)
                    {
                        if (student.Username == txtUser.Text)
                        {
                            txtPassword.Text = student.Password;
                            studentFound = true;
                            return;
                        }
                    }
                }

                if (!studentFound)
                {
                    foreach (var admin in admins)
                    {
                        if (admin.Username == txtUser.Text)
                        {
                            txtPassword.Text = admin.Password;
                            adminFound = true;
                            return;
                        }
                    }
                }

                if (!userFound && !studentFound && !adminFound)
                {
                    MessageBox.Show("Invalid username.", "Forgot Password Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
