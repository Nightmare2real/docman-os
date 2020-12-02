using System;
using System.Collections;

namespace Model
{
    public class Document : FileSystemObject
    {
        public Folder Folder { get; }

        //public DateTime CreatedAt { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime LastModified { get; set; }
        //public string FullPath { get; set; }

        public Document(Folder folder = null)=>
            Folder = folder;


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
                if (Folder is not null && Folder.ContainsKey(key))
                    throw new InvalidOperationException("It's not possible to edit parrents fields");
                _fields[key] = value;
            }
        }
    }
}
