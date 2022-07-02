
namespace BoxLib.Filters
{
    class BinaryComparer : IComparer
    {
        public int Compare(byte[]? left, byte[]? right)
        {
            if (ReferenceEquals(left, right))
                return 0;

            if (left is null)
                return -1;

            if (right is null)
                return 1;

            if (left.Length < right.Length)
                return -1;

            if (left.Length > right.Length)
                return 1;

            for (var i = 0; i < left.Length; i++)
            {
                var value = left[i] - right[i];

                if (value != 0)
                    return value > 0 ? 1 : -1;
            }

            return 0;
        }
    }
}