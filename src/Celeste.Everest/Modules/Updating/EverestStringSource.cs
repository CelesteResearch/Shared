using System.Text;

namespace Celeste.Everest.Modules.Updating
{
    public static class EverestStringSource
    {
        public static string SpacedPascalCase(string input)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (i > 0 && char.IsUpper(c) && char.IsLower(input[i - 1])) builder.Append(' ');
                builder.Append(c);
            }

            return builder.ToString();
        }

        public static string DialogKeyify(string input)
            => input.Replace('/', '_').Replace('-', '_').Replace('+', '_').Replace(' ', '_');
    }
}
