using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdvancedApi.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? Status { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [JsonIgnore]
        public HashSet<Product> Products { get; set; } = new HashSet<Product>();
    }
}
