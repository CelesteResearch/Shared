using System;
using System.Collections.Generic;

namespace Celeste.Core.Text
{
    public static class SourceCsvIntegerFrames
    {
        public static int[] Read(string csv)
        {
            if (csv == "") return /* ReSharper disable once UseCollectionExpression */ new int[0];

            var array = csv.Split(',');
            var list = new List<int>();
            var array2 = array;
            foreach (var text in array2)
                if (text.IndexOf('-') != -1)
                {
                    var array3 = text.Split('-');
                    var num = Convert.ToInt32(array3[0]);
                    var num2 = Convert.ToInt32(array3[1]);
                    for (var j = num; j != num2; j += Math.Sign(num2 - num)) list.Add(j);

                    list.Add(num2);
                }
                else if (text.IndexOf('*') != -1)
                {
                    var array4 = text.Split('*');
                    var item = Convert.ToInt32(array4[0]);
                    var num3 = Convert.ToInt32(array4[1]);
                    for (var k = 0; k < num3; k++) list.Add(item);
                }
                else
                {
                    list.Add(Convert.ToInt32(text));
                }

            return [.. list];
        }
    }
}
