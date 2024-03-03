using CupcakeShop.Core.Entities;

namespace CupcakeShop.Core.DTOs
{
    public class AdditionalParamsDTO
    {
        public AdditionalParamsDTO()
        {
            Weights = new List<AdditionWeight>();
            Decorations = new List<AdditionDecoration>();
            Subspecies = new List<AdditionSubspecies>();
        }
        public IEnumerable<AdditionWeight> Weights { get; set; }
        public IEnumerable<AdditionDecoration> Decorations { get; set; }
        public IEnumerable<AdditionSubspecies> Subspecies { get; set; }
    }
}
