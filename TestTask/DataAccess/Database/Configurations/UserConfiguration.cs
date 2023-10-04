using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.DataAccess.Enums;
using TestTask.DataAccess.Models;

namespace TestTask.DataAccess.Database.Configurations
{
    internal class UserConfiguration
        : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property<int>("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Status).IsRequired();

            builder.HasIndex(u => u.Status);

            builder.HasMany(u => u.Orders)
                   .WithOne(o => o.User)
                   .HasForeignKey(o => o.UserId)
                   .IsRequired();

            builder.HasData(
                new User[]
                {
                    new User { Id = 1, Email = "user1@gmail.com", Status = UserStatus.Active},
                    new User { Id = 2, Email = "user2@gmail.com", Status = UserStatus.Active},
                    new User { Id = 3, Email = "user3@gmail.com", Status = UserStatus.Active},
                    new User { Id = 4, Email = "user4@gmail.com", Status = UserStatus.Active},
                    new User { Id = 5, Email = "user5@gmail.com", Status = UserStatus.Inactive},
                    new User { Id = 6, Email = "user6@gmail.com", Status = UserStatus.Inactive},
                    new User { Id = 7, Email = "user7@gmail.com", Status = UserStatus.Active},
                });
        }
    }
}
