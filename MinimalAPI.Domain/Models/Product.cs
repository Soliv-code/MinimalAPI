using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; }
    }
}
