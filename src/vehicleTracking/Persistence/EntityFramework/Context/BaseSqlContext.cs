using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFramework.Context
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

            // 196 197 199 201
            Car carOne = new Car { Id = 1, NumberPlate = 196, UserId = 1 };
            Car carTwo = new Car { Id = 2, NumberPlate = 201, UserId = 1 };
            Car carFour = new Car { Id = 3, NumberPlate = 197, UserId = 2 };
            Car carThree = new Car { Id = 4, NumberPlate = 199, UserId = 2 };
            modelBuilder.Entity<Car>().HasData(carOne, carTwo, carThree, carFour);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}