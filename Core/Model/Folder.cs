using System;
using System.Collections.Generic;

namespace Model
{
    public class Folder
    {
        public Folder ParrentFolder { get; init; }

        public Folder(Folder folder = null) =>
            ParrentFolder = folder;

        public List<Document> Documents { get; init; } = new();

        private readonly Dictionary<string, object> _fields = new();

        public object this[string key]
        {
            get
            {
                if(_fields.ContainsKey(key))
                    return _fields[key];
                if (ParrentFolder != null)
                    return ParrentFolder[key];
                throw new KeyNotFoundException();
            }
            set
            {
                if(ParrentFolder != null && ParrentFolder.ContainsKey(key))
                    throw new InvalidOperationException("It's not possible to edit parrents fields");
                _fields[key] = value;
            }
        }

        public bool ContainsKey(string key) =>
            _fields.ContainsKey(key);
    }
}