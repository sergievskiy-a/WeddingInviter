using System.Collections.Generic;
using FamilySite.Dtos.Guest;

namespace FamilySite.Dtos.Invite
{
    public class UpdateInviteDto : BaseInviteDto
    {
        public ICollection<UpdateGuestDto> Guests { get; set; }
    }
}