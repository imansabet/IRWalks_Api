using AutoMapper;
using IRWalks.API.Models.Domain;
using IRWalks.API.Models.DTO;

namespace IRWalks.API.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Region, RegionDto>().ReverseMap();
        CreateMap<AddRegionRequestDto, Region>().ReverseMap();
        CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
        CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
        CreateMap<Walk, WalkDto>().ReverseMap();


        //CreateMap<UserDTO, UserDomain>()
        //    .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName)).ReverseMap();
    }
    //public class UserDTO
    //{
    //    public string FullName { get; set; }
    //}
    //public class UserDomain
    //{
    //    public string Name { get; set; }
    //}

}
