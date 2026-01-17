using InformacioniSistemZU.Dtos.Responses;
using InformacioniSistemZU.Models;

namespace InformacioniSistemZU.BusinessModell.RepositoriesBM
{
    public interface ILekarService
    {
        IEnumerable<LekarDtoResponse> VratiSveLekare();
        LekarDtoResponse VratiLekaraPoId(int id);
        LekarDtoResponse UnesiLekara(LekarDtoResponse lekar);
        LekarDtoResponse IzmeniLekara(int id, LekarDtoResponse lekar);
        LekarDtoResponse ObrisiLekara(int id);
    }
}
