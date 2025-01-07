namespace CoreCodeFirst_2.Models.PureVms.Products
{
    public class ProductRequestModel
    {
        public ProductRequestModel(string categoryName)
        {
            CategoryName = categoryName;
        }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        string _categoryName;
        public string CategoryName 
        {
            get 
            { 
                if (_categoryName == null)
                    return "Kategorisi yoktur";
                return _categoryName; }
            private set
            {
                _categoryName = value;
            }
        }

    }
}
