
namespace BoxLib.Filters.Builder
{
    class Builder : IBuilder
    {
        public IFilter Build()
        {
            throw new NotImplementedException();
        }

        public IBuilder And(Func<ICondition, ICondition> group)
        {
            throw new NotImplementedException();
        }

        public IBuilder Or(Func<ICondition, ICondition> group)
        {
            throw new NotImplementedException();
        }
    }
}