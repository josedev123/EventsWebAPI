using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsWebAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public DateTime Date { get; set; }
        public bool Free { get; set; }
    }
}
