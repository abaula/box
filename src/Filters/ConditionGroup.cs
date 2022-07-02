
namespace BoxLib.Filters
{
    class ConditionGroup
    {
        public ConditionGroup(ConditionGroupType type,
            Condition[] conditionMembers,
            ConditionGroup[] conditionGroupMembers)
        {
            Type = type;
            ConditionMembers = conditionMembers;
            ConditionGroupMembers = conditionGroupMembers;
        }

        public ConditionGroupType Type { get; }
        public Condition[] ConditionMembers { get; }
        public ConditionGroup[] ConditionGroupMembers { get; }
    }
}