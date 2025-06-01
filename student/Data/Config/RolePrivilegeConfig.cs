using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace student.Data.Config
{
    public class RolePrivilegeConfig : IEntityTypeConfiguration<RolePrivilege>
    {
        public void Configure(EntityTypeBuilder<RolePrivilege> builder)
        {
            builder.ToTable("RolePrivilege");
            builder.HasKey(x => x.Id);
            builder.Property(x =>x.Id).UseIdentityColumn();
            builder.Property(x => x.rolePrivilege).IsRequired();


            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDelete).IsRequired();
            builder.Property(x => x.CreateedDate).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.HasOne(x => x.Role).WithMany(x => x.RolePrivilege)
                .HasForeignKey(x => x.RoleId).HasConstraintName("FK_RolePrivilege_Role");
        }
    }
}
