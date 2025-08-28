using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiSandwitch.Model
{
    [Table("Sandwitch")]
    public class Sandwitch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public double? Price { get; set; }
        
    }
}
