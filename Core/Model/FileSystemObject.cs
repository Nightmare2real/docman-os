using System.Collections.Generic;

namespace Model
{
    public abstract class FileSystemObject
    {
        public long Id { get; init; }
        private protected readonly Dictionary<string, object> _fields = new();

        public abstract object this[string key]
        {
            get;set;
        }

        public T Get<T>(string key) => (T)_fields[key];
    }
}
