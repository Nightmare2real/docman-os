using System;

namespace Model
{
    public class Document : FileSystemObject
    {
        public Folder Folder { init; get; }

        //public DateTime CreatedAt { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime LastModified { get; set; }
        //public string FullPath { get; set; }

        //public Document(Folder folder = null)=>
        //    Folder = folder;


        public override object this[string key]
        {
            get => Get<object>(key);
            set => Set(key, value);
        }


        public override T Get<T>(string key)
        {
            if (_fields.ContainsKey(key))
                return (T)_fields[key];

            return (T)Folder[key];
        }

        public override void Set(string key, object value)
        {
            if (Folder is not null && Folder.ContainsKey(key))
                throw new InvalidOperationException("It's not possible to edit parrents fields");
            _fields[key] = value;
        }
    }
}
