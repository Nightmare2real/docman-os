using System.Collections.Generic;

namespace Model
{
    public static class DocumentManager
    {
        public static List<Folder> Folders { get; } = new List<Folder>();
        public static List<Document> Document { get; } = new List<Document>();

        public static DocumentContext OpenContext()=>
            new DocumentContext();
    }
}
