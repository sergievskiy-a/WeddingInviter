using System.Collections.Generic;
using FamilySite.Dtos.Guest;

namespace FamilySite.Dtos.Invite
{
    public class CreateInviteDto : BaseInviteDto
    {
        public ICollection<BaseGuestDto> Guests { get; set; }
    }
}