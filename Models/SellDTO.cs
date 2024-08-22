namespace ProductSalesSystem.Models
{
    public class SellDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string PurchaseType { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
