using API_Project.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Domain
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> opts) : base(opts)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<StudentClass> StudentClasses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                           .HasOne(s => s.Address)
                           .WithOne(a => a.Student)
                           .HasForeignKey<Address>(a => a.StudentId);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Student)
                .WithOne(s => s.Address)
                .HasForeignKey<Student>(s => s.Id);


            modelBuilder.Entity<StudentClass>().
                HasMany(a => a.Students).
                WithOne(x => x.StudentClass)
                .HasForeignKey(x => x.StudentClassId);


            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
