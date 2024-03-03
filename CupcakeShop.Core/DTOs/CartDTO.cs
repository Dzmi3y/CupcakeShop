namespace CupcakeShop.Core.DTOs
{
    public class CartDTO
    {
        public CartDTO()
        {
            ProductIdList = new List<Guid>();
        }

        public List<Guid> ProductIdList { get; set; }
        public Guid? AdditionWeightId { get; set; }
        public Guid? AdditionDecorationId { get; set; }
        public Guid? AdditionSubspeciesId { get; set; }
    }
}
