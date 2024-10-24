namespace MoviesAPI_EFCore7.Data;

using Microsoft.EntityFrameworkCore;
using MoviesAPI_EFCore7.Entities;

public class MoviesDbContext(DbContextOptions<MoviesDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Genero>().HasKey(g => g.Id); // No es necesario ya que por convención el campo de nombre Id de una entidad es usado por EF como PK.
        //modelBuilder.Entity<Genero>().Property(g => g.Nombre).HasMaxLength(150);

        //modelBuilder.Entity<Actor>().Property(a => a.Nombre).HasMaxLength(150);
        modelBuilder.Entity<Actor>().Property(a => a.FechaNacimiento).HasColumnType("date");
        modelBuilder.Entity<Actor>().Property(a => a.Fortuna).HasPrecision(18,2);

        //modelBuilder.Entity<Pelicula>().Property(p => p.Titulo).HasMaxLength(150);
        modelBuilder.Entity<Pelicula>().Property(p => p.FechaEstreno).HasColumnType("date");

        modelBuilder.Entity<Comentario>().Property(a => a.Contenido).HasMaxLength(500);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(150); // Por defecto, los campos de tipo string tendrán siempre maxlength de 150.
    }

    public DbSet<Genero> Generos => Set<Genero>();
    public DbSet<Actor> Actores => Set<Actor>();
    public DbSet<Pelicula> Peliculas => Set<Pelicula>();
    public DbSet<Comentario> Comentarios => Set<Comentario>();
}
