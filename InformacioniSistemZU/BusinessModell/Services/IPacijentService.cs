using InformacioniSistemZU.Dtos.Requests;
using InformacioniSistemZU.Dtos.Responses;

namespace InformacioniSistemZU.BusinessModell.Services
{
    public interface IPacijentService
    {
        IEnumerable<PacijentDtoResponse> VratiSvePacijente();
        PacijentDtoResponse VratiPacijentaPoId(int id);
        PacijentDtoResponse UnesiPacijenta(UnesiPacijentaDtoRequest pacijentRequest);
        PacijentDtoResponse IzmeniPacijenta (int id, IzmeniPacijentaDtoRequest pacijentRequest);
        PacijentDtoResponse ObrisiPacijenta(int id);
    }
}
