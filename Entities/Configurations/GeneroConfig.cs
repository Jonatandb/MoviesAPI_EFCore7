using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesAPI_EFCore7.Entities.Configurations
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            var cienciaFiccion = new Genero { Id = 2, Nombre = "Ciencia ficción" };
            var anime= new Genero { Id = 5, Nombre = "Anime" };

            builder.HasData(cienciaFiccion, anime);
        }
    }
}
