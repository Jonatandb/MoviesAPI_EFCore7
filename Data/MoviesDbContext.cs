namespace MoviesAPI_EFCore7.Data;

using Microsoft.EntityFrameworkCore;
using MoviesAPI_EFCore7.Entities;
using MoviesAPI_EFCore7.Entities.Seeding;
using System.Reflection;

public class MoviesDbContext(DbContextOptions<MoviesDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Genero>().HasKey(g => g.Id); // No es necesario ya que por convención el campo de nombre Id de una entidad es usado por EF como PK.

        // modelBuilder.Entity<Genero>().Property(g => g.Nombre).HasMaxLength(150); // Ya no es necesario luego de establecer
        //                  el maxLength dentro de "override void ConfigureConventions".

        // Con esta línea le decimos a EF que busque y aplique las configuraciones especificadas
        //   en todas las clases, de este mismo ensamblado, que implementen la interfaz IEntityTypeConfiguration<>,
        //   ejemplo: Entities/Configurations/ActionConfig.cs
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        SeedingInicial.Seed(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(150); // Por defecto, ahora los campos de tipo string de todas las entidades
                                                                      // tendrán siempre maxlength de 150.
    }

    public DbSet<Genero> Generos => Set<Genero>();
    public DbSet<Actor> Actores => Set<Actor>();
    public DbSet<Pelicula> Peliculas => Set<Pelicula>();
    public DbSet<Comentario> Comentarios => Set<Comentario>();
    public DbSet<PeliculaActor> PeliculasActores => Set<PeliculaActor>();
}
