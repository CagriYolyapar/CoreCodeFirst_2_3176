namespace CoreCodeFirst_2.Models.Entities
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        //Relational Properties
        public virtual ICollection<Order> Orders { get; set; }
        public virtual AppUserProfile AppUserProfile { get; set; }
    }
}
