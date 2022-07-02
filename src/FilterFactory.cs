using BoxLib.Filters.Builder;

namespace BoxLib
{
    public static class FilterFactory
    {
        public static IBuilder Create()
        {
            return new Builder();
        }
    }
}