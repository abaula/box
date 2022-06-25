
namespace BoxLib.Terms
{
    public interface ITerms
    {
        ValueTask<ITerm> GetTerm(long termId);
    }
}