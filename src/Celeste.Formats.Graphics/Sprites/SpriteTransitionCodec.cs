using System;
using System.Globalization;
using Celeste.Core.Randomness;

namespace Celeste.Formats.Graphics.Sprites
{
    public static class SpriteTransitionCodec
    {
        public static Chooser<TT> Parse<TT>(string data) where TT : IConvertible
        {
            var chooser = new Chooser<TT>();
            var array = data.Split(',');
            if (array.Length == 1 && array[0].IndexOf(':') == -1)
            {
                chooser.Add((TT)Convert.ChangeType(array[0], typeof(TT)), 1f);
                return chooser;
            }

            var array2 = array;
            foreach (var text in array2)
            {
                if (text.IndexOf(':') == -1)
                {
                    chooser.Add((TT)Convert.ChangeType(text, typeof(TT)), 1f);
                    continue;
                }

                var array3 = text.Split(':');
                var value = array3[0].Trim();
                var value2 = array3[1].Trim();
                chooser.Add((TT)Convert.ChangeType(value, typeof(TT)),
                    Convert.ToSingle(value2, CultureInfo.InvariantCulture));
            }

            return chooser;
        }
    }
}
