using InformacioniSistemZU.Models;
using static InformacioniSistemZU.Enums.Enums;

namespace InformacioniSistemZU.Dtos.Responses
{
    public class LekarDtoResponse
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Pol Pol { get; set; }
        public string Opis { get; set; }
        public bool IsActive { get; set; }
        public int SpecijalnostId { get; set; } //TODO smo promenili. U ovom slucaju bi trebalo da napravimo SpecijalnostController koji vraca sifarnik (u realnom svetu). Sad ga ne pravis
        //public string Specijalnost { get; set; } // moze i ovako umesto ovog iznad

    }
}
