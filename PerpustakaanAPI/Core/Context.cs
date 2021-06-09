using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PerpustakaanAPI.Entity.Tables;
using System;

namespace PerpustakaanAPI.Core
{
    public class Context : DbContext
    {
        public DbSet<MS_Books> Books { get; set; }
        public DbSet<MS_Status> Statuses { get; set; }
        public DbSet<MS_User> Users { get; set; }
        public DbSet<MS_UserRole> UserRoles { get; set; }
        public DbSet<MS_Category> Categories { get; set; }
        public DbSet<TR_Peminjaman> Peminjamans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
