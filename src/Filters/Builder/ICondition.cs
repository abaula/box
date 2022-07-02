
namespace BoxLib.Filters.Builder
{
    public interface ICondition
    {
        ICondition Equal(byte[]? value, IComparer comparer);
        ICondition NotEqual(byte[]? value, IComparer comparer);
        ICondition GreaterThen(byte[]? value, IComparer comparer);
        ICondition GreaterOrEqualThen(byte[]? value, IComparer comparer);
        ICondition LessThen(byte[]? value, IComparer comparer);
        ICondition LessOrEqualThen(byte[]? value, IComparer comparer);
        ICondition And(Func<ICondition, ICondition> group);
        ICondition Or(Func<ICondition, ICondition> group);
    }
}