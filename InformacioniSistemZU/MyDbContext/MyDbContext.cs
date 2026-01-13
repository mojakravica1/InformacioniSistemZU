using InformacioniSistemZU.Models;
using Microsoft.EntityFrameworkCore;

namespace InformacioniSistemZU.MyDbContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        public DbSet<Dijagnoza> Dijagnoze { get; set; }
        public DbSet<Lekar> Lekari { get; set; }
        public DbSet<Pacijent> Pacijenti { get; set; }
        public DbSet<Pregled> Pregledi {  get; set; }
        public DbSet<Specijalnost> Specijalnosti { get; set; }
    }
}
