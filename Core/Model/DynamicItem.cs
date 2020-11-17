namespace Model
{
    public class DynamicItem
    {
        public DynamicItem(DynamicItem parrent = null)
        {
            if (parrent != null)
                Fields = new DynamicField(parrent);
            else
                Fields = new DynamicField();
        }
        public DynamicField Fields { get; init; }

    }
}
