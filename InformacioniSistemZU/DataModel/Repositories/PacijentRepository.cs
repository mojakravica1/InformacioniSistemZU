using InformacioniSistemZU.MainDbContext;
using InformacioniSistemZU.Models;

namespace InformacioniSistemZU.DataModel.Repositories
{
    public class PacijentRepository : IPacijentRepository
    {
        private readonly MyDbContext _dbContext;

        public PacijentRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Pacijent IzbrisiPacijenta(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var dataPacijent = _dbContext.Pacijenti.FirstOrDefault(x => x.Id == id);
            if (dataPacijent == null)
            {
                return null;
            }
            _dbContext.Pacijenti.Remove(dataPacijent);
            _dbContext.SaveChanges();
            return dataPacijent;
        }

        public Pacijent IzmeniPacijenta(int id, Pacijent pacijent)
        {
            ArgumentNullException.ThrowIfNull(pacijent);

            var dataPacijent = _dbContext.Pacijenti.FirstOrDefault(x => x.Id == id);
            if (dataPacijent == null)
            {
                return null;
            }

            dataPacijent.Ime = pacijent.Ime;
            dataPacijent.Prezime = pacijent.Prezime;
            dataPacijent.Jmbg = pacijent.Jmbg;
            dataPacijent.DatumRodjenja = pacijent.DatumRodjenja;
            dataPacijent.Pol = pacijent.Pol;
            dataPacijent.DatumKreiranja = pacijent.DatumKreiranja;
            dataPacijent.IsActive = pacijent.IsActive;
            dataPacijent.LekarId = pacijent.LekarId;
            _dbContext.SaveChanges();
            return dataPacijent;
        }

        public Pacijent UnesiPacijenta(Pacijent pacijent)
        {
            ArgumentNullException.ThrowIfNull(pacijent);

            _dbContext.Pacijenti.Add(pacijent);
            _dbContext.SaveChanges();
            return pacijent;
        }

        public Pacijent VratiPacijentaPoId(int id)
        {
            return _dbContext.Pacijenti.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Pacijent> VratiSvePacijente()
        {
            return _dbContext.Pacijenti.ToList();
        }
    }
}
