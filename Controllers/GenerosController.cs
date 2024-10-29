using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI_EFCore7.Data;
using MoviesAPI_EFCore7.DTO_s;
using MoviesAPI_EFCore7.Entities;

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
    }
}
