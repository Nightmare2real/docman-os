using System.Collections.Generic;

namespace Model
{
    public abstract class FileSystemObject
    {
        public long Id { get; init; }
        public string Name { get; set; }
        
        private protected readonly Dictionary<string, object> _fields = new();

        public abstract object this[string key]
        {
            get;set;
        }

        public abstract T Get<T>(string key);

        public abstract void Set(string key, object value);        
    }
}
