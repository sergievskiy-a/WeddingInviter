using System.Collections.Generic;
using FamilySite.Dtos.Event;

namespace FamilySite.Dtos.Wedding
{
    public class WeddingDto: BaseWeddingDto
    {
        public int Id { get; set; }
        public ICollection<EventDto> Events { get; set; }
    }
}
