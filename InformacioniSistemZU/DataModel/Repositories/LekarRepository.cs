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
            if (id <= 0) //ovo se zove defanzivno programiranje. Ako neko prosledi parametre koji nemaju veze sa vezom, u startu ga izbacis iz metode. Nije obavezno svakako ali je pozeljno na nekom nivou
            {
                throw new ArgumentOutOfRangeException();
            }

            var dataLekar = _dbContext.Lekari.FirstOrDefault(x => x.Id == id);
            if (dataLekar == null)
            {
                return null; //izbegavaj da vracas null; ima nekoliko misljenja sta treba da se vrati (pricacemo), ali null skoro pa nikad
            }
            _dbContext.Remove(dataLekar);
            _dbContext.SaveChanges();
            return dataLekar; //sto ovde vracas objekar lekara?
        }

        public Lekar IzmeniLekara(int id, Lekar lekar)
        {
            ArgumentNullException.ThrowIfNull(lekar); //defanzivno programiranje

            var dataLekar = _dbContext.Lekari.FirstOrDefault(x => x.Id == id);
            if (dataLekar == null)
            {
                return null; //izbegavaj da vracas null; ima nekoliko misljenja sta treba da se vrati (pricacemo), ali null skoro pa nikad
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
            
            /*
            if(dataLekar == null)
            {
                return null; //ovaj ceo IF deo koda ti je visak, pogledaj opet. Moze isti kod kao kod PregledLekara(). (ovde i ima smisla da se vrati null) 
            }*/
            return dataLekar;
        }

        public Lekar UnesiLekara(Lekar lekar)
        {
            ArgumentNullException.ThrowIfNull(lekar); //defanzivno programiranje

            _dbContext.Lekari.Add(lekar);
            _dbContext.SaveChanges();
            return lekar;
        }
    }
}
