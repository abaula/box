
namespace BoxLib.Filters.Builder
{
    class ConditionBuilder : IConditionBuilder
    {
        private readonly List<Condition> _conditionMembers;
        private readonly List<ConditionGroup> _conditionGroupMembers;

        public ConditionBuilder(ConditionGroupType type)
        {
            Type = type;
            _conditionMembers = new List<Condition>();
            _conditionGroupMembers = new List<ConditionGroup>();
        }

        public ConditionGroupType Type { get; }
        public Condition[] ConditionMembers => _conditionMembers.ToArray();
        public ConditionGroup[] ConditionGroupMembers => _conditionGroupMembers.ToArray();

        public IConditionBuilder Equal(byte[]? value, IComparer comparer)
        {
            _conditionMembers.Add(new Condition(ConditionType.Equal, value, comparer));

            return this;
        }

        public IConditionBuilder NotEqual(byte[]? value, IComparer comparer)
        {
            _conditionMembers.Add(new Condition(ConditionType.NotEqual, value, comparer));

            return this;
        }

        public IConditionBuilder GreaterOrEqualThan(byte[]? value, IComparer comparer)
        {
            _conditionMembers.Add(new Condition(ConditionType.GreaterOrEqualThan, value, comparer));

            return this;
        }


        public IConditionBuilder GreaterThan(byte[]? value, IComparer comparer)
        {
            _conditionMembers.Add(new Condition(ConditionType.GreaterThan, value, comparer));

            return this;
        }

        public IConditionBuilder LessOrEqualThan(byte[]? value, IComparer comparer)
        {
            _conditionMembers.Add(new Condition(ConditionType.LessOrEqualThan, value, comparer));

            return this;
        }

        public IConditionBuilder LessThan(byte[]? value, IComparer comparer)
        {
            _conditionMembers.Add(new Condition(ConditionType.LessThan, value, comparer));

            return this;
        }

        public IConditionBuilder And(Func<IConditionBuilder, IConditionBuilder> group)
        {
            var conditionBuilder = new ConditionBuilder(ConditionGroupType.And);

            group(conditionBuilder);
            _conditionGroupMembers.Add(new ConditionGroup(conditionBuilder.Type, conditionBuilder.ConditionMembers, conditionBuilder.ConditionGroupMembers));

            return this;
        }

        public IConditionBuilder Or(Func<IConditionBuilder, IConditionBuilder> group)
        {
            var conditionBuilder = new ConditionBuilder(ConditionGroupType.Or);

            group(conditionBuilder);
            _conditionGroupMembers.Add(new ConditionGroup(conditionBuilder.Type, conditionBuilder.ConditionMembers, conditionBuilder.ConditionGroupMembers));

            return this;
        }
    }
}