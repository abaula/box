
namespace BoxLib.Filters
{
    public interface IFilter
    {
        bool IsTrue(byte[] value);
    }
}