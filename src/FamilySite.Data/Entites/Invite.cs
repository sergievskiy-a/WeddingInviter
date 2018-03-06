using System;
using System.Collections.Generic;

namespace FamilySite.Data.Entites
{
    public class Invite
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }
}
