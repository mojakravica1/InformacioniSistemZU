using InformacioniSistemZU.Dtos.Responses;

namespace InformacioniSistemZU.BusinessModell.RepositoriesBM
{
    public interface ILekarService
    {
        IEnumerable<LekarDtoResponse> PregledLekara();
    }
}
