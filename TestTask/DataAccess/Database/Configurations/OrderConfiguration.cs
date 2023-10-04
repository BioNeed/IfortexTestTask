using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TestTask.DataAccess.Models;

namespace TestTask.DataAccess.Database.Configurations
{
    internal class OrderConfiguration
        : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property<int>("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.HasKey(o => o.Id);
            builder.Property(o => o.ProductName).IsRequired();
            builder.Property(o => o.Price).IsRequired();
            builder.Property(o => o.Quantity).IsRequired();

            builder.HasIndex(o => o.Quantity);

            builder.ToTable(tableBuilder => tableBuilder.HasCheckConstraint(
                name: "CHK_Orders_Price",
                sql: "Orders.Price > 0 "));

            builder.ToTable(tableBuilder => tableBuilder.HasCheckConstraint(
                name: "CHK_Orders_Quantity",
                sql: "Orders.Quantity > 0 "));

            builder.HasData(
                new Order[]
                {
                    new Order {Id = 1, ProductName = "Apple", Price = 10, Quantity = 5, UserId = 1},
                    new Order {Id = 2, ProductName = "Lemon", Price = 30, Quantity = 2, UserId = 1},
                    new Order {Id = 3, ProductName = "Cucumber", Price = 5, Quantity = 10, UserId = 1},
                    new Order {Id = 4, ProductName = "Cabbage", Price = 7, Quantity = 2, UserId = 2},
                    new Order {Id = 5, ProductName = "Onion", Price = 8, Quantity = 6, UserId = 2},
                    new Order {Id = 6, ProductName = "Carrot", Price = 9, Quantity = 5, UserId = 2},
                    new Order {Id = 7, ProductName = "Mango", Price = 40, Quantity = 2, UserId = 3},
                    new Order {Id = 8, ProductName = "Orange", Price = 45, Quantity = 5, UserId = 4},
                    new Order {Id = 9, ProductName = "Watermelon", Price = 100, Quantity = 1, UserId = 4},
                    new Order {Id = 10, ProductName = "Garlic", Price = 8, Quantity = 12, UserId = 4},
                    new Order {Id = 11, ProductName = "Potato", Price = 3, Quantity = 100, UserId = 7},
                    new Order {Id = 12, ProductName = "Carrot", Price = 9, Quantity = 15, UserId = 7},
                    new Order {Id = 13, ProductName = "Onion", Price = 8, Quantity = 15, UserId = 7},
                    new Order {Id = 14, ProductName = "Pumpkin", Price = 50, Quantity = 1, UserId = 7},
                    new Order {Id = 15, ProductName = "Watermelon", Price = 100, Quantity = 12, UserId = 7},
                });
        }
    }
}
