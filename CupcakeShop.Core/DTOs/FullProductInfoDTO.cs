namespace CupcakeShop.Core.DTOs
{
    public class FullProductInfoDTO : ShortProductInfoDTO
    {
        public string Description { get; set; } = string.Empty;
        public string StorageConditions { get; set; } = string.Empty;
        public string Delivery { get; set; } = string.Empty;
        public string ImgUrlsJson { get; set; } = string.Empty;
        public string ShortDetailsJson { get; set; } = string.Empty;
    }
}
