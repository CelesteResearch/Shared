using System;
using System.Collections.Generic;

namespace Celeste.Core.Text.Sequences
{
    public static class SourceIntegerSequenceParsing
    {
        public static int[] ReadCsvWithRangesAndRepetition(string csv)
        {
            if (csv == "") return new int[0];
            var values = new List<int>();
            foreach (string part in csv.Split(','))
            {
                if (part.IndexOf('-') != -1)
                {
                    string[] range = part.Split('-');
                    int start = Convert.ToInt32(range[0]);
                    int end = Convert.ToInt32(range[1]);
                    for (int value = start; value != end; value += Math.Sign(end - start)) values.Add(value);
                    values.Add(end);
                }
                else if (part.IndexOf('*') != -1)
                {
                    string[] repeat = part.Split('*');
                    int value = Convert.ToInt32(repeat[0]);
                    int count = Convert.ToInt32(repeat[1]);
                    for (int index = 0; index < count; index++) values.Add(value);
                }
                else values.Add(Convert.ToInt32(part));
            }

            return values.ToArray();
        }
    }
}
