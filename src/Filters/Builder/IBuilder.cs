
namespace BoxLib.Filters.Builder
{
    public interface IBuilder
    {
        IFilter Build();
        IBuilder And(Func<ICondition, ICondition> group);
        IBuilder Or(Func<ICondition, ICondition> group);
    }
}