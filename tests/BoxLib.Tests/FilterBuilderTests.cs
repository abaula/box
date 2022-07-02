using Xunit;
using BoxLib;

namespace BoxLib.Tests
{
    public class FilterBuilderTests
    {
        [Fact]
        public void CreateFilter_Success()
        {
            var builder = FilterFactory.Create();

            var value1 = new byte[] { 1, 2, 3 };
            var value2 = new byte[] { 1, 2, 3, 4 };
            var value3 = new byte[] { 1, 2, 3, 5 };
            var comparer = ComparerFactory.GetDefault();

            // Is null or between.
            var filter = builder
                .Or(group1 => group1

                    .Equal(null, comparer)

                    .And(group2 => group2
                        .GreaterThen(value1, comparer)
                        .LessOrEqualThen(value3, comparer)
                    )
                )
                .Build();

            var actual = filter.IsTrue(value2);
            Assert.True(actual);
        }
    }
}
