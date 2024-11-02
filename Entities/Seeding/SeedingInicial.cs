using Microsoft.EntityFrameworkCore;

namespace MoviesAPI_EFCore7.Entities.Seeding
{
    public class SeedingInicial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var samuelJackson = new Actor()
            {
                Id = 2,
                Nombre = "Samuel Jackson",
                FechaNacimiento = new DateTime(1900, 1, 1),
                Fortuna = 15000
            };

            var RobertDowney = new Actor()
            {
                Id = 3,
                Nombre = "Robert Downey Jr",
                FechaNacimiento = new DateTime(2000, 1, 1),
                Fortuna = 18000
            };

            modelBuilder.Entity<Actor>().HasData(samuelJackson, RobertDowney);

            var avengers = new Pelicula()
            {
                Id = 2,
                Titulo = "Avengers Endgame",
                FechaEstreno = new DateTime(2019, 1, 1),
            };

            var spidermanNWH = new Pelicula()
            {
                Id = 3,
                Titulo = "Spiderman: No Way Home",
                FechaEstreno = new DateTime(2021, 1, 1),
            };

            var spidermanSpiderVerse2 = new Pelicula()
            {
                Id = 4,
                Titulo = "Spiderman: Across the Spider-Verse 2",
                FechaEstreno = new DateTime(2022, 1, 1),
            };

            modelBuilder.Entity<Pelicula>()
                .HasData(avengers, spidermanNWH, spidermanSpiderVerse2);

            var comentarioAvengers = new Comentario()
            {
                Id = 2,
                Recomendar = true,
                Contenido = "Muy buena",
                PeliculaId = avengers.Id
            };

            var comentarioAvengers2 = new Comentario()
            {
                Id = 3,
                Recomendar = true,
                Contenido = "Dura dura",
                PeliculaId = avengers.Id
            };

            var comentarioNWH = new Comentario()
            {
                Id = 4,
                Recomendar = false,
                Contenido = "Muy aburrida...",
                PeliculaId = spidermanNWH.Id
            };

            modelBuilder.Entity<Comentario>()
                .HasData(comentarioAvengers, 
                comentarioAvengers2, 
                comentarioNWH);


            // Relación muchos a muchos - "Con salto de navegación"
            // (Donde no existe entidad intermedia)
       
            var tablaGeneroPelicula = "GeneroPelicula";
            var generoIdPropiedad = "GenerosId";
            var peliculaIdPropiedad = "PeliculasId";

            var idCienciaFiccion = 2;
            var idAnime = 5;

            modelBuilder.Entity(tablaGeneroPelicula).HasData(
                new Dictionary<string, object>
                {
                    [generoIdPropiedad] = idCienciaFiccion,
                    [peliculaIdPropiedad] = avengers.Id
                },

                new Dictionary<string, object>
                {
                    [generoIdPropiedad] = idCienciaFiccion,
                    [peliculaIdPropiedad] = spidermanNWH.Id
                },

                new Dictionary<string, object>
                {
                    [generoIdPropiedad] = idAnime,
                    [peliculaIdPropiedad] = spidermanSpiderVerse2.Id
                }
            );

            // Relación muchos a muchos - "Sin salto de navegación"
            // (Donde si existe entidad intermedia: PeliculaActor)

            var samuelJacksonSpidermanNWH = new PeliculaActor()
            {
                ActorId = samuelJackson.Id,
                PeliculaId = spidermanNWH.Id,
                Orden = 1,
                Personaje = "Nick Fury"
            };

            var samuelJacksonAvengers = new PeliculaActor()
            {
                ActorId = samuelJackson.Id,
                PeliculaId = avengers.Id,
                Orden = 2,
                Personaje = "Nick Fury"
            };

            var robertDowneyAvengers = new PeliculaActor()
            {
                ActorId = RobertDowney.Id,
                PeliculaId = avengers.Id,
                Orden = 1,
                Personaje = "Tony Stark / Ironman"
            };

            modelBuilder.Entity<PeliculaActor>()
                .HasData(samuelJacksonSpidermanNWH, 
                samuelJacksonAvengers, 
                robertDowneyAvengers);
        }

    }
}
