namespace Model
{
    public class Document : DynamicItem
    {
        public Document(Folder folder = null) : base(folder)
        {
            Folder = folder;
        }

        public Folder Folder { get; }
    }
}
