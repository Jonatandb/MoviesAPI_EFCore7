﻿namespace MoviesAPI_EFCore7.Entities
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }

        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>(); // Esta es una "propiedad de navegación"
                                                                                          // que va desde "Pelicula" hacia "Comentario".
                // * Como es una relación uno a muchos, se utiliza un hashset, ya que contendrá una colección de comentarios.
                //
                //** HashSet es más rápido para trabajar con colecciones, pero no garantiza que se respete el orden,
                //          por lo que si se necesita ordenar los comentarios conviene usar una lista en su lugar.

        public HashSet<Genero> Generos { get; set; } = new HashSet<Genero>();

        public List<PeliculaActor> PeliculasActores { get; set; } = new List<PeliculaActor>();
    }
}
