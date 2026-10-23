using System;
using System.Collections.Generic;

namespace Celeste.Core.Text.Sequences
{
    public static class SourceIntegerSequenceParsing
    {
        public static int[] ReadCsvWithRangesAndRepetition(string csv)
        {
            if (csv == "") return /* ReSharper disable once UseCollectionExpression */ new int[0];
            var values = new List<int>();
            foreach (var part in csv.Split(','))
                if (part.IndexOf('-') != -1)
                {
                    var range = part.Split('-');
                    var start = Convert.ToInt32(range[0]);
                    var end = Convert.ToInt32(range[1]);
                    for (var value = start; value != end; value += Math.Sign(end - start)) values.Add(value);
                    values.Add(end);
                }
                else if (part.IndexOf('*') != -1)
                {
                    var repeat = part.Split('*');
                    var value = Convert.ToInt32(repeat[0]);
                    var count = Convert.ToInt32(repeat[1]);
                    for (var index = 0; index < count; index++) values.Add(value);
                }
                else
                {
                    values.Add(Convert.ToInt32(part));
                }

            return [.. values];
        }
    }
}
