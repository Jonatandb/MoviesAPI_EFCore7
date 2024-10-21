namespace MoviesAPI_EFCore7.Data;

using Microsoft.EntityFrameworkCore;
using MoviesAPI_EFCore7.Entities;

public class MoviesDbContext(DbContextOptions<MoviesDbContext> options) : DbContext(options)
{
    public DbSet<Genero> Generos => Set<Genero>();
}
