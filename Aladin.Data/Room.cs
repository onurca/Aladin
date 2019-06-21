using Aladin.Data.Enum;
using Framework.Model;

namespace Aladin.Data
{
    public class Room : AuditableEntity
    {
        public string Name { get; set; }
        public RoomStatus Status { get; set; }
        public RoomType Type { get; set; }
    }
}
