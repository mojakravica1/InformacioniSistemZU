using InformacioniSistemZU.MainDbContext;
using InformacioniSistemZU.Models;
using Microsoft.EntityFrameworkCore;

namespace InformacioniSistemZU.DataModel.Repositories
{
    public class LekarRepository : ILekarRepository
    {
        private readonly MyDbContext _dbContext;

        public LekarRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Lekar IzbrisiLekara(int id)
        {
            var dataLekar = _dbContext.Lekari.FirstOrDefault(x => x.Id == id);
            if (dataLekar == null)
            {
                return null;
            }
            _dbContext.Remove(dataLekar);
            _dbContext.SaveChanges();
            return dataLekar;
        }

        public Lekar IzmeniLekara(int id, Lekar lekar)
        {
            var dataLekar = _dbContext.Lekari.FirstOrDefault(x => x.Id == id);
            if (dataLekar == null)
            {
                return null;
            }
            dataLekar.Ime = lekar.Ime;
            dataLekar.Prezime = lekar.Prezime;
            dataLekar.Jmbg = lekar.Jmbg;
            dataLekar.DatumRodjenja = lekar.DatumRodjenja;
            dataLekar.isActive = lekar.isActive;
            dataLekar.Specijalnost = lekar.Specijalnost;
            _dbContext.SaveChanges();
            return dataLekar;
        }

        public IEnumerable<Lekar> PregledLekara()
        {
            return _dbContext.Lekari.ToList();
        }

        public Lekar PregledLekaraPoId(int id)
        {
            var dataLekar = _dbContext.Lekari.FirstOrDefault(x => x.Id == id);
            if(dataLekar == null)
            {
                return null;
            }
            return dataLekar;
        }

        public Lekar UnesiLekara(Lekar lekar)
        {
            _dbContext.Lekari.Add(lekar);
            _dbContext.SaveChanges();
            return lekar;
        }
    }
}
