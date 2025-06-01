using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace student.Data.Config
{
    public class DepartmentsConfig : IEntityTypeConfiguration<Departments>
    {

        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();

            builder.Property(x => x.DepartmentName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description).HasMaxLength(250);

            builder.HasData(new List<Departments>()
            {
                new Departments()
                {
                    Id = 1,
                    DepartmentName = "ECE1",
                    Description = "ECE des"
                },
                new Departments()
                {
                    Id = 2,
                    DepartmentName = "ECD1",
                    Description = "ECD des"
                }
            });
        }
    }
}
