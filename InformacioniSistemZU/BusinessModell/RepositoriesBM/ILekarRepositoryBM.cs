using InformacioniSistemZU.BusinessModell.ModelsBM;

namespace InformacioniSistemZU.BusinessModell.RepositoriesBM
{
    public interface ILekarRepositoryBM
    {
        IEnumerable<LekarBM> PregledLekara();
    }
}
