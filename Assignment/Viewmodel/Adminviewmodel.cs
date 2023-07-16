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
    public partial class Adminviewmodel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Admin> admins = new ObservableCollection<Admin>();

        [ObservableProperty]
        public string? username;

        [ObservableProperty]
        public string? password;
    }
}
