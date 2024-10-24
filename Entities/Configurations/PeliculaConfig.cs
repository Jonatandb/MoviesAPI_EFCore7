using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesAPI_EFCore7.Entities.Configurations
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            //modelBuilder.Entity<Pelicula>().Property(p => p.Titulo).HasMaxLength(150); // Ya no es necesario luego de establecer
            //                  en el DBContext el maxLength para todos los campos de tipo string de todas las entidades, dentro de
            //                  "override void ConfigureConventions".

            builder.Property(p => p.FechaEstreno).HasColumnType("date");
        }
    }
}
