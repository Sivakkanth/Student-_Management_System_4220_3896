using Assignment.Migrations;
using Assignment.Model;
using Assignment.Respositories;
using Assignment.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Assignment.Viewmodel
{
    public partial class Loginviewmodel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<UserAccountModel> userAccountModels = new ObservableCollection<UserAccountModel>();

        [ObservableProperty]
        public UserAccountModel userList;

        // Create data variables
        [ObservableProperty] // It will create a new property. So we change the VM class - partial class 
        public string? title;  // Nullable

        [ObservableProperty]
        public string? firstname;

        [ObservableProperty]
        public string? lastname;

        [ObservableProperty]
        public string? gender;

        [ObservableProperty]
        public string? address;

        [ObservableProperty]
        public string? city;

        [ObservableProperty]
        public string? district;

        [ObservableProperty]
        public string? email;

        [ObservableProperty]
        public string? nIC;

        [ObservableProperty]
        public string? phone;

        [ObservableProperty]
        public string? dateofbirth;

        [ObservableProperty]
        public string? username;

        [ObservableProperty]
        public string? password;

        public Loginviewmodel(UserAccountModel u1)
        {
            Title = u1.Title;
            Firstname = u1.Firstname;
            Lastname = u1.Lastname;
            Gender = u1.Gender;
            Address = u1.Address;
            City = u1.City;
            District = u1.District;
            Email = u1.Email;
            NIC = u1.NIC;
            Phone = u1.Phone;
            Dateofbirth = u1.Dateofbirth;
            Username = u1.Username;
            Password = u1.Password;
        }

        public Loginviewmodel()
        {
            using (var context = new RespositoryBase())
            {
                var z = context.Users.ToList();
                foreach (var x in z)
                {
                    UserAccountModels.Add(x);
                }
            }
        }

        [RelayCommand]
        public void CreateTheUser()
        {
            using (RespositoryBase context = new RespositoryBase())
            {
                var uTitle = Title;
                var uFirstname = Firstname;
                var uLastname = Lastname;
                var uGender = Gender;
                var uAddress = Address;
                var uCity = City;
                var uDistrict = District;
                var uEmail = Email;
                var uNIC = NIC;
                var uPhone = Phone;
                var uDateofbirth = Dateofbirth;
                var uName = Username;
                var uPassword = Password;

                if (uName != null && uPassword != null)
                {
                    if (uTitle == null)
                    {
                        MessageBox.Show("Please selected your title", "Confirmation");
                    }
                    else if (uFirstname == null)
                    {
                        MessageBox.Show("Please Enter your First Name", "Confirmation");
                    }
                    else if (uLastname == null)
                    {
                        MessageBox.Show("Please Enter your Last Name", "Confirmation");
                    }
                    else if (uAddress == null)
                    {
                        MessageBox.Show("Please Enter your Address", "Confirmation");
                    }
                    else if (uCity == null)
                    {
                        MessageBox.Show("Please Enter your City", "Confirmation");
                    }
                    else if (uDistrict == null)
                    {
                        MessageBox.Show("Please Enter your District", "Confirmation");
                    }
                    else if (uEmail == null)
                    {
                        MessageBox.Show("Please Enter your Email", "Confirmation");
                    }
                    else if (uNIC == null)
                    {
                        MessageBox.Show("Please Enter your NIC", "Confirmation");
                    }
                    else if (uPhone == null)
                    {
                        MessageBox.Show("Please Enter your Phone number", "Confirmation");
                    }
                    else
                    {
                        context.Users.Add(new UserAccountModel()
                        { Username = uName, Password = uPassword, Title = uTitle, Firstname = uFirstname, Lastname = uLastname, Gender = uGender, Address = uAddress, City = uCity, Dateofbirth = uDateofbirth, District = uDistrict, Email = uEmail, NIC = uNIC, Phone = uPhone });
                        context.SaveChanges();
                        MessageBox.Show("User create successful", "Confirmation");
                    }
                }
                else
                {
                    MessageBox.Show("User create unsuccessful", "Confirmation");
                }
            }

        }

        [RelayCommand]
        public void DeleteTheUser()
        {
            using (var context = new RespositoryBase())
            {
                UserAccountModel selectedUser = UserList as UserAccountModel;
                if (selectedUser != null)
                {
                    UserAccountModel user = context.Users.Single(x => x.UserID == selectedUser.UserID);
                    context.Remove(user);
                    context.SaveChanges();
                    MessageBox.Show("User delete successful", "Confirmation");
                }
                else
                {
                    MessageBox.Show("User delete unsuccessful", "Confirmation");
                }
            }
        }
    }
}