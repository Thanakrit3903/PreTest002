using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterMember.Model
{
    public class Members
    {
        public int id { get; set; }
        public string username { get; set; } = string.Empty;
        [Column("passwordhash")]
        public string passwordHash { get; set; } = string.Empty;
        [Column("createdat")]
        public DateTime createdAt { get; set; }
    }
}
