using System;
using System.Globalization;

namespace Celeste.Formats.Graphics.Sprites
{
    public static class SpriteTransitionCodec
    {
        public static global::Celeste.Core.Randomness.Chooser<TT> Parse<TT>(string data) where TT : IConvertible
        {
            global::Celeste.Core.Randomness.Chooser<TT> chooser = new global::Celeste.Core.Randomness.Chooser<TT>();
            string[] array = data.Split(',');
            if (array.Length == 1 && array[0].IndexOf(':') == -1)
            {
                chooser.Add((TT)Convert.ChangeType(array[0], typeof(TT)), 1f);
                return chooser;
            }

            string[] array2 = array;
            foreach (string text in array2)
            {
                if (text.IndexOf(':') == -1)
                {
                    chooser.Add((TT)Convert.ChangeType(text, typeof(TT)), 1f);
                    continue;
                }

                string[] array3 = text.Split(':');
                string value = array3[0].Trim();
                string value2 = array3[1].Trim();
                chooser.Add((TT)Convert.ChangeType(value, typeof(TT)),
                    Convert.ToSingle(value2, CultureInfo.InvariantCulture));
            }

            return chooser;
        }
    }
}
