using Xunit;
using BoxLib.Filters;

namespace BoxLib.Tests
{
    public class BinaryComparerTests
    {
        [Fact]
        public void Compare_Array_Success()
        {
            var value1 = new byte[] { 1, 2, 3 };
            var value2 = new byte[] { 1, 2, 3, 4 };
            var value3 = new byte[] { 1, 2, 3, 5 };
            var value4 = new byte[] { 1, 2, 3 };

            var comparer = new BinaryComparer();

            var actual = comparer.Compare(value1, value2);
            Assert.Equal(-1, actual);

            actual = comparer.Compare(value2, value1);
            Assert.Equal(1, actual);

            actual = comparer.Compare(value2, value3);
            Assert.Equal(-1, actual);

            actual = comparer.Compare(value3, value2);
            Assert.Equal(1, actual);

            actual = comparer.Compare(null, null);
            Assert.Equal(0, actual);

            actual = comparer.Compare(null, value1);
            Assert.Equal(-1, actual);

            actual = comparer.Compare(value1, null);
            Assert.Equal(1, actual);

            actual = comparer.Compare(value1, value1);
            Assert.Equal(0, actual);

            actual = comparer.Compare(value1, value4);
            Assert.Equal(0, actual);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(2, 1, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(1, null, 1)]
        [InlineData(null, 1, -1)]
        [InlineData(null, null, 0)]
        public void Compare_Long_Success(long? left, long? right, int expected)
        {
            var leftValue = left != null ? ByteHelper.GetByteArray(left.Value) : null;
            var rightValue = right != null ? ByteHelper.GetByteArray(right.Value) : null;

            var comparer = new BinaryComparer();

            var actual = comparer.Compare(leftValue, rightValue);
            Assert.Equal(expected, actual);
        }
    }
}