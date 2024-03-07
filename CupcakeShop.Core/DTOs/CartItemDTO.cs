namespace CupcakeShop.Core.DTOs
{
    public class CartItemDTO
    {
        public Guid? ProductId { get; set; }
        public Guid? AdditionWeightId { get; set; }
        public Guid? AdditionDecorationId { get; set; }
        public Guid? AdditionSubspeciesId { get; set; }
    }
}
