using System;

namespace Aladin.Model
{
    public class File : Base
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
