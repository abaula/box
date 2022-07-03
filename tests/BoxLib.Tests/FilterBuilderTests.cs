using Xunit;
using BoxLib.Filters;

namespace BoxLib.Tests
{
    public class FilterBuilderTests
    {
        [Fact]
        public void BuildFilter_Success()
        {
            var builder = FilterFactory.Create();

            var value1 = new byte[] { 1, 2, 3 };
            var value2 = new byte[] { 1, 2, 3, 4 };
            var comparer = ComparerFactory.GetDefault();

            // Is null or between.
            var filter = builder
                .Or(group1 => group1

                    .Equal(null, comparer)

                    .And(group2 => group2
                        .GreaterThan(value1, comparer)
                        .LessOrEqualThan(value2, comparer)
                    )
                )
                .Build();

            Assert.NotNull(filter.RootConditionGroup);

            // .Or()
            var or = filter.RootConditionGroup;
            Assert.Equal(ConditionGroupType.Or, or.Type);
            Assert.Single(or.ConditionMembers);
            Assert.Single(or.ConditionGroupMembers);

            // .Or(.Equal())
            var or_equal = or.ConditionMembers.Single();
            Assert.Equal(ConditionType.Equal, or_equal.Type);
            Assert.Null(or_equal.Value);
            Assert.Equal(comparer, or_equal.Comparer);

            // .Or(.And())
            var or_and = or.ConditionGroupMembers.Single();
            Assert.Equal(ConditionGroupType.And, or_and.Type);
            Assert.Equal(2, or_and.ConditionMembers.Length);
            Assert.Empty(or_and.ConditionGroupMembers);

            // .Or(.And(.GreaterThan()))
            var or_and_greaterThan = or_and.ConditionMembers.First();
            Assert.Equal(ConditionType.GreaterThan, or_and_greaterThan.Type);
            Assert.Equal(value1, or_and_greaterThan.Value);
            Assert.Equal(comparer, or_and_greaterThan.Comparer);

            // .Or(.And(.LessOrEqualThan()))
            var or_and_lessOrEqualThan = or_and.ConditionMembers.Last();
            Assert.Equal(ConditionType.LessOrEqualThan, or_and_lessOrEqualThan.Type);
            Assert.Equal(value2, or_and_lessOrEqualThan.Value);
            Assert.Equal(comparer, or_and_lessOrEqualThan.Comparer);
        }

        [Fact]
        public void BuildFilter_NotInitialized_Throws()
        {
            var builder = FilterFactory.Create();

            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }

        [Fact]
        public void BuildFilter_MoreThanOneRootCondition_Throws()
        {
            var comparer = ComparerFactory.GetDefault();
            var builder = FilterFactory.Create();

            Assert.Throws<InvalidOperationException>(() => builder.And(_ => _.Equal(null, comparer)).And(_ => _.Equal(null, comparer)).Build());
            Assert.Throws<InvalidOperationException>(() => builder.And(_ => _.Equal(null, comparer)).Or(_ => _.Equal(null, comparer)).Build());
            Assert.Throws<InvalidOperationException>(() => builder.Or(_ => _.Equal(null, comparer)).Or(_ => _.Equal(null, comparer)).Build());
            Assert.Throws<InvalidOperationException>(() => builder.Or(_ => _.Equal(null, comparer)).And(_ => _.Equal(null, comparer)).Build());
        }


        [Fact]
        public void Filter_Pass_Success()
        {
            var builder = FilterFactory.Create();

            var value1 = new byte[] { 1, 2, 3 };
            var value2 = new byte[] { 1, 2, 3, 4 };
            var value3 = new byte[] { 1, 2, 3, 5 };
            var value4 = new byte[] { 1, 2, 3, 4, 5 };
            var value5 = new byte[] { 1, 2, 3, 4, 6 };
            var value5_1 = new byte[] { 1, 2, 3, 4, 6 };
            var comparer = ComparerFactory.GetDefault();

            // Is null or Value or between.
            var filter = builder
                .Or(group1 => group1

                    .Equal(null, comparer)

                    .Equal(value5, comparer)

                    .And(group2 => group2
                        .GreaterThan(value1, comparer)
                        .LessOrEqualThan(value3, comparer)
                    )
                )
                .Build();

            Assert.True(filter.Pass(null));
            Assert.False(filter.Pass(value1));
            Assert.True(filter.Pass(value2));
            Assert.True(filter.Pass(value3));
            Assert.False(filter.Pass(value4));
            Assert.True(filter.Pass(value5_1));
        }
    }
}
