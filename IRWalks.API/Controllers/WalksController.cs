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
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository WalkRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository WalkRepository
            ,IMapper mapper)
        {
            this.WalkRepository = WalkRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var WalksDomain = await WalkRepository.GetAllAsync();            
            return Ok(_mapper.Map<List<WalkDto>>(WalksDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            var WalkDomain = await WalkRepository.GetAsync(id);
            if (WalkDomain == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<List<WalkDto>>(WalkDomain));

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var WalkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);

            WalkDomainModel =   await WalkRepository.AddAsync(WalkDomainModel);

            var WalkDto = _mapper.Map<WalkDto>(WalkDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = WalkDto.Id }, WalkDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id , [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var WalkDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);

            WalkDomainModel = await WalkRepository.UpdateAsync(id, WalkDomainModel);

            if (WalkDomainModel == null)
            {
                return NotFound();
            }
            var WalkDto = _mapper.Map<WalkDto>(WalkDomainModel);

            return Ok(WalkDto);

        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var WalkDomainModel = await WalkRepository.DeleteAsync(id);

            if(WalkDomainModel == null)
            {
                return NotFound();
            }
             

            return Ok();
        }


    }
}
