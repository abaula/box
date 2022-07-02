
namespace BoxLib.Filters.Builder
{
    class Builder : IBuilder
    {
        private ConditionBuilder? _conditionBuilder;

        public Builder()
        {
            _conditionBuilder = null;
        }

        public IFilter Build()
        {
            if (_conditionBuilder == null)
                throw new InvalidOperationException("Не задано ни одного условия фильтрации.");

            var rootConditionGroup = new ConditionGroup(_conditionBuilder.Type, _conditionBuilder.ConditionMembers, _conditionBuilder.ConditionGroupMembers);
            return new Filter(rootConditionGroup);
        }

        public IBuilder And(Func<IConditionBuilder, IConditionBuilder> group)
        {
            if (_conditionBuilder != null)
                throw new InvalidOperationException("Может быть задано только одно корневое условие фильтрации.");

            _conditionBuilder = new ConditionBuilder(ConditionGroupType.And);
            group(_conditionBuilder);

            return this;
        }

        public IBuilder Or(Func<IConditionBuilder, IConditionBuilder> group)
        {
            if (_conditionBuilder != null)
                throw new InvalidOperationException("Может быть задано только одно корневое условие фильтрации.");

            _conditionBuilder = new ConditionBuilder(ConditionGroupType.Or);
            group(_conditionBuilder);

            return this;
        }
    }
}