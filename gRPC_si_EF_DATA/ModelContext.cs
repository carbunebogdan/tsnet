using gRPC_si_EF_DATA.Entities;
using Microsoft.EntityFrameworkCore;

namespace gRPC_si_EF_DATA
{
    public class ModelContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KAUU9VV;Database = grpcPostComment; Trusted_Connection = True");
         }


        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>()
                .HasMany(m => m.Comments)
                .WithOne(p => p.Post);
        }
    }
}