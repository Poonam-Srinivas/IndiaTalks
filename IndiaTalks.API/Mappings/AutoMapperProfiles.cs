using AutoMapper;
using IndiaTalks.API.Models.Domain;
using IndiaTalks.API.Models.DTOs;

namespace IndiaTalks.API.Mappings
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {   //Automapper also allows reverse Mapping

           /* CreateMap<UserDTO, UserDomain>()
                //Suppose if the property in Source and destination is diff than
                .ForMember(x=>x.Name,opt=> opt.MapFrom(x=>x.FullName))
                .ReverseMap();*/

            CreateMap<Region, RegionDTO>().ReverseMap();

            CreateMap<AddRegionRequestDTo, Region>().ReverseMap();

            CreateMap<UpdateRegionRequestDto, RegionDTO>().ReverseMap();

            CreateMap<AddWalksRequestDto,Walk>().ReverseMap();

            CreateMap<Walk, WalkDto>().ReverseMap();

            CreateMap<Difficulty, DifficultyDto>().ReverseMap();

            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
        }
    }



    public class UserDTO
    {
        public string FullName { get; set; }
    }

    public class UserDomain
    {
        // public string FullName { get; set; }
        public string Name { get; set; }
    }
}
