using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testDemo.Models
{
    public enum Status { InTime, Delayed, Cancelled };
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid  ID { get; set; }
        public string  Origin { get; set; }
        public string Destination { get; set; }
        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
        public Status Status { get; set; }

    }
}
