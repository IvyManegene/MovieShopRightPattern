using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShopRightPattern.Data;

namespace MovieShopRightPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyMovieShopController<TEntity, TRepository> : ControllerBase
    where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository Repository;

        public MyMovieShopController(TRepository Repository)
        {
            this.Repository = Repository;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetMovie()
        {
            return await Repository.GetAll();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetMovieById(int id)
        {
            var Movie = await Repository.Get(id);
            if (Movie == null)
            {
                return NotFound();
            }
            return Movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, TEntity Movie)
        {
            if (id != Movie.Id)
            {
                return BadRequest();
            }
            await Repository.Update(Movie);
            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TEntity>> PostMovie(TEntity Movie)
        {
            await Repository.Add(Movie);
            return CreatedAtAction("GetMovie", new { id = Movie.Id }, Movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> DeleteMovie(int id)
        {
            var Movie = await Repository.Delete(id);
            if (Movie == null)
            {
                return NotFound();
            }
            return Movie;
        }
    }
}
