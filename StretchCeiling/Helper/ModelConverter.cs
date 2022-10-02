namespace StretchCeiling.Helper
{
    internal static class ModelConverter<T,I> where T : I
    {
        public static List<T> ToModel(List<I> InterfaceCollection)
        {
            if(InterfaceCollection is null)
            {
                return null;
            }

            List<T> collection = new();
            foreach (I item in InterfaceCollection)
            {
                collection.Add((T)item);
            }
            return collection;
        }

        public static List<I> FromModel(List<T> collection)
        {
            if (collection is null)
            {
                return null;
            }

            List<I> interfaceCollection = new();
            foreach (T item in collection)
            {
                interfaceCollection.Add(item);
            }
            return interfaceCollection;
        }
    }
}
