using InformacioniSistemZU.Dtos.Requests;
using InformacioniSistemZU.Dtos.Responses;
using InformacioniSistemZU.Models;

namespace InformacioniSistemZU.BusinessModell.RepositoriesBM
{
    public interface ILekarService
    {
        IEnumerable<LekarDtoResponse> VratiSveLekare();
        LekarDtoResponse VratiLekaraPoId(int id);
        LekarDtoResponse UnesiLekara(UnesiLekaraDtoRequest lekarRequest);
        LekarDtoResponse IzmeniLekara(int id, IzmeniLekaraDtoRequest lekarRequest);
        LekarDtoResponse ObrisiLekara(int id);
        IEnumerable<PacijentDtoResponse> VratiPacijentePoIdLekara(int id);
        IEnumerable<LekarDtoResponse> VratiLekarePoImenu(string ime);
    }
}
