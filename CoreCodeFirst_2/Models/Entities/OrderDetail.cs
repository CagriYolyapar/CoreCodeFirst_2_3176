namespace CoreCodeFirst_2.Models.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        //Relational Properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}
