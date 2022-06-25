
namespace BoxLib.Documents
{
    public interface IDocument
    {
        long Id { get; }
        ValueTask<long[]> GetTermIds(long fieldId);
    }
}