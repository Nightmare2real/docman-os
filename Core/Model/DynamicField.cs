using System.Collections.Generic;

namespace Model
{
    public class DynamicField
    {
        private readonly Dictionary<string, object> _fields = new Dictionary<string, object>();
        private readonly DynamicItem _parrent;
        private readonly DynamicItem _type;

        public DynamicField(DynamicItem parrent = null, DynamicItem type = null)=>
            (_parrent,_type) = (parrent,type);

        public object this[string key]
        {
            get {

                if (_fields.ContainsKey(key))
                    return _fields[key];
                else if (_type != null && _type.Fields.ContainsKey(key))
                    return _type.Fields[key];
                else if (_parrent != null && _parrent.Fields.ContainsKey(key))
                    return _parrent.Fields[key];
                else
                    throw new KeyNotFoundException(key);
            }
            set => _fields[key] = value;
        }

        public bool ContainsKey(string key) =>
            _fields.ContainsKey(key);
    }
}
