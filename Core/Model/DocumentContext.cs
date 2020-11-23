using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Model
{
    public class DocumentContext : IDisposable
    {
        public ObservableCollection<Folder> Folders { get; set; } = new ObservableCollection<Folder>();
        public void Dispose()
        {
            
        }

        public async Task SaveChangesAsync()
        {
            DocumentManager.Folders.AddRange(Folders);
            await Task.Delay(10);
        }
    }
}
