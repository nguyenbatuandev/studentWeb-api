using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace student.Data.Config
{
    public class UserTypeConfig : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.ToTable("UserType");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.HasData(new List<UserType>
            {
                new UserType { Id = 1, Name = "Student" , Description = "for students"},
                new UserType { Id = 2, Name = "Faculty" , Description = "for Faculty"},
                new UserType { Id = 3, Name = "Supporting Staff" , Description = "for Supporting Staff"}
            });
        }
    }
}
