using InformacioniSistemZU.BusinessModell.Services;
using InformacioniSistemZU.Dtos.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InformacioniSistemZU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacijentController : ControllerBase
    {
        private readonly IPacijentService _pacijentService;

        public PacijentController(IPacijentService pacijentService)
        {
            _pacijentService = pacijentService;
        }

        [HttpGet]
        public IActionResult VratiSvePacijente() 
        {
            var sviPacijenti = _pacijentService.VratiSvePacijente();
            return Ok(sviPacijenti);
        }

        [HttpGet("{id:int}")]
        public IActionResult VratiPacijentaPoId(int id)
        {
            var pacijent = _pacijentService.VratiPacijentaPoId(id);
            if (pacijent == null)
            {
                return NotFound();
            }
            return Ok(pacijent);
        }

        [HttpPost]
        public IActionResult SacuvajPacijenta(UnesiPacijentaDtoRequest unesiRequest)
        {
            var unetiPacijent = _pacijentService.UnesiPacijenta(unesiRequest);
            return Ok(unetiPacijent);
        }
    }
}
