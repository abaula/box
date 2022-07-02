
namespace BoxLib.Filters
{
    public interface IComparer
    {
        int Compare(byte[]? left, byte[]? right);
    }
}