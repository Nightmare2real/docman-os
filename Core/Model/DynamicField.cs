using System.Collections.Generic;

namespace Model
{
    public class DynamicField
    {
        private readonly Dictionary<string, object> _fields = new Dictionary<string, object>();
        private DynamicItem _parrent;

        public DynamicField(DynamicItem parrent = null)=>
            _parrent = parrent;

        public object this[string key]
        {
            get
            {
              return  _fields.ContainsKey(key) ? _fields[key] : _parrent != null ? _parrent.Fields[key] : throw new KeyNotFoundException();
            }
            set => _fields[key] = value;
        }
    }
}
