using System;
using FamilySite.Dtos.Location;

namespace FamilySite.Dtos.Event
{
    public class GetEventDto: BaseEventDto
    {
        public LocationDto Location { get; set; }
    }
}
