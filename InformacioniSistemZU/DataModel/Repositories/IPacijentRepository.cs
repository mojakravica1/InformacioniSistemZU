using InformacioniSistemZU.Models;

namespace InformacioniSistemZU.DataModel.Repositories
{
    public interface IPacijentRepository
    {
        IEnumerable<Pacijent> VratiSvePacijente();
        Pacijent VratiPacijentaPoId(int id);
        Pacijent UnesiPacijenta (Pacijent pacijent);
        Pacijent IzmeniPacijenta(int id, Pacijent pacijent);
        Pacijent IzbrisiPacijenta(int id);
    }
}
