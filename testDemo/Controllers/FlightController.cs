using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
        private readonly IFlightFilter _filter;
        public FlightController(IFlightRepository repo, IMapper mapper, IFlightFilter flightFilter)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _filter = flightFilter ?? throw new ArgumentNullException(nameof(flightFilter));
        }

        [Route("get")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDto>>> GetAllFlights(string origin = null, string destination = null)
        {
            var fligths = await _filter.FilterByOriginAndDest(origin, destination);
            if(fligths != null)
                 return Ok(fligths);
            return NoContent();
           
        }

        [Route("create")]
        [HttpPost, Authorize(Roles = "Moderator")]
        public async Task<ActionResult<Flight>> Create([FromBody] FlightDto flightDto)
        {
            var flightModel = _mapper.Map<Flight>(flightDto);
            return  Ok(await _repo.CreateFlight(flightModel)); 
        }

        [Route("edit")]
        [HttpPost, Authorize(Roles = "Moderator")]
        public async Task<ActionResult> EditStatus([FromBody] FlightEditDto flightEditDto)
        {
           await  _repo.EditFlight(flightEditDto);
           return Ok();
        }
    }
}
