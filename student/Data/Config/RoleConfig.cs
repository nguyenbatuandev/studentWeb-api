using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace student.Data.Config
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDelete).IsRequired();
            builder.Property(x => x.CreateedDate).IsRequired();
            builder.Property(x => x.RoleDescription).IsRequired().HasMaxLength(250);

        }
    }
}
