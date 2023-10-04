using System.ComponentModel.DataAnnotations;
using TestTask.DataAccess.Enums;

namespace TestTask.DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public UserStatus Status { get; set; }

        public List<Order> Orders { get; set; }
    }
}
