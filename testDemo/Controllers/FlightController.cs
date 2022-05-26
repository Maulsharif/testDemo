using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testDemo.Dto;
using testDemo.IRepo;
using testDemo.Models;

namespace testDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        
       // private readonly ILogger<FlightController> _logger;
        private readonly IFlightRepository _repo;
        private readonly IMapper _mapper;
        public FlightController(IFlightRepository repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Route("get")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDto>>> GetAllFlights()
        {
            var res =  await _repo.GetAllFlights();
            return Ok(_mapper.Map<IEnumerable<FlightDto>>(res));

        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<Flight>> Create([FromBody] FlightDto flightDto)
        {
            var flightModel = _mapper.Map<Flight>(flightDto);
            return  Ok(await _repo.CreateFlight(flightModel)); 
        }

        [Route("edit")]
        [HttpPost]
        public async Task<ActionResult> EditStatus([FromBody] FlightEditDto flightEditDto)
        {
           await  _repo.EditFlight(flightEditDto);
            return Ok();
        }
    }
}
