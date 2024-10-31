using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI_EFCore7.Data;
using MoviesAPI_EFCore7.DTO_s;
using MoviesAPI_EFCore7.Entities;

namespace MoviesAPI_EFCore7.Controllers
{
    [ApiController]
    [Route("api/peliculas/{peliculaId:int}/comentarios")]
    public class ComentariosController: ControllerBase
    {
        private readonly MoviesDbContext _dbContext;
        private readonly IMapper _mapper;

        public ComentariosController(MoviesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int peliculaId, ComentarioCreacionDTO comentario)
        {
            var nuevoComentario = _mapper.Map<Comentario>(comentario);
            nuevoComentario.PeliculaId = peliculaId;
            _dbContext.Add(nuevoComentario);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
