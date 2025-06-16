using System.ComponentModel.DataAnnotations;

namespace MotorcycleStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string City { get; set; }

        public int MotorcycleId { get; set; }

        public Motorcycle Motorcycle { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
