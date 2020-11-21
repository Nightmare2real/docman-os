using System.Collections.Generic;

namespace DocManOSDb
{
    public class Folder
    {
        public long Id { get; set; }
        public string Fields { get; set; }
        public IList<File> Files { get; set; }
    }
}
