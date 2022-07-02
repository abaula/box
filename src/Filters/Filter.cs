
namespace BoxLib.Filters
{
    class Filter : IFilter
    {
        public Filter(ConditionGroup rootConditionGroup)
        {
            RootConditionGroup = rootConditionGroup;
        }

        public ConditionGroup RootConditionGroup { get; }

        public bool Pass(byte[] value)
        {
            throw new NotImplementedException();
        }
    }
}