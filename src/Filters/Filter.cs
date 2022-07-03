
namespace BoxLib.Filters
{
    class Filter : IFilter
    {
        public Filter(ConditionGroup rootConditionGroup)
        {
            RootConditionGroup = rootConditionGroup;
        }

        public ConditionGroup RootConditionGroup { get; }

        public bool Pass(byte[]? value)
        {
            return CheckConditionGroup(RootConditionGroup, value);
        }

        private static bool CheckConditionGroup(ConditionGroup conditionGroup, byte[]? value)
        {
            // Для ИЛИ обработка останавливается при первом сравнении равном TRUE.
            // Для И обработка останавливается при первом сравнении равном FALSE.
            var stopFlag = conditionGroup.Type == ConditionGroupType.Or;

            // Первыми обрабатываем простые условия.
            foreach (var condition in conditionGroup.ConditionMembers)
            {
                var compareResult = condition.Comparer.Compare(value, condition.Value);
                var conditionResult = CheckConditionResult(condition.Type, compareResult);

                if (conditionResult == stopFlag)
                    return conditionResult;
            }

            // Вторыми обрабатываем сложные условия.
            foreach (var group in conditionGroup.ConditionGroupMembers)
            {
                var conditionResult = CheckConditionGroup(group, value);

                if (conditionResult == stopFlag)
                    return conditionResult;
            }

            // Для ИЛИ не было ни одного сравнения с результатом TRUE.
            // Для И не было ни одного сравнения с результатом FALSE.
            return !stopFlag;
        }

        private static bool CheckConditionResult(ConditionType type, int compareResult)
        {
            if (compareResult == 0)
                return type == ConditionType.Equal || type == ConditionType.GreaterOrEqualThan || type == ConditionType.LessOrEqualThan;

            if (compareResult == -1)
                return type == ConditionType.NotEqual || type == ConditionType.LessThan || type == ConditionType.LessOrEqualThan;

            if (compareResult == 1)
                return type == ConditionType.NotEqual || type == ConditionType.GreaterThan || type == ConditionType.GreaterOrEqualThan;

            throw new ArgumentException($"Неверное значение параметра {nameof(compareResult)}.");
        }
    }
}