namespace MoviesAPI_EFCore7.Data;

using Microsoft.EntityFrameworkCore;

public class MoviesDbContext(DbContextOptions<MoviesDbContext> options) : DbContext(options)
{

}
