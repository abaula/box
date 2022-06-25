
namespace BoxLib.Terms
{
    public interface ITerm
    {
        long Id { get; }
        byte[] Hash { get; }
        long Size { get; }
        ValueTask<IEnumerable<byte>> GetValue();
    }
}