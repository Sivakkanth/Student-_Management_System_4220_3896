using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Model
{
    public class UserAccountModel
    {
        [Key]
        public int UserID
        {
            get; set;
        }
        public string? Title
        {
            get;
            set;
        }
        public string? Firstname
        {
            get;
            set;
        }
        public string? Lastname
        {
            get;
            set;
        }
        public string? Gender
        {
            get;
            set;
        }
        public string? Address
        {
            get;
            set;
        }
        public string? City
        {
            get;
            set;
        }
        public string? District
        {
            get;
            set;
        }
        public string? Email
        {
            get;
            set;
        }
        public string? NIC
        {
            get;
            set;
        }
        public string? Phone
        {
            get;
            set;
        }
        public string? Dateofbirth
        {
            get;
            set;
        }
        public string? Username
        {
            get;
            set;
        }
        public string? Password
        {
            get;
            set;
        }
    }
}