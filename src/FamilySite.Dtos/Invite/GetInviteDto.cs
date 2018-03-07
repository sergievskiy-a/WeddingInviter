using System.Collections.Generic;
using FamilySite.Dtos.Guest;

namespace FamilySite.Dtos.Invite
{
    public class GetInviteDto : BaseInviteDto
    {
        public int Id { get; set; }
        public ICollection<GetGuestDto> Guests { get; set; }
    }
}