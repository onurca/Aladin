using Aladin.Model.Enum;

namespace Aladin.Model
{
    public class Room : Base
    {
        public string Name { get; set; }
        public RoomStatus Status { get; set; }
        public RoomType Type { get; set; }
    }
}
