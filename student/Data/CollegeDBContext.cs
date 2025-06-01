using Microsoft.EntityFrameworkCore;
using student.Data.Config;

namespace student.Data
{
    public class ClollegeDBContext : DbContext
    {
        public ClollegeDBContext(DbContextOptions<ClollegeDBContext> options) : base(options) 
        {

        }
        public DbSet<Students> Students { get; set; }
        public DbSet<Departments> Department { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePrivilege> RolePrivileges { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        public DbSet<UserType> UserType { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new DepartmentsConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new RolePrivilegeConfig());
            modelBuilder.ApplyConfiguration(new UserRoleMappingConfig());
            modelBuilder.ApplyConfiguration(new UserTypeConfig());
        }
    }
}
