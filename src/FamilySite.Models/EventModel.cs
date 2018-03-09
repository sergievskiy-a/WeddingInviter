using System;
using System.Collections.Generic;

namespace FamilySite.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int? LocationId { get; set; }

        public LocationModel Location { get; set; }
    }
}
