using AutoMapper;
using InformacioniSistemZU.DataModel.Repositories;
using InformacioniSistemZU.Dtos.Responses;

namespace InformacioniSistemZU.BusinessModell.RepositoriesBM
{
    public class LekarService : ILekarService
    {
        private readonly ILekarRepository _lekarRepository;
        private readonly IMapper _mapper;

        public LekarService(ILekarRepository lekarRepository, IMapper mapper)
        {
            _lekarRepository = lekarRepository;
            _mapper = mapper;
        }
        public IEnumerable<LekarDtoResponse> PregledLekara()
        {
            var dataLekar = _lekarRepository.PregledLekara();
            var bmLekar = _mapper.Map<IEnumerable<LekarDtoResponse>>(dataLekar);
            return bmLekar;
        }
    }
}
