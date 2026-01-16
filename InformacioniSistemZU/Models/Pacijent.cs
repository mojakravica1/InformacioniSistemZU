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
        public int LekarId { get; set; }
    }
}
