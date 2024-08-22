using System.ComponentModel.DataAnnotations;

namespace ProductSalesSystem.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Sale { get; set; }

        public int Purchase { get; set; }

        public int Stock { get; set; }

        public int ProductSaleCount { get; set; }

        public decimal TotalPrice { get; set; }

        public string? FilePath { get; set; }
    }
}
