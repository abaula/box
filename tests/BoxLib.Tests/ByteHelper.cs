using System.Text;

namespace BoxLib.Tests
{
    static class ByteHelper
    {
        public static byte[] GetByteArray(long value)
        {
            if (BitConverter.IsLittleEndian)
                return BitConverter.GetBytes(value).Reverse().ToArray();

            return BitConverter.GetBytes(value);
        }

        public static byte[] GetByteArray(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }
    }
}