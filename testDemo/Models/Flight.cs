using System;

namespace testDemo.Models
{
    public enum Status { InTime, Delayed, Cancelled };
    public class Flight
    {
        public string  ID { get; set; }
        public string  Origin { get; set; }
        public string Destination { get; set; }
        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
        public Status Status { get; set; }

    }
}
