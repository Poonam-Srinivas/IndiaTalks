using AutoMapper;
using IndiaTalks.API.CustomActionFilters;
using IndiaTalks.API.Data;
using IndiaTalks.API.Models.Domain;
using IndiaTalks.API.Models.DTOs;
using IndiaTalks.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace IndiaTalks.API.Controllers
{
    //location-https://localhost:1234/api/Regions-> it points to Regionscontroller
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly IndiaWalkAuthDbContext dBContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        //create a constructor injection to make use of dbcontxt or database instead of hardcoring the data

        public RegionsController(IndiaWalkAuthDbContext dBContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        //http get resource
        //Get all regions
        // GET- https://localhost:postnumber/api/regions--RESTful URl  
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            //now to access the regions table
            //get data from database- domain model

            // var regionsDomain = await dBContext.Regions.ToListAsync();

            var regionsDomain=await regionRepository.GetAllAsync();

            // Map the domain models to data transfer objects-DTOs

            /*var regionDtos = new List<RegionDTO>();
            foreach (var regionDomain in regionsDomain)
            {
                regionDtos.Add(new RegionDTO()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl

                });
            }*/

            // map domain mdels to dtos

            //var regionDto = mapper.Map<List<RegionDTO>>(regionsDomain);

            return Ok(mapper.Map<List<Region>>(regionsDomain));

            // return DTOs to client

            //  return Ok(regionDto);

        }
        //Get single method(get region by ID)
        // GET: https://localhost:postnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task <IActionResult> GetById([FromRoute] Guid id)

        {
            // var region= dBContext.Regions.Find(id);
            //Get Region Domain Model from Datbase
            // var regionDomain = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            var regionDomain = await regionRepository.GetByIdAsync(id);
           
                if (regionDomain == null)
            {
                return NotFound();
            }
            //Map/convert Region Domain Model to Region DTO
            // 
            /*var regionDTO = new RegionDTO
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };*/
            //Return DTO back to client

            return Ok(mapper.Map<RegionDTO>(regionDomain));
        }

        //Post to Create New Region
        // POST: https://localhost:postnumber/api/regions

        [HttpPost]
        [ValidateModel]

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTo addRegionRequestDTo)

        {

            
                //To avoid the use of Dtos and Domain Model one can make use of AutoMapper

                // Map or Convert DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDTo);


                /*var regionDomainModel = new Region
                {
                    Code = addRegionRequestDTo.Code,
                    Name = addRegionRequestDTo.Name,
                    RegionImageUrl = addRegionRequestDTo.RegionImageUrl

                };*/

                // Use Domain Model to create Region
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                //await dBContext.Regions.AddAsync(regionDomainModel);
                //await dBContext.SaveChangesAsync();



                //Map Domain model back to DTO
                var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

                /* {
                     Id = regionDomainModel.Id,
                     Code = regionDomainModel.Code,
                     Name = regionDomainModel.Name,
                     RegionImageUrl = regionDomainModel.RegionImageUrl
                 };*/

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            
         }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]

        // Update Region 
        //PUT:  https://localhost:postnumber/api/regions/{id}

        public async Task<IActionResult> Update([FromRoute] Guid id , [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            

                //Map dto to domain model

                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
                /*{
                    Code = updateRegionRequestDto.Code,
                    Name = updateRegionRequestDto.Name,
                    RegionImageUrl = updateRegionRequestDto.RegionImageUrl
                };*/

                //check if region exists
                //var regionDomainModel= await dBContext.Regions.FirstOrDefaultAsync(x=> x.Id == id);
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);


                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                //Map DTO to Domain Model


                //regionDomainModel.Code = updateRegionRequestDto.Code;
                //regionDomainModel.Name = updateRegionRequestDto.Name;
                //regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

                //await dBContext.SaveChangesAsync();
                //Convert  domain to Dto
                return Ok(mapper.Map<RegionDTO>(regionDomainModel));

                /*{
                    Id = regionDomainModel.Id,
                    Code = regionDomainModel.Code,
                    Name = regionDomainModel.Name,
                    RegionImageUrl = regionDomainModel.RegionImageUrl
                };*/
           
        }



        [HttpDelete]
        [Route("{id:Guid}")]

        //Delete region
        // DELETE :  https://localhost:postnumber/api/regions/{id}

        public async Task< IActionResult> Delete([FromRoute] Guid id) 
        {
           //var regionDomainModel= await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
           var regionDomainModel= await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Delete Region
            //dBContext.Regions.Remove(regionDomainModel);
            //await dBContext.SaveChangesAsync();

            //return deleted region back
            //map Domain Model to DTO

            return Ok( mapper.Map < RegionDTO >( regionDomainModel));

            /*{
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };*/
           // return Ok(regionDto);


        }


    }
}
