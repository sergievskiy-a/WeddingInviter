using System.ComponentModel.DataAnnotations.Schema;

namespace FamilySite.Data.Entites
{
    public class InviteAnswer
    {
        public int Id { get; set; }

        public bool Going { get; set; }

        public bool NeedHotel { get; set; }

        public string Comment { get; set; }

        public int InviteId { get; set; }

        public Invite Invite { get; set; }
    }
}
