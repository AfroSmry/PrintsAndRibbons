using System.ComponentModel.DataAnnotations;

namespace PrintsAndRibbons.Models
{
    public class Print
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(70)]
        public string ProductName { get; set; }

        [StringLength(300)]
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
