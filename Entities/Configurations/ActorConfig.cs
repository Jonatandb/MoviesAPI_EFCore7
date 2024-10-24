using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesAPI_EFCore7.Entities.Configurations
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            //modelBuilder.Entity<Actor>().Property(a => a.Nombre).HasMaxLength(150); // Ya no es necesario luego de establecer
            // en el DBContext el maxLength para todos los campos de tipo string de todas las entidades, dentro de
            // "override void ConfigureConventions".

            builder.Property(a => a.FechaNacimiento).HasColumnType("date");
            builder.Property(a => a.Fortuna).HasPrecision(18, 2);
        }
    }
}
