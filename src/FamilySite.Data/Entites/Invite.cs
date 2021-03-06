﻿using System.Collections.Generic;

namespace FamilySite.Data.Entites
{
    public class Invite
    {
        public int Id { get; set; }
        public int WeddingId { get; set; }
        public int? EventId { get; set; }
        public string Alias { get; set; }
        public string CustomGreeting { get; set; }
        public string Description { get; set; }
        public bool SuggestHotel { get; set; }

        public InviteAnswer InviteAnswer { get; set; }
        public Event Event { get; set; }
        public Wedding Wedding { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
    }
}
