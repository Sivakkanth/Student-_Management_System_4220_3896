using Assignment.Respositories;
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
    /// Interaction logic for UpdateStudentMainWindow.xaml
    /// </summary>
    public partial class UpdateStudentMainWindow : Window
    {
        public UpdateStudentMainWindow()
        {
            InitializeComponent();
        }
        private void btnMinimize_Click(Object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            var a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void studentf_Click(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new RespositoryBase())
            {
                var users = dbContext.Students.ToList();
                bool userFound = false;

                foreach (var user in users)
                {
                    if (user.Firstname == txtUser.Text)
                    {
                        tit.Text = user.Title;
                        name.Text = user.Firstname;
                        lastname.Text = user.Lastname;
                        address.Text = user.Address;
                        city.Text = user.City;
                        district.Text = user.District;
                        email.Text = user.Email;
                        nic.Text = user.NIC;
                        phone.Text = user.Phone;
                        username.Text = user.Username;
                        password.Text = user.Password;
                        userFound = true;
                        break;
                    }
                }

                if (!userFound)
                {
                    MessageBox.Show("Invalid Firstname.", "Forgot Password Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var context = new RespositoryBase())
            {
                var users = context.Students.ToList();
                bool userFound = false;
                if (tit.Text != null && name != null && lastname != null && address != null && city != null && district != null && email != null && nic != null && phone != null && username != null && password != null)
                {
                    foreach (var user in users)
                    {
                        if (user.Firstname == txtUser.Text)
                        {
                            user.Title = tit.Text;
                            user.Firstname = name.Text;
                            user.Lastname = lastname.Text;
                            user.Address = address.Text;
                            user.City = city.Text;
                            user.District = district.Text;
                            user.Email = email.Text;
                            user.NIC = nic.Text;
                            user.Phone = phone.Text;
                            user.Username = username.Text;
                            user.Password = password.Text;
                            context.SaveChanges();
                            userFound = true;
                            MessageBox.Show("Password update successful", "Confirmation");
                            txtUser.Clear();
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
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter all details", "Confirmation");
                }
            }
        }
    }
}
