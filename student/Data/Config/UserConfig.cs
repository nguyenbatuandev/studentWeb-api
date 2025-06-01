using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace student.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x  => x.Username).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.PasswordSalt).IsRequired();
            builder.Property(x => x.CreateedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.UserTypeId).IsRequired();

            builder.HasOne(x => x.UserType).WithMany(x =>x.User)
                .HasForeignKey(x => x.UserTypeId).HasConstraintName("FK_User_UserType");
        }
    }
}
