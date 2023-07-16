using Assignment.Model;
using Assignment.Respositories;
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
    public partial class Studentviewmodel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<UserModel> userModels = new ObservableCollection<UserModel>();

        [ObservableProperty]
        public UserModel userList;

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

        [ObservableProperty]
        public UserModel selecteduser = null;

        public Studentviewmodel()
        {
            using (var context = new RespositoryBase())
            { 
                var y = context.Students.ToList();
                foreach (var x in y)
                {
                    userModels.Add(x);
                }
            }
        }

        [RelayCommand]
        public void CreateThestudent()
        {
            using (RespositoryBase context = new RespositoryBase())
            {
                var sName = Username;
                var sPassword = Password;
                var sTitle = Title;
                var sFirstname = Firstname;
                var sLastname = Lastname;
                var sCity = City;
                var sDistrict = District;
                var sGender = Gender;
                var sAddress = Address;
                var sEmail = Email;
                var sNIC = NIC;
                var sPhone = Phone;
                var sDateofBirth = Dateofbirth;

                if (sName != null && sPassword != null)
                {
                    context.Students.Add(new UserModel()
                    {
                        Username = sName,
                        Password = sPassword,
                        Title = sTitle,
                        Firstname = sFirstname,
                        Lastname = sLastname,
                        City = sCity,
                        District = sDistrict,
                        Gender = sGender,
                        Address = sAddress,
                        Email = sEmail,
                        NIC = sNIC,
                        Phone = sPhone,
                        Dateofbirth = sDateofBirth
                    });
                    context.SaveChanges();
                    MessageBox.Show("User create successful", "Confirmation");
                    //var x = new Sucessmsg();
                    //x.Show();
                }
                else
                {
                    MessageBox.Show("User create unsuccessful", "Confirmation");
                    //var y = new unsucess();
                    //y.Show();
                }
            }
        }

        [RelayCommand]
        public void DeleteTheUser()
        {
            using (var context = new RespositoryBase())
            {
                UserModel selectedUser = UserList as UserModel;
                if (selectedUser != null)
                {
                    UserModel user = context.Students.Single(x => x.Id == selectedUser.Id);
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
