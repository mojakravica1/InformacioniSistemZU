using InformacioniSistemZU.Models;

namespace InformacioniSistemZU.DataModel.Repositories
{
    public interface IPregledRepository
    {
        IEnumerable<Pregled> VratiSvePreglede();
        Pregled VratiPregledPoId(int id);
        Pregled UnesiPregled(Pregled pregled);
        Pregled IzmeniPregled(int id, Pregled pregled);
        Pregled ObrisiPregled(int id);
    }
}
