using CoreCodeFirst_2.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCodeFirst_2.Models.Configurations
{
    public class OrderDetailConfiguration : BaseConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.Id);
            builder.HasKey(x => new
            {
                x.OrderId,
                x.ProductId
            });
        }
    }
}
