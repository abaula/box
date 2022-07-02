using BoxLib.Filters;

namespace BoxLib
{
    public static class ComparerFactory
    {
        public static IComparer GetDefault()
        {
            return new BinaryComparer();
        }
    }
}