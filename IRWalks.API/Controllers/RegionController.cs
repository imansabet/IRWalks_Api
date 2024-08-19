using AutoMapper;
using IRWalks.API.Data;
using IRWalks.API.Models.Domain;
using IRWalks.API.Models.DTO;
using IRWalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IRWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRWalksDbContext _dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper _mapper;

        public RegionController(IRWalksDbContext dbContext , IRegionRepository regionRepository
            ,IMapper mapper)
        {
            _dbContext = dbContext;
            this.regionRepository = regionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await regionRepository.GetAllAsync();            
            return Ok(_mapper.Map<List<RegionDto>>(regionsDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            var regionDomain = await regionRepository.GetAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<List<RegionDto>>(regionDomain));

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);

            regionDomainModel =   await regionRepository.AddAsync(regionDomainModel);

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id , [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);

        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if(regionDomainModel == null)
            {
                return NotFound();
            }
             

            return Ok();
        }


    }
}
