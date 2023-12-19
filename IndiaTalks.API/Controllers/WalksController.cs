
using AutoMapper;
using IndiaTalks.API.CustomActionFilters;
using IndiaTalks.API.Models.Domain;
using IndiaTalks.API.Models.DTOs;
using IndiaTalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Security.Claims;

namespace IndiaTalks.API.Controllers
{
    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        // Create Walk
        //POST: /api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalksRequestDto)
        {

            //Map DTO to domain model
            var walkDomainModel = mapper.Map<Walk>(addWalksRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);
            //Map domain model to DTO


            return Ok(mapper.Map<WalkDto>(walkDomainModel));


        }


        //GET walks
        // GET : /api/walks/filteron=name& filterQuery=Track&sortBy=Name&Ascending=true& pageNumber=1&pageSize=10

        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber=1, [FromQuery] int pageSize =1000)
        {
            var walksDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery
                , sortBy, isAscending?? true, pageNumber, pageSize);

            // Map domain Model into DTO

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));

        }

        // GET Walks by ID
        //GET: /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }
            // map domain model to DTO

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //UpdATE walk by Id
        //PUT : /api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            {

                //Map dto to domain model
                var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

                walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

                if (walkDomainModel == null)
                {
                    return NotFound();

                }

                //Map domain Model to Dto

                return Ok(mapper.Map<WalkDto>(walkDomainModel));
            }

        }

        //DELETE a walk By Id
        //DELETE: /api/walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]



        public async Task<IActionResult> Delete([FromRoute] Guid id)

        {
            var deleteWalkDomainModel = await walkRepository.DeleteAsync(id);
            if (deleteWalkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(deleteWalkDomainModel));

        }



    }
}
