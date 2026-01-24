namespace InformacioniSistemZU.Dtos.Requests
{
    public class UnesiPregledDtoRequest
    {
        public DateTime Datum { get; set; }
        public int DijagnozaId { get; set; }
        public int? LekarId { get; set; }
        public int? PacijentId { get; set; }
    }
}
