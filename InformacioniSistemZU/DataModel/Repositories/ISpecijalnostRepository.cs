using InformacioniSistemZU.Models;

namespace InformacioniSistemZU.DataModel.Repositories
{
    public interface ISpecijalnostRepository
    {
        Specijalnost DaLiPostoji(int id); //Nikola: Promeni naziv. Ovaj naziv sugerise da vracas true/false vrednost a ne objekat. Ali svakako nazovi metodu VratiPoIdu ili GetById
    }
}
