namespace MoviesAPI_EFCore7.Data;

using Microsoft.EntityFrameworkCore;
using MoviesAPI_EFCore7.Entities;

public class MoviesDbContext(DbContextOptions<MoviesDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Genero>().HasKey(g => g.Id);
        modelBuilder.Entity<Genero>().Property(g => g.Nombre).HasMaxLength(150);
    }

    public DbSet<Genero> Generos => Set<Genero>();
}
