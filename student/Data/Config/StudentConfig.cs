using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace student.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(n => n.Name).IsRequired().HasMaxLength(250);
            builder.Property(n => n.Address).IsRequired(false).HasMaxLength(250);
            builder.Property(n => n.Email).IsRequired(false).HasMaxLength(250);
            builder.HasData(new List<Students>()
            {
                new Students
                {
                    Id = 1,
                    Name = "Nam",
                    Address = "VN",
                    Email ="1#gamil.com",
                    DOB = new DateTime(2022,12,12)

                },
                new Students
                {
                    Id = 2,
                    Name = "Nam2",
                    Address = "VN2",
                    Email ="1#gamil.com2",
                    DOB = new DateTime(2022,12,12)

                },
                new Students
                {
                    Id = 3,
                    Name = "Nam3",
                    Address = "VN3",
                    Email ="1#gamil.com3",
                    DOB = new DateTime(2022,12,12)

                },
            });

            builder.HasOne(x=>x.Department).WithMany(x =>x.Students)
                .HasForeignKey(x => x.DepartmentId).HasConstraintName("FK_Student_Department");
        }
    }
}
