using InformacioniSistemZU.Models;

namespace InformacioniSistemZU.DataModel.Repositories
{
    public interface ILekarRepository
    {
        IEnumerable<Lekar> VratiSveLekare();
        Lekar VratiLekaraPoId(int id);
        Lekar UnesiLekara(Lekar lekar);
        Lekar IzmeniLekara(int id, Lekar lekar);
        Lekar IzbrisiLekara(int id);
    }
}
