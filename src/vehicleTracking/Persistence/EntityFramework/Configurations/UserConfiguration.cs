/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFramework.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NumberPlate).IsRequired();
            builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId);
        }

        #endregion Methods
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();
        }

        #endregion Methods
    }
}