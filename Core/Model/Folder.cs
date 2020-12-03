using System;
using System.Collections.Generic;

namespace Model
{
    public class Folder: FileSystemObject
    {
        public Folder ParrentFolder { get; init; }

        public List<Folder> SubFolders { get; set; } = new();

        public List<Document> Documents { get; init; } = new();

        public Folder(Folder folder = null)
        {
            ParrentFolder = folder;
        }

        public override object this[string key]
        {
            get => Get<object>(key);
            set => Set(key, value);
        }

        public bool ContainsKey(string key) =>
            _fields.ContainsKey(key);

        public override void Set(string key, object value)
        {
            if (ParrentFolder != null && ParrentFolder.ContainsKey(key))
                throw new InvalidOperationException("It's not possible to edit parrents fields");
            _fields[key] = value;
        }

        public override T Get<T>(string key)
        {
            if (_fields.ContainsKey(key))
                return (T)_fields[key];
            if (ParrentFolder != null)
                return (T)ParrentFolder[key];
            throw new KeyNotFoundException();
        }
    }
}