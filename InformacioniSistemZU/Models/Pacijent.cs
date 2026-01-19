using static InformacioniSistemZU.Enums.Enums;

namespace InformacioniSistemZU.Models
{
    public class Pacijent
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Pol Pol {  get; set; }
        public DateTime DatumKreiranja { get; set; }
        public bool IsActive { get; set; }
        public Lekar Lekar { get; set; }
        public int? LekarId { get; set; }
        // Navigacija: pacijent može imati više pregleda
        public ICollection<Pregled> Pregledi { get; set; } = new List<Pregled>();

    }
}
