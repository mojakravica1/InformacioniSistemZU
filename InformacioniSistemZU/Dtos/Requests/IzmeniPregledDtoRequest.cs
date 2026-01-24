namespace InformacioniSistemZU.Dtos.Requests
{
    public class IzmeniPregledDtoRequest
    {
        public DateTime Datum { get; set; }
        public int DijagnozaId { get; set; }
        public int? LekarId { get; set; }
        public int? PacijentId { get; set; }
    }
}
