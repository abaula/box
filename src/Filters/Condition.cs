
namespace BoxLib.Filters
{
    class Condition
    {
        public Condition(ConditionType type,
            byte[]? value,
            IComparer comparer)
        {
            Type = type;
            Value = value;
            Comparer = comparer;
        }

        public ConditionType Type { get; }
        public byte[]? Value { get; }
        public IComparer Comparer { get; }
    }
}