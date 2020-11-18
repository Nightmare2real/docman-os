using System;

namespace Model
{
    public class Document : DynamicItem
    {
        public Folder Folder { get; }
        public DynamicItem DocumentType { get; set; }
        public string FileName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string FullPath { get; set; }
  
        public Document(Folder folder = null, DynamicItem documentType = null)
            : base(folder,documentType) =>
            (Folder,DocumentType) = (folder,documentType);
    }
}
