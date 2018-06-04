using System.Collections.Generic;

namespace FamilySite.Models
{
    public class InviteModel
    {
        public int Id { get; set; }

        public int? EventId { get; set; }

        public string Alias { get; set; }

        public string CustomGreeting { get; set; }

        public bool SuggestHotel { get; set; }

        public string Description { get; set; }

        public ICollection<GuestModel> Guests { get; set; }
    }
}
