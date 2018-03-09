using FamilySite.Dtos.Location;

namespace FamilySite.Dtos.Event
{
    public class CreateEventDto: BaseEventDto
    {
        public int Id { get; set; }
        public LocationDto Location { get; set; }
    }
}
