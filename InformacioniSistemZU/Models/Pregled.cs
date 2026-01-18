namespace InformacioniSistemZU.Models
{
    public class Pregled
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public Dijagnoza Dijagnoza { get; set; }
        public Pacijent Pacijent { get; set; }
        public Lekar Lekar { get; set; }
    }
}
