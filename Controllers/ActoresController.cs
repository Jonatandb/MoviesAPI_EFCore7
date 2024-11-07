using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI_EFCore7.Data;
using MoviesAPI_EFCore7.DTO_s;
using MoviesAPI_EFCore7.Entities;

namespace MoviesAPI_EFCore7.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly MoviesDbContext _dbContext;
        private readonly IMapper _mapper;

        public ActoresController(MoviesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actor)
        {
            var nuevoActor = _mapper.Map<Actor>(actor);
            _dbContext.Add(nuevoActor);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await _dbContext.Actores
                .OrderByDescending(a => a.FechaNacimiento)
                    .ThenBy(a => a.Nombre)
                .ToListAsync();
        }

        [HttpGet("nombre")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string nombre)
        {
            // Versión 1: el nombre debe coincidir exatamente (incluídas mayúsculas)
            return await _dbContext.Actores
                .Where(a => a.Nombre == nombre)
                .ToListAsync();
        }

        [HttpGet("nombreV2")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetV2(string nombre)
        {
            // Versión 2: el nombre debe coincidir con alguna parte del mismo (incluídas mayúsculas)
            return await _dbContext.Actores
                .Where(a => a.Nombre.ToLower()
                .Contains(nombre.ToLower()))
                .ToListAsync();
        }

        [HttpGet("fechaNacimiento/rango")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetByDateRange(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _dbContext.Actores
                .Where(a => a.FechaNacimiento >= fechaInicio && a.FechaNacimiento <= fechaFin)
                    .OrderBy(a => a.FechaNacimiento)
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> Get(int id)
        {
            var actor = await _dbContext.Actores.FirstOrDefaultAsync(a => a.Id == id);
            if (actor is null)
            {
                return NotFound();
            }
            return actor;
        }

        [HttpGet("idynombre")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> Getidynombre()
        {
            return await _dbContext.Actores
                .ProjectTo<ActorDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
