namespace FamilySite.Data.Entites
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool FromGroom { get; set; }
        public int InviteId { get; set; }

        public Invite Invite { get; set; }
    }
}
