using Framework.Model.Logger.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Model.Logger
{
    [Table("Log", Schema = "General")]
    public class Log : AuditableEntity
    {
        public LogLevel LogLevel { get; set; }
        public string Location { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
