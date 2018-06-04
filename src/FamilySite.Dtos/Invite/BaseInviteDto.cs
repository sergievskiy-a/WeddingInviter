namespace FamilySite.Dtos.Invite
{
    public class BaseInviteDto
    {
        public string Alias { get; set; }

        public int? EventId { get; set; }

        public string CustomGreeting { get; set; }

        public string Description { get; set; }

        public bool SuggestHotel { get; set; }
    }
}
