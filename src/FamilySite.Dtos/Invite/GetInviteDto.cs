using System.Collections.Generic;
using FamilySite.Dtos.Guest;
using FamilySite.Dtos.Wedding;

namespace FamilySite.Dtos.Invite
{
    public class GetInviteDto : BaseInviteDto
    {
        public int Id { get; set; }

        public InviteAnswerDto Answer { get; set; }
        public WeddingDto Wedding { get; set; }
        public ICollection<GetGuestDto> Guests { get; set; }
    }
}