namespace CupcakeShop.Core.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderedProducts = new List<OrderedProduct>();
        }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string DeliveryMethod { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string House { get; set; } = string.Empty;
        public string Entrance { get; set; } = string.Empty;
        public string Building { get; set; } = string.Empty;
        public string Apartment { get; set; } = string.Empty;
        public string Floor { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string Commentary { get; set; } = string.Empty;

        public List<OrderedProduct> OrderedProducts { get; set; }
    }

}
