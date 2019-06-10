using Framework.Model.Logger.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Model.Logger
{
    [Table("Info", Schema = "General")]
    public class Info : AuditableEntity
    {
        public Info()
        {

        }

        public Info(string message,string location, InfoType type)
        {
            Message = message;
            Location = location;
            Type = type;
        }

        public string Location { get; set; }
        public string Message { get; set; }
        public InfoType Type { get; set; }
    }

}
