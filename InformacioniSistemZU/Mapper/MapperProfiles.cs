using AutoMapper;
using InformacioniSistemZU.Dtos.Requests;
using InformacioniSistemZU.Dtos.Responses;
using InformacioniSistemZU.Models;

namespace InformacioniSistemZU.Mapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Lekar, LekarDtoResponse>().ReverseMap();
            CreateMap<UnesiLekaraDtoRequest, LekarDtoResponse>().ReverseMap();
        }
    }
}
