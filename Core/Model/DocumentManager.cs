using System.Collections.Generic;

namespace Model
{
    public static class DocumentManager
    {
        public static List<Folder> Folders { get; } = new List<Folder>();

        public static DocumentContext OpenContext()=>
            new DocumentContext();
    }
}
