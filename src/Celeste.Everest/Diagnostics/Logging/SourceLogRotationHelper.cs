using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Celeste.Everest.Diagnostics.Logging
{
    public static class SourceLogRotationHelper
    {
        public class OldestFirst : IComparer<string>
        {
            public int Compare(string first, string second)
            {
                if (!TryParse(first, out var dateTime, out var index) ||
                    !TryParse(second, out var dateTime2, out var index2))
                    return string.Compare(first, second, StringComparison.Ordinal);

                return dateTime == dateTime2 ? index.CompareTo(index2) : dateTime.CompareTo(dateTime2);
            }
        }

        public static string GetFileNameByDate(DateTime date)
        {
            var text = $"log_{date:yyyyMMdd_HHmmss}";
            var list = Directory.GetFiles("LogHistory", text + "*.txt").ToList();
            if (list.Count == 0) return text + ".txt";

            var value = list.Max(fileName => !TryParse(fileName, out _, out var index) ? 0 : index) +
                        1;
            return $"{text}_{value}.txt";
        }

        private static bool TryParse(string path, out DateTime dateTime, out ulong index)
        {
            dateTime = DateTime.MinValue;
            index = 0uL;
            if (path == null) return false;

            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            var match =
                new Regex("^log_(?<dateTime>\\d{8}_\\d{6})(?:_(?<index>\\d+))?$").Match(fileNameWithoutExtension);
            if (!match.Success) return false;

            if (!DateTime.TryParseExact(match.Groups["dateTime"].Value, "yyyyMMdd_HHmmss", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out dateTime))
                return false;

            if (!match.Groups["index"].Success)
            {
                index = 0uL;
                return true;
            }

            return ulong.TryParse(match.Groups["index"].Value, out index);
        }
    }
}
