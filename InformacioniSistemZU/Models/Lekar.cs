using static InformacioniSistemZU.Enums.Enums;

namespace InformacioniSistemZU.Models
{
    public class Lekar
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Pol Pol {get; set; }
        public string Opis { get; set; }
        public bool isActive { get; set; }
        public Specijalnost Specijalnost { get; set; }
    }
}
