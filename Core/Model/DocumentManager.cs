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

        public static void Add(Folder folder)
        {
            Folders.Add(folder);
        }

        public static void Add(params Document[] documents)
        {
            if (documents is not null)
            {
                Documents.AddRange(documents);
            }
        }
    }
}
