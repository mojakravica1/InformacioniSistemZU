using System.ComponentModel.DataAnnotations.Schema;

namespace InformacioniSistemZU.Models
{
   public class Pregled
    {
          public int Id { get; set; }
          public DateTime Datum { get; set; }
          public Dijagnoza Dijagnoza { get; set; }
         
          // FK prema lekaru
          public int? LekarId { get; set; }
          [ForeignKey(nameof(LekarId))]
          public Lekar Lekar { get; set; }

          // FK prema pacijentu
          public int? PacijentId { get; set; }
          [ForeignKey(nameof(PacijentId))]
          public Pacijent Pacijent { get; set; }

    }
}
