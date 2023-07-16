using Assignment.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Respositories
{
    public class RespositoryBase : DbContext
    {
        
        public string path = @"C:\Users\sivak\Desktop\Assignment\usermodel.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={path}");
        }

        public DbSet<UserAccountModel> Users { get; set; }
        public DbSet<UserModel> Students { get; set; }
        public DbSet<Admin>Admins { get; set; }
    }
}