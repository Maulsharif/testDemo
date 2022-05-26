using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testDemo.Dto;
using testDemo.IRepo;

namespace testDemo
{
    public class FilterService : IFlightFilter
    {
        private readonly IFlightRepository _repo;
        private readonly IMapper _mapper;
        public FilterService(IFlightRepository repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private IEnumerable<FlightDto> FilterByDest(IEnumerable<FlightDto> flightDtos, string destination)
        {
            return flightDtos?.Where(f => f.Destination == destination).OrderBy(p => p.Arrival);
        }

        private IEnumerable<FlightDto> FilterByOrigin(IEnumerable<FlightDto> flightDtos, string origin )
        {
            return flightDtos?.Where(f => f.Origin == origin).OrderBy(p => p.Arrival);
        }

        public async Task<IEnumerable<FlightDto>> FilterByOriginAndDest(string origin, string destination)
        {
            var fligths = await _repo.GetAllFlights();
            var result = _mapper.Map<IEnumerable<FlightDto>>(fligths); 
           
             if(origin != null && destination == null)
            {
                return FilterByOrigin(result,origin);
            }
            else if (origin != null && destination != null)
            {
                return FilterByDest(result, origin);
            }
            else if (origin != null && destination != null)
            {
                return result.Where(f=>f.Origin == origin && f.Destination == destination).OrderBy(p => p.Arrival);
            }
            return result.OrderBy(p => p.Arrival);

        }
    }
}
