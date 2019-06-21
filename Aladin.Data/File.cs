using Framework.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aladin.Data
{
    [Table("File", Schema = "Aladin")]
    public class File : AuditableEntity
    {
        public string Name { get; set; }
        public Guid GuidName { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public Guid ReferenceGuid { get; set; }
        public int Order { get; set; }
    }
}
