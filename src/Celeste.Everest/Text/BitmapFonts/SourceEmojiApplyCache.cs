using System.Text;

namespace Celeste.Everest.Text.BitmapFonts
{
    internal sealed class SourceEmojiApplyCache : SourceStringCacheHelper
    {
        private readonly SourceEverestEmojiState owner;

        public SourceEmojiApplyCache(SourceEverestEmojiState owner, IEverestEmojiProcess process) : base("Emoji.Apply",
            1000, process)
        {
            this.owner = owner;
        }

        protected override string Compute(string text)
        {
            lock (owner._IDs)
            {
                StringBuilder stringBuilder = new StringBuilder();
                int num = 0;
                int num2 = -1;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != ':')
                    {
                        continue;
                    }

                    if (num2 >= 0 && text[num2] == ':')
                    {
                        string key = text.Substring(num2 + 1, i - 1 - (num2 + 1) + 1);
                        if (owner._IDs.TryGetValue(key, out var value))
                        {
                            stringBuilder.Append(text, num, num2 - 1 - num + 1);
                            stringBuilder.Append((char)(57344 + value));
                            i++;
                            num = i;
                        }
                    }

                    num2 = i;
                }

                if (num < text.Length)
                {
                    stringBuilder.Append(text, num, text.Length - 1 - num + 1);
                }

                return stringBuilder.ToString();
            }
        }
    }
}
