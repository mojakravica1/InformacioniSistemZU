using AutoMapper;
using InformacioniSistemZU.BusinessModell.ModelsBM;
using InformacioniSistemZU.Models;

namespace InformacioniSistemZU.Mapper
{
    public class DataModel2BusinessModel : Profile
    {
        public DataModel2BusinessModel()
        {
            CreateMap<Lekar, LekarBM>();
        }
    }
}
