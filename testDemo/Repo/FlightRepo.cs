using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testDemo.Data;
using testDemo.Dto;
using testDemo.IRepo;
using testDemo.Models;

namespace testDemo.Repo
{
    public class FlightRepo : IFlightRepository
    {
        private readonly AppDbContext _appDbContext;
        public FlightRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async  Task<Flight> CreateFlight(Flight flight)
        {
            var result = await _appDbContext.Flights.AddAsync(flight);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public  async Task EditFlight( FlightEditDto flightEditDto)
        {
            var result = await _appDbContext.Flights
               .FirstOrDefaultAsync(e => e.ID.ToString() == flightEditDto.Id);

            if (result != null)
            {  
                result.Status = flightEditDto.Status;
                await _appDbContext.SaveChangesAsync();
            }
           
        }

        public  async Task<IEnumerable<Flight>> GetAllFlights()
        {
           return await _appDbContext.Flights.ToListAsync();
        }
      
    }
}
