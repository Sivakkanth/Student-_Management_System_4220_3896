using Assignment.Viewmodel;
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
using Assignment.Respositories;
using Microsoft.EntityFrameworkCore;
using Assignment.Model;

namespace Assignment.Views
{
    /// <summary>
    /// Interaction logic for ResetWindow.xaml
    /// </summary>
    public partial class ResetWindow : Window
    {
        public ResetWindow()
        {
            DataContext = new Loginviewmodel();
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
            using (var dbContext = new RespositoryBase())
            {
                var users = dbContext.Users.ToList();
                bool userFound = false;
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
                    MessageBox.Show("Invalid username.", "Forgot Password Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void studentre_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new RespositoryBase())
            {
                var users = context.Users.ToList();
                bool userFound = false;
                if (txtPassword.Text != null)
                {
                    foreach (var user in users)
                    {
                        if (user.Username == txtUser.Text)
                        {
                            if(user.Password != txtPassword.Text)
                            {
                                user.Password = txtPassword.Text;
                                context.SaveChanges();
                                MessageBox.Show("Password Reset successful", "Confirmation");
                                txtPassword.Clear();
                                txtUser.Clear();
                                userFound = true;
                                break;
                            }
                            if (user.Password == txtPassword.Text)
                            {
                                MessageBox.Show("This Password already exists, Enter New Password for Reset", "Confirmation");
                                userFound = true;
                            }
                        }
                    }
                }
                if (!userFound)
                {
                    MessageBox.Show("Username Not Found", "Confirmation");
                }
                if (txtPassword.Text == null)
                {
                    MessageBox.Show("Enter New Password for Reset", "Confirmation");
                }
            }
        }
    }
}
