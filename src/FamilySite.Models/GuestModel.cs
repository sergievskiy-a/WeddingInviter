using System;

namespace FamilySite.Models
{
    public class GuestModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool FromGroom { get; set; }
        public Guid InviteId { get; set; }
    }
}
