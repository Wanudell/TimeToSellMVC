using TimeToSell.Data.Dtos;

namespace TimeToSell.MVC.Models
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
            Items = new List<ProductListDto>();
        }

        public List<ProductListDto> Items { get; set; }
        public bool IsEmpty => !Items.Any();
    }
}