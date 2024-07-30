using Microsoft.EntityFrameworkCore;

namespace University.API.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    //builder.Entity<User>()
        //    //    .HasIndex(u => u.Email)
        //    //    .IsUnique();
        //    //builder.Entity<User>()
        //    //    .HasIndex(u => u.Username)
        //    //    .IsUnique();
        //}
    }
}