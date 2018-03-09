using System.Collections.Generic;

namespace FamilySite.Data.Entites
{
    public class Wedding
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Hashtag { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Invite> Invites { get; set; }
    }
}
