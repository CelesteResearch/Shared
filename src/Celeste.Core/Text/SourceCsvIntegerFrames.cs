using System;
using System.Collections.Generic;

namespace Celeste.Core.Text
{
    public static class SourceCsvIntegerFrames
    {
        public static int[] Read(string csv)
        {
            if (csv == "")
            {
                return new int[0];
            }

            string[] array = csv.Split(',');
            List<int> list = new List<int>();
            string[] array2 = array;
            foreach (string text in array2)
            {
                if (text.IndexOf('-') != -1)
                {
                    string[] array3 = text.Split('-');
                    int num = Convert.ToInt32(array3[0]);
                    int num2 = Convert.ToInt32(array3[1]);
                    for (int j = num; j != num2; j += Math.Sign(num2 - num))
                    {
                        list.Add(j);
                    }

                    list.Add(num2);
                }
                else if (text.IndexOf('*') != -1)
                {
                    string[] array4 = text.Split('*');
                    int item = Convert.ToInt32(array4[0]);
                    int num3 = Convert.ToInt32(array4[1]);
                    for (int k = 0; k < num3; k++)
                    {
                        list.Add(item);
                    }
                }
                else
                {
                    list.Add(Convert.ToInt32(text));
                }
            }

            return list.ToArray();
        }
    }
}
