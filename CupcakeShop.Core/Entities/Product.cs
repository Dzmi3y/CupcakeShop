namespace CupcakeShop.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public bool IsBestseller { get; set; }
        public double Weight { get; set; }
        public string UnitOfMeasurement { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string StorageConditions { get; set; } = string.Empty;
        public string Delivery { get; set; } = string.Empty;
        public string ImgUrlsJson { get; set; } = string.Empty;
        public string ShortDetailsJson { get; set; } = string.Empty;

        public int ProductTypeId { get; set; }
        public virtual ProductType? ProductType { get; set; }
    }
}
