using IRWalks.API.Data;
using IRWalks.API.Models.Domain;
using IRWalks.API.Models.DTO;
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
            var regionsDomain = _dbContext.Regions.ToList();
            var regionsDto = new List<RegionDto>();

            foreach(var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }
                 

            return Ok(regionsDto);
            
        }
        [HttpGet("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {

            var regionDomain = _dbContext.Regions.FirstOrDefault(x=>x.Id==id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return Ok(regionDto);

        }
    }
}
