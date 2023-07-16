using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Model
{
    public class Admin
    {
        [Key]
        public int UserID
        {
            get; set;
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
