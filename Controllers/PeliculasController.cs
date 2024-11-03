﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI_EFCore7.Data;
using MoviesAPI_EFCore7.DTO_s;
using MoviesAPI_EFCore7.Entities;

namespace MoviesAPI_EFCore7.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController: ControllerBase
    {
        private readonly MoviesDbContext _context;
        private readonly IMapper _mapper;

        public PeliculasController(MoviesDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PeliculaCreacionDTO pelicula)
        {
            var nuevaPelicula = _mapper.Map<Pelicula>(pelicula);

            if(nuevaPelicula.Generos is not null)
            {
                foreach(var genero in nuevaPelicula.Generos)
                {
                    // Aviso a EFCore que "genero" ya existe en la base de datos
                    // y no tiene que hacer nada. Esto evita que EFCore cree
                    // un nuevo registro en la base de datos.
                    _context.Entry(genero).State = EntityState.Unchanged;
                }
            }

            if(nuevaPelicula.PeliculasActores is not null)
            {
                for(int i = 0; i < nuevaPelicula.PeliculasActores.Count; i++)
                {
                    nuevaPelicula.PeliculasActores[i].Orden = i + 1;
                }
            }

            _context.Add(nuevaPelicula);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}