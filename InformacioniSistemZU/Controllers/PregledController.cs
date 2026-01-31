using InformacioniSistemZU.BusinessModell.Services;
using InformacioniSistemZU.Dtos.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InformacioniSistemZU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PregledController : ControllerBase
    {
        private readonly IPregledService _pregledService;

        public PregledController(IPregledService pregledService)
        {
            _pregledService = pregledService;
        }

        [HttpGet]
        public IActionResult VratiSvePregled()
        { 
            return Ok(_pregledService.VratiSvePreglede());
        }

        [HttpGet("{id:int}")]
        public IActionResult VratiPregledPoId(int id)
        {
            var pregled = _pregledService.VratiPregledPoId(id);
            if (pregled == null)
            {
                return NotFound();
            }
            return Ok(pregled);
        }

        [HttpGet("lekar/{specijalnostid:int}")]
        //opet mislim da ruta nije dobra. Tebi trenutna ruta izgleda ovako - api/Pregled/lekar/1
        //iz nje se ne moze jasno zakljuciti da vracas preglede za specijalnost sa id-em 1, cak je intuitivno da vracas preglede lekara sa id-em 1
        //api/Pregled/Lekar?specijalnostId=1
        //api/Pregled/specijalistickiPregledId=1
        //msm da bi neka od ove 2 bila odgovarajuca. Mrzi me da guglam sad da vidim tacno.
        //Proguglaj,procitaj malo oko pravila rutiranja u REST API-jima
        public IActionResult VratiPregledPoSpecijalnostId(int specijalnostid)
        {
            var pregledi = _pregledService.VratiPregledePoSpecijalnostId(specijalnostid);
            if(pregledi == null)
            {
                return NotFound();
            }
            return Ok(pregledi);
        }

        [HttpPost]
        public IActionResult SacuvajPregled(UnesiPregledDtoRequest unesiPregled)
        {
            var unetiPregled = _pregledService.UnesiPregled(unesiPregled);
            return Ok(unetiPregled);
        }

        [HttpPut("{id:int}")]
        public IActionResult IzmeniPregled (int id, IzmeniPregledDtoRequest izmeniPregled)
        {
            var izmenjeniPregled = _pregledService.IzmeniPregled(id, izmeniPregled);
            if (izmenjeniPregled == null)
            {
                return NotFound();
            }
            return Ok(izmenjeniPregled);
        }


        [HttpDelete("{id:int}")]
        public IActionResult ObrisiPregled(int id)
        {
            var obrisaniPregled = _pregledService.ObrisiPregled(id);
            if (obrisaniPregled == null)
            {
                return NotFound();
            }
            return Ok(obrisaniPregled);
        }
    }
}
