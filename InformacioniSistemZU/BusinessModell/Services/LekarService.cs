using AutoMapper;
using InformacioniSistemZU.DataModel.Repositories;
using InformacioniSistemZU.Dtos.Requests;
using InformacioniSistemZU.Dtos.Responses;
using InformacioniSistemZU.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;

namespace InformacioniSistemZU.BusinessModell.RepositoriesBM
{
    public class LekarService : ILekarService
    {
        private readonly ILekarRepository _lekarRepository;
        private readonly IMapper _mapper;
        private readonly ISpecijalnostRepository _specijalnostRepository;

        public LekarService(ILekarRepository lekarRepository, IMapper mapper, ISpecijalnostRepository specijalnostRepository)
        {
            _lekarRepository = lekarRepository;
            _mapper = mapper;
            _specijalnostRepository = specijalnostRepository;
        }

        public LekarDtoResponse IzmeniLekara(int id, IzmeniLekaraDtoRequest lekarRequest)
        {
            var dataLekar = _mapper.Map<Lekar>(lekarRequest);
            var izmenjeniLekar = _lekarRepository.IzmeniLekara(id, dataLekar);
            if (izmenjeniLekar == null)
            {
                return null;
            }
            var lekarResponse = _mapper.Map<LekarDtoResponse>(izmenjeniLekar);
            return lekarResponse;
        }

        public LekarDtoResponse ObrisiLekara(int id)
        {
            var dataLekar = _lekarRepository.IzbrisiLekara(id);
            if (dataLekar == null)
            {
                return null;
            }
            var lekarResponse = _mapper.Map<LekarDtoResponse>(dataLekar);
            return lekarResponse;
        }

        public LekarDtoResponse UnesiLekara(UnesiLekaraDtoRequest lekarRequest)
        {
            var dataLekar = _mapper.Map<Lekar>(lekarRequest);
            var specijalnostId = _specijalnostRepository.VratiPoId(lekarRequest.SpecijalnostId); 
            if (specijalnostId == null)                                                            
            {                                                                                 
                return null;
            } 
            var kreiraniLekar = _lekarRepository.UnesiLekara(dataLekar);
            var lekarResponse = _mapper.Map<LekarDtoResponse>(kreiraniLekar);
            return lekarResponse;
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
