using InformacioniSistemZU.MainDbContext;
using InformacioniSistemZU.Models;
using Microsoft.EntityFrameworkCore;

namespace InformacioniSistemZU.DataModel.Repositories
{
    public class PregledRepository : IPregledRepository
    {
        private readonly MyDbContext _dbContext;

        public PregledRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Pregled IzmeniPregled(int id, Pregled pregled)
        {
            ArgumentNullException.ThrowIfNull(pregled);

            var dataPregled = _dbContext.Pregledi.FirstOrDefault(x => x.Id == id);
            if (dataPregled == null)
            {
                return null;
            }
            dataPregled.Datum = pregled.Datum;
            dataPregled.Dijagnoza = pregled.Dijagnoza;
            dataPregled.PacijentId = pregled.PacijentId;
            dataPregled.LekarId = pregled.LekarId;
            _dbContext.SaveChanges();
            return dataPregled;
        }

        public Pregled ObrisiPregled(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var dataPregled = _dbContext.Pregledi.FirstOrDefault(x => x.Id == id);
            if (dataPregled == null)
            {
                return null;
            }
            _dbContext.Pregledi.Remove(dataPregled);
            _dbContext.SaveChanges();
            return dataPregled;
        }

        public Pregled UnesiPregled(Pregled pregled)
        {
            ArgumentNullException.ThrowIfNull(pregled);

            _dbContext.Pregledi.Add(pregled);
            _dbContext.SaveChanges();
            return pregled;
        }

        public Pregled VratiPregledPoId(int id)
        {
            return _dbContext.Pregledi.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Pregled> VratiSvePreglede()
        {
            return _dbContext.Pregledi.Include(p => p.Lekar).ToList();
        }
    }
}
