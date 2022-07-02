
namespace BoxLib.Filters.Builder
{
    public interface IConditionBuilder
    {
        IConditionBuilder Equal(byte[]? value, IComparer comparer);
        IConditionBuilder NotEqual(byte[]? value, IComparer comparer);
        IConditionBuilder GreaterThan(byte[]? value, IComparer comparer);
        IConditionBuilder GreaterOrEqualThan(byte[]? value, IComparer comparer);
        IConditionBuilder LessThan(byte[]? value, IComparer comparer);
        IConditionBuilder LessOrEqualThan(byte[]? value, IComparer comparer);
        IConditionBuilder And(Func<IConditionBuilder, IConditionBuilder> group);
        IConditionBuilder Or(Func<IConditionBuilder, IConditionBuilder> group);
    }
}