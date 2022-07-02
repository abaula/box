
namespace BoxLib.Filters.Builder
{
    public interface IBuilder
    {
        IFilter Build();
        IBuilder And(Func<IConditionBuilder, IConditionBuilder> group);
        IBuilder Or(Func<IConditionBuilder, IConditionBuilder> group);
    }
}