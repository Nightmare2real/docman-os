using Model.Interfaces;
using System.Collections.Generic;

namespace Model
{
    public class DocumentManager
    {
        public IDocumentQueue DocumentQueue { get; set; }

        public static List<Folder> Folders { get; } = new List<Folder>();
        public static List<Document> Documents { get; } = new List<Document>();

        public static DocumentContext OpenContext()=>
            new DocumentContext();

        public static void Add(params Folder[] folders)
        {
            if(folders is not null)
                Folders.AddRange(folders);
        }

        public static void Add(params Document[] documents)
        {
            if (documents is not null)
                Documents.AddRange(documents);
        }
    }
}
