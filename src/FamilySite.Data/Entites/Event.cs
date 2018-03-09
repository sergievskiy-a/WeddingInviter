using System;

namespace FamilySite.Data.Entites
{
    public class Event
    {
        public int Id { get; set; }
        public int WeddingId { get; set; }

        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime{ get; set; }
        public int? LocationId { get; set; }

        public Wedding Wedding { get; set; }
        public Location Location { get; set; }
    }
}
