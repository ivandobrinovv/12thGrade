using Microsoft.EntityFrameworkCore;
using BasicAPIProject.DataAccess.Entities;

namespace BasicAPIProject.DataAccess
{
    public class PracticalAssignmentDbContext : DbContext
    {
        public PracticalAssignmentDbContext(DbContextOptions<PracticalAssignmentDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
