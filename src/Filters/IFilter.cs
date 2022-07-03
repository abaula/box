
namespace BoxLib.Filters
{
    public interface IFilter
    {
        bool Pass(byte[]? value);
        internal ConditionGroup RootConditionGroup { get; }
    }
}