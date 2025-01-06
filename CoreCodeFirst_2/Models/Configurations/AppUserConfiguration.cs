using CoreCodeFirst_2.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCodeFirst_2.Models.Configurations
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.AppUserProfile).WithOne(x => x.AppUser).HasForeignKey<AppUserProfile>(x => x.Id); //birebir yapının Core Framework'teki tanımlama şekli
        }
    }
}
