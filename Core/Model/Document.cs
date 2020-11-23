using System;

namespace Model
{
    public class Document : FileSystemObject
    {
        public Folder Folder { get; }

        //public string FileName { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime LastModified { get; set; }
        //public string FullPath { get; set; }

        public Document(Folder folder)=>
            Folder = folder ?? throw new ArgumentNullException(nameof(folder));


        public override object this[string key]
        {
            get
            {
                if (_fields.ContainsKey(key))
                    return _fields[key];
                
                return Folder[key];
            }
            set
            {
                if (Folder.ContainsKey(key))
                    throw new InvalidOperationException("It's not possible to edit parrents fields");
                _fields[key] = value;
            }
        }
    }
}
