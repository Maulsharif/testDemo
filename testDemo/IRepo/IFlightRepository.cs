using System.Collections.Generic;
using System.Threading.Tasks;
using testDemo.Dto;
using testDemo.Models;

namespace testDemo.IRepo
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetAllFlights();
        Task<Flight>CreateFlight(Flight flight);
        Task EditFlight(FlightEditDto flightEditDto);
    }
}
