using System.ComponentModel.DataAnnotations;

namespace TestTask.DataAccess.Models
{
    public class Order
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
