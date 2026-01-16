using InformacioniSistemZU.BusinessModell.RepositoriesBM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InformacioniSistemZU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LekarController : ControllerBase
    {
        private readonly ILekarService _repositoryBM;

        public LekarController(ILekarService repositoryBM)
        {
            _repositoryBM = repositoryBM;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repositoryBM.PregledLekara());
        }
    }
}
