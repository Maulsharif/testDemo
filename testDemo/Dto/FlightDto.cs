using System;
using System.ComponentModel.DataAnnotations;
using testDemo.Models;

namespace testDemo.Dto
{
    public class FlightDto
    {
        [MaxLength(3)]
        public string Origin { get; set; }
        [MaxLength(3)]
        public string Destination { get; set; }
        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
        public Status Status { get; set; }
    }
}
