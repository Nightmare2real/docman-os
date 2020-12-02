using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IDocumentQueue
    {
        public Task EnqueueAsync(params Document[] documents);

        public Task<Document[]> Dequeue(int nrOfDocuments);        
    }
}