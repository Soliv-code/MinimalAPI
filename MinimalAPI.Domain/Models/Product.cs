using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public int Qnt { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; }

    }
}
