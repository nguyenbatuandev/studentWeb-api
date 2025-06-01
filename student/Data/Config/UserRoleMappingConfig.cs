using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace student.Data.Config
{
    public class UserRoleMappingConfig : IEntityTypeConfiguration<UserRoleMapping>
    {
        public void Configure(EntityTypeBuilder<UserRoleMapping> builder)
        {
            builder.ToTable("UserRoleMapping");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.RoleId).IsRequired();
            builder.HasIndex(x => new
            {
                x.UserId,
                x.RoleId,
            }, "UK_UserRoleMapping"     
            ).IsUnique();

            builder.HasOne(x => x.User).WithMany(x => x.UserRoleMapping)
               .HasForeignKey(x => x.UserId).HasConstraintName("FK_UserRoleMapping_User");

            builder.HasOne(x => x.Role).WithMany(x => x.UserRoleMapping)
              .HasForeignKey(x => x.RoleId).HasConstraintName("FK_UserRoleMapping_Role");
        }
    }
}
