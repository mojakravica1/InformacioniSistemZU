using AutoMapper;
using InformacioniSistemZU.BusinessModell.RepositoriesBM;
using InformacioniSistemZU.Dtos.Requests;
using InformacioniSistemZU.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InformacioniSistemZU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LekarController : ControllerBase
    {
        private readonly ILekarService _lekarservice;
        private readonly IMapper _mapper;

        public LekarController(ILekarService lekarService, IMapper mapper)
        {
            _lekarservice = lekarService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult VratiSveLekare()
        {
            return Ok(_lekarservice.VratiSveLekare());
        }

        [HttpGet("{id:int}")]
        public IActionResult VratiLekaraPoId(int id)
        {
            var lekarExist = _lekarservice.VratiLekaraPoId(id);
            if (lekarExist == null)
            {
                return NotFound();
            }
            return Ok(lekarExist);
        }

       
        [HttpGet("{lekarid:int}/pacijenti")]
        public IActionResult VratiPacijentePoIdLekara(int lekarid)
        {
            var pacijenti = _lekarservice.VratiPacijentePoIdLekara(lekarid);
            return Ok(pacijenti);
        }

        //ispravna ruta bi bila Lekar
        //na primer Lekar?ime='Nikola'
        //vidi ovde pokasnjenje primer: https://stackoverflow.com/questions/4024271/rest-api-best-practices-where-to-put-parameters
        //mozes da napravis i jednu zajednicku metodu gde bi u query parametru stavio sve filtere pretrage
        //ali prvo odradi ove pojedinacne, mada je zajednicka metoda najbolje resenje
        //npr: Lekar?ime='Nikola'&specijalnostId=1&jmbg=1234
        [HttpGet("{ime}")]
        public IActionResult VratiLekarePoImenu(string ime)
        {
            var lekari = _lekarservice.VratiLekarePoImenu(ime); //i dalje mislim da bi bolja ruta bila ova koju sam predlozio - api/Lekar?ime='Nikola'.
                                                                //tvoja trenutna ruta je - api/Lekar/Nikola . Svakako ce raditi i sa njom, ovo su finese
                                                                //Nisi uspeo da izvedes ili si nasao neko drugo misljenje po netu?
                                                                //Fali ti i validacija po polu (stoji u zahtevu).
            if (lekari == null)
            {
                return NotFound();
            }
            return Ok(lekari);
        }


        [HttpPost]
        public IActionResult SacuvajLekara(UnesiLekaraDtoRequest unesiLekara)
        {
            var unetiLekar = _lekarservice.UnesiLekara(unesiLekara);
           
            return Ok(unetiLekar);
        }

        [HttpPut("{id:int}")]
        public IActionResult IzmeniLekara(int id, IzmeniLekaraDtoRequest izmeniLekara)
        {
            var izmenjeniLekar = _lekarservice.IzmeniLekara(id, izmeniLekara);
            if (izmenjeniLekar == null)
            {
                return NotFound();
            }
            return Ok(izmenjeniLekar);
        }

        [HttpDelete("{id:int}")]
        public IActionResult ObrisiLekara(int id)
        {
            var obrisaniLekar = _lekarservice.ObrisiLekara(id);
            if (obrisaniLekar == null)
            {
                return NotFound();
            }
            return Ok(obrisaniLekar);
        }
    }
}
