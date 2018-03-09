using System;

namespace FamilySite.Dtos.Event
{
    public class BaseEventDto
    {
        public int WeddingId { get; set; }

        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int? LocationId { get; set; }
    }
}
