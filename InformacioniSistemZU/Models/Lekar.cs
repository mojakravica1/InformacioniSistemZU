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
        public Pol Pol { get; set; }
        public string Opis { get; set; }
        public bool IsActive { get; set; }
        public Specijalnost Specijalnost { get; set; }
        public int SpecijalnostId { get; set; }
        // Navigacija: jedan lekar ima više pacijenata
        public ICollection<Pacijent> Pacijenti { get; set; } = new List<Pacijent>();
        // Navigacija: jedan lekar ima više pregleda
        public ICollection<Pregled> Pregledi { get; set; } = new List<Pregled>();
    }
}
