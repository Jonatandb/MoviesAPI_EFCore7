﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI_EFCore7.Entities;
using Microsoft.EntityFrameworkCore;
using MoviesAPI_EFCore7.DTO_s;
using MoviesAPI_EFCore7.Data;


namespace MoviesAPI_EFCore7.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly MoviesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenerosController(MoviesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(GeneroCreacionDTO genero)
        {
            var GeneroExistente = await _dbContext.Generos.AnyAsync(g => g.Nombre == genero.Nombre);

            if(GeneroExistente)
            {
                return BadRequest("El genero " + genero.Nombre + " ya existe!");
            }

            var nuevoGenero = _mapper.Map<Genero>(genero);

            _dbContext.Add(nuevoGenero);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("varios")] // Este nombre "varios" es el que se va a usar en la URL --> /api/generos/varios
        // [Route("varios")] // Necesario si en lugar de "HttpPost("varios")" se usa solo "HttpPost"
        public async Task<ActionResult> Post(GeneroCreacionDTO[] generosCreacion)
        {
            var generos = _mapper.Map<Genero[]>(generosCreacion);

            _dbContext.AddRange(generos);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> Get()
        {
            return await _dbContext.Generos.ToListAsync();
        }

        [HttpPut("{id:int}/nombre2")]
        public async Task<ActionResult> Put(int id)
        {
            // Actualización por medio del "modelo conectado":

            var genero = await _dbContext.Generos.FirstOrDefaultAsync(g => g.Id == id);

            if (genero is null)
            {
                return NotFound();
            }

            genero.Nombre = genero.Nombre + "2";

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, GeneroCreacionDTO generoToUpdate)
        {
            // Actualización por medio del "modelo desconectado":

            var genero = _mapper.Map<Genero>(generoToUpdate);

            genero.Id = id;

            _dbContext.Update(genero);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteModernoRecomendado(int id)
        {
            var filasAfectadas = await _dbContext.Generos.Where(g => g.Id == id).ExecuteDeleteAsync();

            if (filasAfectadas == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}/anterior")]
        public async Task<ActionResult> DeleteAnterior(int id)
        {
            var genero = await _dbContext.Generos.FirstOrDefaultAsync(g => g.Id == id);

            if (genero is null)
            {
                return NotFound();
            }

            _dbContext.Remove(genero);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
