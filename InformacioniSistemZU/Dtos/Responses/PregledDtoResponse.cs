using InformacioniSistemZU.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformacioniSistemZU.Dtos.Responses
{
    public class PregledDtoResponse
    {
        public DateTime Datum { get; set; }
        public int DijagnozaId { get; set; }
        public int? LekarId { get; set; }
        public int? PacijentId { get; set; }
    }
}
