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
        public IActionResult GetAll()
        {
            return Ok(_lekarservice.VratiSveLekare());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var lekarExist = _lekarservice.VratiLekaraPoId(id);
            if (lekarExist == null)
            {
                return NotFound();
            }
            return Ok(lekarExist);
        }
        [HttpPost]
        public IActionResult Post(UnesiLekaraDtoRequest unesiLekara)
        {
            var bmLekar = _mapper.Map<LekarDtoResponse>(unesiLekara);
            bmLekar = _lekarservice.UnesiLekara(bmLekar);
            var response = _mapper.Map<UnesiLekaraDtoRequest>(bmLekar);
            return Ok(response);
        }
    }
}
