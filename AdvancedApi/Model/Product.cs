using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdvancedApi.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? Status { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
    }
}
