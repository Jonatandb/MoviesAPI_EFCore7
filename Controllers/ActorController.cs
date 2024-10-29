using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI_EFCore7.Data;
using MoviesAPI_EFCore7.DTO_s;
using MoviesAPI_EFCore7.Entities;

namespace MoviesAPI_EFCore7.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActorController: ControllerBase
    {
        private readonly MoviesDbContext _dbContext;
        private readonly IMapper _mapper;

        public ActorController(MoviesDbContext dbContext, IMapper mapper)
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
    }
}
