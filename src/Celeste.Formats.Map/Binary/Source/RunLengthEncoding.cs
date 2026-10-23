using System.Text;

namespace Celeste.Formats.Map.Binary.Source
{
    public static class RunLengthEncoding
    {
        public static string Decode(byte[] bytes)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i += 2) stringBuilder.Append((char)bytes[i + 1], bytes[i]);

            return stringBuilder.ToString();
        }
    }
}
