using AutoMapper;
using InformacioniSistemZU.DataModel.Repositories;
using InformacioniSistemZU.Dtos.Requests;
using InformacioniSistemZU.Dtos.Responses;
using InformacioniSistemZU.Models;

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

            //IEnumerable<Pacijent> pacijenti = new List<Pacijent>();

            var lekarId = _lekarRepository.VratiLekaraPoId(pacijentRequest.LekarId);
            IEnumerable<Lekar> lekari = _lekarRepository.VratiSveLekare().Where(x => x.Id == pacijentRequest.LekarId);
            
            if (lekari.Count() > 5 || lekarId == null)
            {
                return null; // Nisam punio bazu radi provere i da li puni listu, mislim da sam pogodio implementaciju
            }                // Opet vracam null :)

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
