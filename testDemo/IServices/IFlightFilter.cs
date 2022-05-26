using System.Collections.Generic;
using System.Threading.Tasks;
using testDemo.Dto;

namespace testDemo
{
    public interface IFlightFilter
    {
        Task<IEnumerable<FlightDto>> FilterByOriginAndDest(string origin, string destination);
        
    }
}
