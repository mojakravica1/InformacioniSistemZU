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

        //ispravna ruta bi bila Lekar/1/pacijenti napisi je u takvom obliku
        [HttpGet("pacijenti/{lekarid:int}")]
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
        [HttpGet("pretrage/{ime}")]
        public IActionResult VratiLekarePoImenu(string ime)
        {
            var lekari = _lekarservice.VratiLekarePoImenu(ime);
            if (lekari == null)
            {
                return NotFound();
            }
            return Ok(lekari);
        }

        //ovde vracas preglede. Znaci glavni RESURS ti je pregled. Prema tome trebalo bi da ide u taj kontroler
        //pravilo za rutiranje isto kao kod pretrage lekara po nazivu
        [HttpGet("specijalnost/{id}")]
        public IActionResult VratiPregledePoSpecijalnostId(int id)
        {
            var pregledi = _lekarservice.VratiPregledePoSpecijalnostId(id);
            if (pregledi == null)
            {
                return NotFound();
            }
            return Ok(pregledi);
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
