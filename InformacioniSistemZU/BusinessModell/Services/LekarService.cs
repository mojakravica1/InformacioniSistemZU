using AutoMapper;
using InformacioniSistemZU.DataModel.Repositories;
using InformacioniSistemZU.Dtos.Requests;
using InformacioniSistemZU.Dtos.Responses;
using InformacioniSistemZU.Models;

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

        public LekarDtoResponse IzmeniLekara(int id, LekarDtoResponse lekar)
        {
            throw new NotImplementedException();
        }

        public LekarDtoResponse ObrisiLekara(int id)
        {
            throw new NotImplementedException();
        }

        public LekarDtoResponse UnesiLekara(LekarDtoResponse lekar)
        {
            var dataLekar = _mapper.Map<Lekar>(lekar);
            dataLekar = _lekarRepository.UnesiLekara(dataLekar);
            var bmLekar = _mapper.Map<LekarDtoResponse>(dataLekar);
            return bmLekar;
        }

        public LekarDtoResponse VratiLekaraPoId(int id)
        {
            var dataLekar = _lekarRepository.VratiLekaraPoId(id);
            var bmLekar = _mapper.Map<LekarDtoResponse>(dataLekar);
            return bmLekar;
        }

        public IEnumerable<LekarDtoResponse> VratiSveLekare()
        {
            var dataLekar = _lekarRepository.VratiSveLekare();
            var bmLekar = _mapper.Map<IEnumerable<LekarDtoResponse>>(dataLekar);
            return bmLekar;
        }
    }
}
