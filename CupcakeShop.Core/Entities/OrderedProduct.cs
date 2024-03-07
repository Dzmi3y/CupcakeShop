namespace CupcakeShop.Core.Entities
{
    public class OrderedProduct : BaseEntity
    {
        public Guid? ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public Guid? AdditionWeightId { get; set; }
        public virtual AdditionWeight? AdditionWeight { get; set; }
        public Guid? AdditionDecorationId { get; set; }
        public virtual AdditionDecoration? AdditionDecoration { get; set; }
        public Guid? AdditionSubspeciesId { get; set; }
        public virtual AdditionSubspecies? AdditionSubspecies { get; set; }
    }
}
