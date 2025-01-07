using CoreCodeFirst_2.Models.Entities;

namespace CoreCodeFirst_2.Models.PageVms.Products
{
    public class CreateProductPageVm
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}
