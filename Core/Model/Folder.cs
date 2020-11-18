namespace Model
{
    public class Folder : DynamicItem
    {
        public DynamicItem FolderType { get; init; }

        public Folder(DynamicItem folderType = null) : base(type: folderType) =>
            FolderType = folderType;
    }
}