using FamilySite.Dtos.Location;

namespace FamilySite.Dtos.Event
{
    public class EventDto: BaseEventDto
    {
        public int Id { get; set; }
        public LocationDto Location { get; set; }
    }
}
