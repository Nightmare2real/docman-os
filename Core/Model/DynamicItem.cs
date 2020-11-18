namespace Model
{
    public class DynamicItem
    {
        public DynamicItem(DynamicItem parrent = null, DynamicItem type = null) =>
                Fields = new DynamicField(parrent,type);

        public DynamicField Fields { get; init; }

    }
}
