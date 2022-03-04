using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SQL.Context
{
    public class BaseSqlContext : DbContext
    {
        public BaseSqlContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            // 5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8 => password
            User userOne = new User() { Id = 1, FullName = "User One", Username = "userone", PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8" };
            User userTwo = new User() { Id = 2, FullName = "User Two", Username = "usertwo", PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8" };
            modelBuilder.Entity<User>().HasData(userOne, userTwo);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}