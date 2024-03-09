using Microsoft.EntityFrameworkCore;
using Eticket.Models;

namespace Eticket.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });
            modelBuilder.Entity<Models.Actor_Movie>().HasOne(am => am.Movie).WithMany(k => k.Actor_Movie).HasForeignKey(k => k.MovieId);
            modelBuilder.Entity<Models.Actor_Movie>().HasOne(am => am.Actor).WithMany(k => k.Actor_Movie).HasForeignKey(k => k.ActorId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Models.Actor> Actor { get; set; }
        public DbSet<Actor_Movie> Actor_Movie { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Movie> Mocie { get; set; }
        public DbSet<Producer> Producer { get; set; }

    }
}
