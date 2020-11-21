using Microsoft.EntityFrameworkCore;

namespace DocManOSDb
{
    public class DocManOSCtx : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<Folder> Folders { get; set; }
    }
}
