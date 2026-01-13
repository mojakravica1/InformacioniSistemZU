namespace InformacioniSistemZU.Models
{
    public class Pregled
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int DijagnozaId { get; set; }
        public int PacijentId { get; set; }
        public int LekarId { get; set; }
    }
}
