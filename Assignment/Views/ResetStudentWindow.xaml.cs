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
    /// Interaction logic for ResetStudentWindow.xaml
    /// </summary>
    public partial class ResetStudentWindow : Window
    {
        public ResetStudentWindow()
        {
            DataContext = new Studentviewmodel();
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
                var students = dbContext.Students.ToList();
                bool userFound = false;
                foreach (var student in students)
                {
                    if (student.Username == txtUser.Text)
                    {
                        txtPassword.Text = student.Password;
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
                var students = context.Students.ToList();
                bool userFound = false;
                if (txtPassword.Text != null)
                {
                    foreach (var student in students)
                    {
                        if (student.Username == txtUser.Text)
                        {
                            if (student.Password != txtPassword.Text)
                            {
                                student.Password = txtPassword.Text;
                                context.SaveChanges();
                                MessageBox.Show("Password Reset successful", "Confirmation");
                                txtPassword.Clear();
                                txtUser.Clear();
                                userFound = true;
                                break;
                            }
                            if (student.Password == txtPassword.Text)
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