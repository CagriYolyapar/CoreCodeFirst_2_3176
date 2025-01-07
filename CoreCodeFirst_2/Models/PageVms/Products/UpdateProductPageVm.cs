using CoreCodeFirst_2.Models.Entities;

namespace CoreCodeFirst_2.Models.PageVms.Products
{
    public class UpdateProductPageVm
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
