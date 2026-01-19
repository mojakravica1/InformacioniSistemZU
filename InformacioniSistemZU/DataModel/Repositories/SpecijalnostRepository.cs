using InformacioniSistemZU.MainDbContext;
using InformacioniSistemZU.Models;

namespace InformacioniSistemZU.DataModel.Repositories
{
    public class SpecijalnostRepository : ISpecijalnostRepository
    {
        private readonly MyDbContext _dbContext;

        public SpecijalnostRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Specijalnost DaLiPostoji(int id)
        {
            var daLiPostoji =  _dbContext.Specijalnosti.FirstOrDefault(x => x.Id == id);
            if (daLiPostoji == null)
            {
                return null;
            }
            return daLiPostoji;
        }
    }
}
