using AutoMapper;
using InformacioniSistemZU.BusinessModell.ModelsBM;
using InformacioniSistemZU.DataModel.Repositories;
using InformacioniSistemZU.Models;

namespace InformacioniSistemZU.BusinessModell.RepositoriesBM
{
    public class LekarRepositoryBM : ILekarRepositoryBM
    {
        private readonly ILekarRepository _lekarRepository;
        private readonly IMapper _mapper;

        public LekarRepositoryBM(ILekarRepository lekarRepository, IMapper mapper)
        {
            _lekarRepository = lekarRepository;
            _mapper = mapper;
        }
        public IEnumerable<LekarBM> PregledLekara()
        {
            var dataLekar = _lekarRepository.PregledLekara();
            var bmLekar = _mapper.Map<IEnumerable<LekarBM>>(dataLekar);
            return bmLekar;
        }
    }
}
