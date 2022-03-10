/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityFramework.Context
{
    public class BaseSqlContext : DbContext
    {
        #region Constructors

        public BaseSqlContext(DbContextOptions options) : base(options)
        {
        }

        #endregion Constructors

        #region Properties

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        #endregion Properties

        #region Methods

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

        #endregion Methods
    }
}