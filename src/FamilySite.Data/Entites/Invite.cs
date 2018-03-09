using System.Collections.Generic;

namespace FamilySite.Data.Entites
{
    public class Invite
    {
        public int Id { get; set; }
        public int WeddingId { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }

        public Wedding Wedding { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }
}
