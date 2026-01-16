using AutoMapper;
using InformacioniSistemZU.Dtos.Responses;
using InformacioniSistemZU.Models;

namespace InformacioniSistemZU.Mapper
{
    public class DataModel2BusinessModel : Profile
    {
        public DataModel2BusinessModel()
        {
            CreateMap<Lekar, LekarDtoResponse>();
        }
    }
}
