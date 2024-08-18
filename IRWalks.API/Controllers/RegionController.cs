using IRWalks.API.Data;
using IRWalks.API.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRWalksDbContext _dbContext;

        public RegionController(IRWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _dbContext.Regions.ToList();

            return Ok(regions);
            
        }
        [HttpGet("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = _dbContext.Regions.FirstOrDefault(x=>x.Id==id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);

        }
    }
}
