namespace MoviesAPI_EFCore7.Entities
{
    public class Comentario
    {
        public int Id { get; set; }
        public string? Contenido { get; set; }
        public bool Recomendar { get; set; }

        public int PeliculaId { get; set; } // Esto se va a configurar como una clave foránea,
                                            // por tanto este id debe existir entre los id's existentes en la tabla Peliculas.
        
        public Pelicula Pelicula { get; set; } = null!; // Esta es una "propiedad de navegación" que va desde
                                                        // "Comentario" hacia "Pelicula".

    }
}
