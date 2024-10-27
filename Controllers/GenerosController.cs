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

        public GenerosController(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Post(GeneroCreacionDTO generoCreacion)
        {
            var genero = new Genero
            {
                Nombre = generoCreacion.Nombre
            };

            _dbContext.Add(genero);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
