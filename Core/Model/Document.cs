using System;
using System.Collections.Generic;

namespace Model
{
    public class Document
    {
        public Folder Folder { get; }
        //public string FileName { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime LastModified { get; set; }
        //public string FullPath { get; set; }

        private readonly Dictionary<string, object> _fields = new();
  
        public Document(Folder folder)=>
            Folder = folder ?? throw new ArgumentNullException(nameof(folder));


        public object this[string key]
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
