using AutoMapper;
using InformacioniSistemZU.DataModel.Repositories;
using InformacioniSistemZU.Dtos.Requests;
using InformacioniSistemZU.Dtos.Responses;
using InformacioniSistemZU.Models;
using System.Data;

namespace InformacioniSistemZU.BusinessModell.Services
{
    public class PacijentService : IPacijentService
    {
        private readonly IPacijentRepository _pacijentRepository;
        private readonly IMapper _mapper;
        private readonly ILekarRepository _lekarRepository;

        public PacijentService(IPacijentRepository pacijentRepository, IMapper mapper, ILekarRepository lekarRepository)
        {
            _pacijentRepository = pacijentRepository;
            _mapper = mapper;
            _lekarRepository = lekarRepository;
        }

        public PacijentDtoResponse IzmeniPacijenta(int id, IzmeniPacijentaDtoRequest pacijentRequest)
        {
            //TODO: razmisli da li ti ovde treba provera postojanja lekara i maksimalnog broja pacijenta
            var dataPacijent = _mapper.Map<Pacijent>(pacijentRequest);
            var izmenjeniPacijent = _pacijentRepository.IzmeniPacijenta(id, dataPacijent);
            if (izmenjeniPacijent == null)
            {
                return null;
            }
            var response = _mapper.Map<PacijentDtoResponse>(izmenjeniPacijent);
            return response;
        }

        public PacijentDtoResponse ObrisiPacijenta(int id)
        {
            var dataPacijent = _pacijentRepository.IzbrisiPacijenta(id);
            if (dataPacijent == null)
            {
                return null;
            }
            var obrisaniPacijent = _mapper.Map<PacijentDtoResponse>(dataPacijent);
            return obrisaniPacijent;
        }

        public PacijentDtoResponse UnesiPacijenta(UnesiPacijentaDtoRequest pacijentRequest)
        {
            var dataPacijent = _mapper.Map<Pacijent>(pacijentRequest);

            var lekar = _lekarRepository.VratiLekaraPoId(pacijentRequest.LekarId); 
            if (lekar == null)
            {
                return null;
            }
            List<Pacijent> pacijenti = _pacijentRepository.VratiSvePacijente().Where(x => x.LekarId == pacijentRequest.LekarId).ToList();
                                                                                      
            if(pacijenti.Count() < 5)
            {
                pacijenti.Add(new Pacijent());          // Radi. Mislim da je sad Ok
            }                                           // Cekam odgovor 
            else                                        // Video sam ono da umesto null bacam throw new exception ali za to sigurno treba posebna validacija
            {                                           // Je l' to sa onim exception Handler - om?
                return null;
            }

            var kreiraniPacijent = _pacijentRepository.UnesiPacijenta(dataPacijent);
            var response = _mapper.Map<PacijentDtoResponse>(kreiraniPacijent);
            return response;
        }

        public PacijentDtoResponse VratiPacijentaPoId(int id)
        {
            var dataPacijent = _pacijentRepository.VratiPacijentaPoId(id);
            if (dataPacijent == null)
            {
                return null;
            }
            var response = _mapper.Map<PacijentDtoResponse>(dataPacijent);
            return response;
        }

        public IEnumerable<PacijentDtoResponse> VratiSvePacijente()
        {
            var dataPacijenti = _pacijentRepository.VratiSvePacijente();
            var response = _mapper.Map<IEnumerable<PacijentDtoResponse>>(dataPacijenti);
            return response;
        }
    }
}
