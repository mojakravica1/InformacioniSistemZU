using InformacioniSistemZU.Models;
using static InformacioniSistemZU.Enums.Enums;

namespace InformacioniSistemZU.BusinessModell.ModelsBM
{
    public class LekarBM
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Pol Pol { get; set; }
        public string Opis { get; set; }
        public bool isActive { get; set; }
        public Specijalnost Specijalnost { get; set; }
    }
}
